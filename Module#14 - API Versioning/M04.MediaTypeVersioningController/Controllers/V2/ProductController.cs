using M04.MediaTypeVersioningController.Data;
using M04.MediaTypeVersioningController.Responses.V2;
using Microsoft.AspNetCore.Mvc;

namespace M04.MediaTypeVersioningController.Controllers.V2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/products")]
public class ProductController(ProductRepository repository) : ControllerBase
{
    [HttpGet("{productId}")]
    public ActionResult<ProductResponse> GetProduct(Guid productId)
    {
        var product = repository.GetProductById(productId);

        return product is null ? NotFound() : Ok(ProductResponse.FromModel(product));
    }
}