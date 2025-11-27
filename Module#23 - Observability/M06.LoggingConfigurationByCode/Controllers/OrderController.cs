using M06.LoggingConfigurationCode.Services;
using Microsoft.AspNetCore.Mvc;

namespace M06.LoggingConfigurationCode.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(OrderService orderService) : ControllerBase
{
    [HttpPost("{orderId:guid}/process")]
    public IActionResult Process(Guid orderId)
    {
        var userId = Guid.Parse("77d942e0-ef46-4753-aa91-4afcc2d6f2b1"); // Simulated user ID
        orderService.ProcessOrder(orderId, userId);
        return Ok(new
        {
            OrderId = orderId,
            Status = "Processed"
        });
    }
}