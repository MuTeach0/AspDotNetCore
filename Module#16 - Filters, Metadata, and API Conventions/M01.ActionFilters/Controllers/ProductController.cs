using M01.ActionFilters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace M01.ActionFilters.Controllers;

[ApiController]
[Route("api/products")]
[TrackActionTimeFilterV2]
public class ProductController(): ControllerBase
{
    [HttpGet]
    public IActionResult Get() =>
        Ok(new[] { "Keyboard: [$52.99]", "Mouse: [$34.99]" });
}