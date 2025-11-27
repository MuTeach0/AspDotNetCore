using Microsoft.AspNetCore.Mvc;
using PaymentServiceApi.Requests;

namespace PaymentServiceApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    [HttpPost("process")]
    public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
    {
        // Simulate async processing
        await Task.Delay(Random.Shared.Next(100, 500));

        // Mock success / failure based on amount
        var success = Random.Shared.NextDouble() > 0.1; // 90% success rate
        // var success = true;

        // Return appropriate response
        if (!success)
            return StatusCode(502, "Payment processing failed.");

        return Ok(new
        {
            TransactionId = $"txn_{Guid.NewGuid():N}"[..8],
            Success = true,
        });

    }
}