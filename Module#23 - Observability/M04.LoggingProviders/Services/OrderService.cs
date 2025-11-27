namespace M04.LoggingProviders.Services;

public class OrderService(ILogger<OrderService> logger)
{
    // Simulate order service methods here
    public Task ProcessOrder(Guid orderId, Guid userId)
    {
        logger.LogError("Failed to process order {OrderId} for user {UserId}.", orderId, userId);
        // Simulate some processing logic
        return Task.CompletedTask;
    }
}