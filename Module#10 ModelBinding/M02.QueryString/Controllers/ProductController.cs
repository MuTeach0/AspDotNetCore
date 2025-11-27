using M02.QueryString.Models;
using Microsoft.AspNetCore.Mvc;

namespace M01.RoutingParameter.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet("product-controller")]
    public IActionResult Get(int page, int pageSize) => Ok($"Showing {pageSize} items of page # {page}");

    [HttpGet("product-controller-complex-query")]
    public IActionResult GetComplexQuery([FromQuery] SearchRequest request) =>
        Ok(request);


    [HttpGet("product-controller-array")]
    public IActionResult GetArray([FromQuery] Guid[] ids) =>
        Ok(ids);

    [HttpGet("date-range-controller")]
    public IActionResult GetArray(DateRangeQuery dateRange) =>
        Ok(dateRange);
}