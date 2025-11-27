using System.Text;
using M02.BuildingRESTFullApi.Data;
using M02.BuildingRESTFullApi.Models;
using M02.BuildingRESTFullApi.Requests;
using M02.BuildingRESTFullApi.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace M02.BuildingRESTFullApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(ProductRepository repository) : ControllerBase
{
    [HttpOptions]
    public IActionResult OptionsProducts()
    {
        Response.Headers.Append("Allow", "GET, POST, PUT, PATCH, DELETE, OPTIONS");
        return NoContent();
    }

    [HttpHead("{productId:guid}")]
    public IActionResult HeadProduct(Guid productId) =>
        repository.ExistsById(productId) ? Ok() : NotFound();

    [HttpGet]
    public IActionResult GetPaged(int page = 1, int pageSize = 10)
    {
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 100);

        int totalCount = repository.GetProductsCount();

        var products = repository.GetAllProductsPage(page, pageSize);

        var pageResult = PageResult<ProductResponse>.Create(
             ProductResponse.FromModels(products),
            totalCount,
            page,
            pageSize);

        return Ok(pageResult);
    }

    [HttpGet("{productId:guid}", Name = "GetProductById")]
    public ActionResult<ProductResponse> GetProductById(Guid productId, bool includeReviews = false)
    {
        var product = repository.GetProductById(productId);

        if (product is null)
            return NotFound($"product with Id `{productId}` not found");

        List<ProductReview>? reviews = null;
        if (includeReviews)
            reviews = repository.GetProductReviews(productId);
        return ProductResponse.FromModel(product, reviews);
    }

    [HttpPost]
    public IActionResult CreatePost(CreateProductRequest request)
    {
        if (repository.ExistsByName(request.Name))
            return Conflict($"A product with the name `{request.Name}` already exists");

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Price = request.Price
        };

        repository.AddProduct(product);

        return CreatedAtRoute
        (
            routeName: nameof(GetProductById),
            routeValues: new { productId = product.Id },
            value: ProductResponse.FromModel(product)
        );
    }

    [HttpPut("{productId:guid}")]
    public IActionResult Put(Guid productId, UpdateProductRequest request)
    {
        var product = repository.GetProductById(productId);
        if (product is null)
            return NotFound($"product with Id `{productId}` not found");

        product.Name = request.Name;
        product.Price = request.Price ?? 0;

        var succeeded = repository.UpdateProduct(product);

        if (!succeeded)
            return StatusCode(500, "Failed to update product");

        return NoContent();
    }

    [HttpPatch("{productId:guid}")]
    public IActionResult Patch(Guid productId, JsonPatchDocument<UpdateProductRequest>? patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("Invalid patch document");

        var product = repository.GetProductById(productId);

        if (product is null)
            return NotFound($"product with Id `{productId}` not found");

        var updateModel = new UpdateProductRequest
        {
            Name = product.Name,
            Price = product.Price
        };

        patchDoc.ApplyTo(updateModel);

        product.Name = updateModel.Name;
        product.Price = updateModel.Price ?? 0;

        var succeeded = repository.UpdateProduct(product);
        if (!succeeded)
            return StatusCode(500, "Failed to patch product");

        return NoContent();
    }

    [HttpDelete("{productId:guid}")]
    public IActionResult Delete(Guid productId)
    {
        if (!repository.ExistsById(productId))
            return NotFound($"Product with Id `{productId}` not found");

        var succeeded = repository.DeleteProduct(productId);
        if (!succeeded)
            return StatusCode(500, "Failed to Delete product");

        return NoContent();
    }

    [HttpPost("process")]
    public IActionResult ProcessAsync()
    {
        var jobId = Guid.NewGuid();

        return Accepted(
            $"/api/products/status/{jobId}",
            new { jobId, status = "Processing" }
        );
    }

    [HttpGet("status/{jobId}")]
    public IActionResult GetProcessingStatus(Guid jobId)
    {
        var isStillProcessing = false; // fake it
        return Ok(new { jobId, status = isStillProcessing ? "Processing" : "Completed" });
    }

    [HttpGet("csv")]
    public IActionResult GetProductsCSV()
    {
        var products = repository.GetAllProductsPage(1, 100);

        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("Id,Name,Price"
        );
        foreach (var p in products)
            csvBuilder.AppendLine($"{p.Id},{p.Name},{p.Price}");

        var fileBytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());

        return File(fileBytes, "text/csv", "product-catalog_1_100.csv");
    }


    [HttpGet("physical-csv-file")]
    public IActionResult GetPhysicalFile()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "products.csv");
        return PhysicalFile(filePath, "text/csv", "products-export.csv");
    }

    [HttpGet("products-legacy")]
    public IActionResult GetRedirect() => Redirect("/api/products/temp-products");

    [HttpGet("temp-products")]
    public IActionResult TempProducts() => Ok(new { message = "You're in the temp endpoint. Chill." });

    [HttpGet("legacy-products")]
    public IActionResult GetPermanentRedirect() => RedirectPermanent("/API/PRODUCTS/PRODUCT-CATALOG");

    [HttpGet("product-catalog")]
    public IActionResult Catalog() => Ok(new { message = "This is the permanent new location" });


}