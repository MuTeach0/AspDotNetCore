
namespace M01.ILoggerCategory.Services;

public class OrderService(ILogger<OrderService> logger)
{
    // Simulate order service methods here
    public Task ProcessOrder(Guid orderId)
    {
        logger.LogInformation("Order: {OrderId} processing started", orderId);
        // Simulate some processing logic
        return Task.CompletedTask;
    }
}