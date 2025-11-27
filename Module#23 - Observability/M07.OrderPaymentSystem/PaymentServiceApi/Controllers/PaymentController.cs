using Microsoft.AspNetCore.Mvc;
using PaymentServiceApi.Data;
using PaymentServiceApi.Models;
using PaymentServiceApi.Requests;

namespace PaymentServiceApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController(
    AppDbContext context,
    IConfiguration configuration,
    ILogger<PaymentController> logger) : ControllerBase
{
    [HttpPost("process")]
    public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
    {
        logger.LogInformation("Start Processing payment for OrderId: {OrderId}, Amount: {Amount}",
            request?.OrderId, request?.Amount);
        try
        {
            if(request is null || request.OrderId == Guid.Empty || request.Amount <= 0)
            {
                logger.LogWarning("Invalid payment request received, OrderId: {OrderId}, Amount: {Amount}",
                    request?.OrderId, request?.Amount);
                return BadRequest("Invalid payment request.");
            }

            if(string.IsNullOrWhiteSpace(configuration["PaymentGateway:ApiKey"]))
            {
                logger.LogError("Fatal: Missing API key.Payment failed for OrderId: {OrderId}", request.OrderId);
                // In a real application, you might want to throw an exception or handle this more gracefully
                throw new InvalidOperationException("Fatal: Missing API key.");
            }

            // Simulate Payment failure chance <= 10%
            if (Random.Shared.NextDouble() <= 0.1)
            {
                logger.LogWarning("Simulated payment failure for OrderId: {OrderId}", request.OrderId);
                return StatusCode(502, new { Message = "Payment processing failed." });
            }

            // Create a new payment record
            var payment = new Payment
            {
                OrderId = request.OrderId,
                Amount = request.Amount,
                PaymentReference = $"txn_{Guid.NewGuid().ToString("N")[..8]}",
                ProcessedAt = DateTime.UtcNow
            };

            await context.SaveChangesAsync();

            logger.LogInformation("Payment succeeded.TransactionId: {TransactionId}, OrderId: {OrderId}",
                payment.PaymentReference, payment.OrderId);

            return Created($"/payment/{payment.PaymentReference}", new
            {
                TransactionId = payment.PaymentReference,
                Success = true
            });
        }
        catch (Exception ex)
        {
            logger.LogCritical(ex, "Unhandled exception during payment processing. OrderId: {OrderId}", request?.OrderId);

            return StatusCode(500, new { Message = "Critical error occurred." });
        }
    }
}