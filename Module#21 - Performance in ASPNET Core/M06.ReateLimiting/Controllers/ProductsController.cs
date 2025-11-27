using M06.RateLimiting.Requests;
using M06.RateLimiting.Responses;
using M06.RateLimiting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace M06.RateLimiting.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    [EnableRateLimiting(policyName: "DefaultPolicy")]
    public async Task<ActionResult> Get(int page = 1, int pageSize = 10)
    {
        Console.WriteLine("Controller Action Invoked");
        var response = await productService.GetProductsAsync(page, pageSize);
        return Ok(response);
    }

    [HttpGet("{productId:int}", Name = nameof(GetById))]
    public async Task<ActionResult<ProductResponse>> GetById(int productId)
    {
        Console.WriteLine("Controller Action(Get By Id) Invoked");
        var product = await productService.GetProductByIdAsync(productId);
        if (product  is null)
            return NotFound($"Product with Id '{productId}' not found");

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

}