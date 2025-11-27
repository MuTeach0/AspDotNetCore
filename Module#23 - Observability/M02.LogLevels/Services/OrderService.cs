
namespace M02.LogLevels.Services;

public class OrderService(ILogger<OrderService> logger)
{
    // Simulate order service methods here
    public Task ProcessOrder(Guid orderId)
    {
        logger.LogInformation("Order: {OrderId} processing started", orderId);
        // logger.Log(LogLevel.Information, "Order: {OrderId} is being validated", orderId);

        logger.LogTrace("Trace: Entering ProcessOrder method for OrderId: {OrderId}", orderId);

        logger.LogDebug("Debug: Validating order details for OrderId: {OrderId}", orderId);

        logger.LogWarning("Warning: OrderId: {OrderId} has a delayed payment method", orderId);

        logger.LogError("Error: Failed to process payment for OrderId: {OrderId}", orderId);

        logger.LogCritical("Critical: System outage while processing OrderId: {OrderId}", orderId);

        return Task.CompletedTask;
    }
}