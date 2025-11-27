using M01.UrlPathVersioningController.Data;
using M01.UrlPathVersioningController.Models;
using M01.UrlPathVersioningController.Responses.V1;
using Microsoft.AspNetCore.Mvc;

namespace M01.UrlPathVersioningController.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/products")]
[Route("api/v{version:apiVersion}/products")]
public class ProductController(ProductRepository repository) : ControllerBase
{
    [HttpGet("{productId}")]
    public ActionResult<ProductResponse> GetProduct(Guid productId)
    {
        // RFC 8594 - Indicating API Deprecation and Sunset Dates
        Response.Headers["Deprecated"] = "true";
        Response.Headers["Sunset"] = "Wed, 31 Dec 2025 23:59:59 GMT";
        Response.Headers["Link"] = "</api/v2/products/>; rel=\"successor-version\"";

        var product = repository.GetProductById(productId);

        return product is null ? NotFound() : Ok(ProductResponse.FromModel(product));
    }
}