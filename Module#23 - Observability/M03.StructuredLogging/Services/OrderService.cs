
namespace M03.StructuredLogging.Services;

public class OrderService(ILogger<OrderService> logger)
{
    // Simulate order service methods here
    public Task ProcessOrder(Guid orderId, Guid userId)
    {
        // Avoid unstructured logging
        logger.LogError($"Failed to process order {orderId} for user {userId}."); // Unstructured logging example

        // Use structured logging instead
        logger.LogError("Failed to process order {OrderId} for user {UserId}.", orderId, userId); // Structured logging example

        // Simulate some processing logic
        return Task.CompletedTask;
    }
}