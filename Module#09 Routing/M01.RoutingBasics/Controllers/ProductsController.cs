using Microsoft.AspNetCore.Mvc;

namespace M01.RoutingBasics.Controllers;

[ApiController]
[Route("[controller]")] // ../products
public class ProductsController : ControllerBase
{
    // ../products/all
    [HttpGet("all")]
    public IActionResult GetProducts() =>
        Ok
        (new[]{
            "Product #1",
            "Product #2"
        });
}