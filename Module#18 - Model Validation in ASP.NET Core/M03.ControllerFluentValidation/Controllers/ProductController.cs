using Microsoft.AspNetCore.Mvc;
using M03.ControllerFluentValidation.Requests;

namespace M03.ControllerFluentValidation.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(/*[FromBody]*/ CreateProductRequest request) =>
        //(!ModelState.IsValid) ? ValidationProblem(ModelState) :
        Created($"/api/products/{Guid.NewGuid()}", request);

}