using Microsoft.AspNetCore.Mvc;
using M02.MinimalDataAnnotations.Requests;

namespace M02.MinimalDataAnnotations.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(/*[FromBody]*/ CreateProductRequest request) =>
        //(!ModelState.IsValid) ? ValidationProblem(ModelState) :
        Created($"/api/products/{Guid.NewGuid()}", request);

}