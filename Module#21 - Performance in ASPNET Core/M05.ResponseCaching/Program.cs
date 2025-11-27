using M05.ResponseCaching.Data;
using M05.ResponseCaching.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddResponseCaching();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=products.db"));
var app = builder.Build();

app.MapControllers();
app.UseResponseCaching();
app.MapGet("/api/products-mn", async (IProductService productService, int page = 1, int pageSize = 10) =>
    {
        Console.WriteLine("Minimal Endpoint Invoked");
        var response = await productService.GetProductsAsync(page, pageSize);
        return Results.Ok(response);
    });

app.MapGet("/api/products-mn/{productId:int}", async (IProductService productService, int productId) =>
    {
        Console.WriteLine("Minimal Endpoint(Get By Id) Invoked");
        var response = await productService.GetProductByIdAsync(productId);
        return response is null
            ? Results.NotFound($"Product with Id '{productId}' not found")
            : Results.Ok(response);
    });

app.Run();
