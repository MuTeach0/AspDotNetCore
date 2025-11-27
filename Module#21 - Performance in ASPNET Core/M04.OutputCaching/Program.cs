using System.Collections.Immutable;
using M04.OutputCaching.Data;
using M04.OutputCaching.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add Default Output Caching services to the container.
// builder.Services.AddOutputCache();

// Configure Output Caching options.
builder.Services.AddOutputCache(options =>
{
    // options.DefaultExpirationTimeSpan = TimeSpan.FromMinutes(10);
    // options.MaximumBodySize = 64 * 1024; // 64 KB
    // options.SizeLimit = 100 * 1024 * 1024; // 100 MB
    // options.UseCaseSensitivePaths = false; // Case insensitive paths
    options.AddPolicy("Single-Product", builder =>
    {
        builder.SetVaryByRouteValue("productId").Expire(TimeSpan.FromSeconds(10));
        builder.Tag(["products"]);
    });
});

builder.Services.AddMemoryCache(options => options.SizeLimit = 100);

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=products.db"));
var app = builder.Build();

app.UseOutputCache();

app.MapControllers();
app.MapGet("/api/products-mn", async (IProductService productService, int page = 1, int pageSize = 10) =>
    {
        Console.WriteLine("Minimal Endpoint Invoked");
        var response = await productService.GetProductsAsync(page, pageSize);
        return Results.Ok(response);
    }).CacheOutput(options => options.Expire(TimeSpan.FromSeconds(10)).SetVaryByQuery(["page", "pageSize"]));

app.MapGet("/api/products-mn/{productId:int}", async (IProductService productService, int productId) =>
    {
        Console.WriteLine("Minimal Endpoint(Get By Id) Invoked");
        var response = await productService.GetProductByIdAsync(productId);
        return response is null
            ? Results.NotFound($"Product with Id '{productId}' not found")
            : Results.Ok(response);
    }).CacheOutput("Single-Product");
    // .CacheOutput(options => options.SetVaryByRouteValue(["productId"]).Expire(TimeSpan.FromSeconds(10)));
app.Run();