using System.Globalization;
using OrderServiceApi.Models;
using OrderServiceApi.Repositories;
using OrderServiceApi.Requests;
using OrderServiceApi.Responses;

namespace OrderServiceApi.Services;

public class OrderService(
    IOrderRepository repository,
    HttpClient paymentHttpClient,
    ILogger<OrderService> logger) : IOrderService
{
    public async Task<OrderResponse?> GetByIdAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        var order = await repository.GetByIdAsync(orderId, cancellationToken);
        if (order is null)
        {
            logger.LogInformation("Order {OrderId} not found", orderId);
            return null;
        }

        return OrderResponse.FromModel(order);
    }

    public async Task<OrderResponse> CreateAsync(CreateOrderRequest request, CancellationToken cancellationToken = default)
    {
        var items = request.Items.Select(i =>
            new OrderItem(i.ProductId, i.Quantity, i.UnitPrice)).ToList();

        var order = new Order(request.CustomerId, items);

        await repository.AddAsync(order, cancellationToken);
        logger.LogInformation(
            "Created new order. Order Id: {OrderId}, Customer Id: {CustomerId}, Items count: {ItemsCount} created",
            order.Id, order.CustomerId, order.Items.Count);

        return OrderResponse.FromModel(order);
    }

    public async Task PayAsync(Guid orderId, PaymentRequest request, CancellationToken cancellationToken = default)
    {
        var order = await repository.GetByIdAsync(orderId, cancellationToken);

        if(order is null)
        {
            logger.LogWarning("Order not found. OrderId: {OrderId}", orderId);
            throw new KeyNotFoundException($"Order {orderId} not found");
        }

        if (order.PaidAt.HasValue)
        {
            logger.LogWarning("Attempt to pay already-paid order. OrderId: {OrderId}", orderId);

            throw new InvalidOperationException("Order has already been paid.");
        }

        var payload = new Dictionary<string, string?>
        {
            { "OrderId", orderId.ToString() },
            { "Amount", order.TotalAmount.ToString(CultureInfo.InvariantCulture) },
            { "Currency", "USD" },
            { "PaymentMethod", request.PaymentMethod.ToString() },
            { "CardNumber", request.CardNumber },
            { "CardHolderName", request.CardHolderName },
        };

        HttpResponseMessage response;
        try
        {
            response = await paymentHttpClient.PostAsJsonAsync("Payment/process", payload, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "HTTP request to payment gateway failed. OrderId: {OrderId}", orderId);
            throw;
        }

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(cancellationToken);

            logger.LogError(
                "Payment gateway returned error. StatusCode: {StatusCode}, Body: {Body}, OrderId: {OrderId}",
                (int)response.StatusCode, body, orderId);

            throw new InvalidOperationException($"Payment failed with status: {(int)response.StatusCode}, body: {body}");
        }

        var paymentResult = await response.Content.ReadFromJsonAsync<PaymentResponse>(cancellationToken);

        if (paymentResult is null)
        {
            var raw = await response.Content.ReadAsStringAsync(cancellationToken);

            logger.LogError(
                "Failed to deserialize payment response. Raw response: {RawResponse}, OrderId: {OrderId}",
                raw, orderId);

            throw new InvalidOperationException($"Deserialization failed. Raw response: {raw}");
        }

        if (!paymentResult.Success)
        {
            logger.LogWarning(
                "Payment was declined by gateway. OrderId: {OrderId}, TransactionId: {TransactionId}",
                orderId, paymentResult.TransactionId);
            throw new InvalidOperationException("Payment was declined");
        }

        order.PaidAt = DateTime.UtcNow;
        order.PaymentReference = paymentResult.TransactionId;

        await repository.UpdateAsync(order, cancellationToken);
        logger.LogInformation(
            "Order payment successful. OrderId: {OrderId}, TransactionId: {TransactionId}",
            orderId, paymentResult.TransactionId);
    }

    public async Task CancelAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Attempting to cancel order. OrderId: {OrderId}", orderId);
        var order = await repository.GetByIdAsync(orderId, cancellationToken);

        if(order is null)
        {
            logger.LogWarning("Order not found. OrderId: {OrderId}", orderId);
            throw new KeyNotFoundException($"Order {orderId} not found");
        }

        if (order.PaidAt.HasValue)
        {
            logger.LogWarning("Tried to cancel a paid order. OrderId: {OrderId}", orderId);
            throw new InvalidOperationException("paid invoice can not be cancelled");
        }

        await repository.RemoveAsync(order, cancellationToken);
        logger.LogInformation("Order canceled successfully. OrderId: {OrderId}", orderId);
    }
}
