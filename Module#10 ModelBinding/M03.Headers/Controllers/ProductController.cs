
using Microsoft.AspNetCore.Mvc;

namespace M03.Headers.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet("product-controller")]
    public IActionResult Get([FromHeader(Name = "X-API-Version")] string apiVersion) =>
       Ok($"API Version: {apiVersion}");
}