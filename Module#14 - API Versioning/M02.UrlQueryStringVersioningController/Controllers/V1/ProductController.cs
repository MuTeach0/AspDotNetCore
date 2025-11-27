using M02.UrlQueryStringVersioningController.Data;
using M02.UrlQueryStringVersioningController.Responses.V1;
using Microsoft.AspNetCore.Mvc;

namespace M02.UrlQueryStringVersioningController.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/products")]
public class ProductController(ProductRepository repository) : ControllerBase
{
    [HttpGet("{productId}")]
    public ActionResult<ProductResponse> GetProduct(Guid productId)
    {
        // RFC 8594 - Indicating API Deprecation and Sunset Dates
        Response.Headers["Deprecated"] = "true";
        Response.Headers["Sunset"] = "Wed, 31 Dec 2025 23:59:59 GMT";
        Response.Headers["Link"] = "</api/products?api-version=2.0>; rel=\"successor-version\"";

        var product = repository.GetProductById(productId);

        return product is null ? NotFound() : Ok(ProductResponse.FromModel(product));
    }
}