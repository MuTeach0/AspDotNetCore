
using M05.Body.Requests;
using Microsoft.AspNetCore.Mvc;

namespace M05.Body.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    [HttpPost("product-controller")]
    public IActionResult Get(ProductRequest product) =>
       Ok(product);
}