using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using M05.ResponseCaching.Requests;
using M05.ResponseCaching.Responses;
using M05.ResponseCaching.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace M05.ResponseCaching.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    [ResponseCache(Duration = 20, Location = ResponseCacheLocation.Any, VaryByQueryKeys = [ "page", "pageSize" ])]
    public async Task<ActionResult> Get(int page = 1, int pageSize = 10)
    {
        Console.WriteLine("Controller Action Invoked");
        var response = await productService.GetProductsAsync(page, pageSize);
        return Ok(response);
    }

    [HttpGet("{productId:int}", Name = nameof(GetById))]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByHeader = "If-None-Match" )]
    public async Task<ActionResult<ProductResponse>> GetById(int productId)
    {
        Console.WriteLine("Controller Action(Get By Id) Invoked");
        var product = await productService.GetProductByIdAsync(productId);
        if (product  is null)
            return NotFound($"Product with Id '{productId}' not found");

        var eTag = GenerateEtag(product);
        if (Request.Headers.IfNoneMatch == eTag)
            return StatusCode(304); // Not Modified

        Response.Headers.ETag = new EntityTagHeaderValue(eTag).ToString();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductRequest request)
    {
        var response = await productService.AddProductAsync(request);
        return CreatedAtRoute(nameof(GetById), new { productId = response.ProductId }, response);
    }

    [HttpPut("{productId:int}")]
    public async Task<IActionResult> Put(int productId, [FromBody] UpdateProductRequest request)
    {
        await productService.UpdateProductAsync(productId, request);
        return NoContent();
    }

    [HttpDelete("{productId:int}")]
    public async Task<IActionResult> Delete(int productId)
    {
        await productService.DeleteProductAsync(productId);
        return NoContent();
    }

    private static string GenerateEtag(ProductResponse product)
    {
        var row = $"{product.ProductId}|{product.Name}|{product.Price}";
        var bytes = Encoding.UTF8.GetBytes(row);
        var hash = SHA256.HashData(bytes);
        return $"\"{Convert.ToBase64String(hash)}\"";
    }

}