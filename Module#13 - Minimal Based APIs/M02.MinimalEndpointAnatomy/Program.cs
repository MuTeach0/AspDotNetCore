using System.Threading.Tasks;
using M02.MinimalEndpointAnatomy.Data;
using M02.MinimalEndpointAnatomy.Responses;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductRepository>();

var app = builder.Build();
// Minimal Api Contains
// 1 Map Method
// 2 Route template
// 3 Method handler - Lambda expression or Method refers to HTTP verbs: GET, POST, PUT, DELETE, etc.
// automatic Parameter binding - From route, From services, From query, From body, etc.

// app.MapGet("/api/products", (ProductRepository repository) => // (Lambda expression)
// {
//     // Handles retrieving a list of products
//     return Results.Ok(repository.GetAllProductsPage());
// });

app.MapGet("/api/products", GetAllProducts); // (Method refers to HTTP verbs: GET, POST, PUT, DELETE, etc.)

static async Task<IResult> GetAllProducts(ProductRepository repository)
{
    // Handles retrieving a list of products
    await Task.Delay(100); // Simulate some asynchronous operation
    return Results.Ok(repository.GetAllProductsPage());
}

// app.MapGet("/api/products/{id:guid}", (Guid id, ProductRepository repository) =>
// {
//     // Handles retrieving a single product by its unique identifier
//     var product = repository.GetProductById(id);

//     return product is null ? Results.NotFound() : Results.Ok(ProductResponse.FromModel(product));
// }).WithName("GetProductById");
 
// app.MapGet("/api/products/{id:guid}", (Guid id, ProductRepository repository) => // (Lambda expression)
// {
//     // Handles retrieving a single product by its unique identifier
//     var product = repository.GetProductById(id);

//     return product is null ? Results.NotFound() : Results.Ok(ProductResponse.FromModel(product));
// });

app.MapGet("/api/products/{id:guid}", GetProduct); // (Method refers to HTTP verbs: GET, POST, PUT, DELETE, etc.)

static IResult GetProduct(Guid id, ProductRepository repository)
{
    // Handles retrieving a single product by its unique identifier
    var product = repository.GetProductById(id);

    return product is null ? Results.NotFound() : Results.Ok(ProductResponse.FromModel(product));
}
app.Run();