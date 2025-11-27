using Microsoft.AspNetCore.Mvc;
using M01.ControllerDataAnnotations.Requests;

namespace M01.ControllerDataAnnotations.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(/*[FromBody]*/ CreateProductRequest request) =>
        //(!ModelState.IsValid) ? ValidationProblem(ModelState) :
        Created($"/api/products/{Guid.NewGuid()}", request);

}