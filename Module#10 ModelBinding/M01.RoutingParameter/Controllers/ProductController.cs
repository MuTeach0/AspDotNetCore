using Microsoft.AspNetCore.Mvc;

namespace M01.RoutingParameter.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet("product-controller/{id:int}")]
    public IActionResult Get(int id) =>
        Ok(id);

}