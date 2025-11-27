using M03.MinimalAPIResponseHandling.Data;
using M03.MinimalAPIResponseHandling.Models;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductRepository>();

var app = builder.Build();
app.MapGet("/text" , () => "Hello, World!"); // Plain text response

app.MapGet("/json", () => new { Message = "Hello, World!" }); // JSON response

app.MapGet("/api/products-mr-ir/{id:guid}",GetProductIResult);

static IResult GetProductIResult (Guid id, ProductRepository repository)  // Using Results<T>
{
    var product = repository.GetProductById(id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
}

app.MapGet("/api/products-le-ir/{id:guid}", (Guid id, ProductRepository repository) => // Using Results<T>
{
    var product = repository.GetProductById(id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

app.MapGet("/api/products-mr-tr/{id:guid}",GetProductTypedResults);

static Results<Ok<Product>, NotFound> GetProductTypedResults(Guid id, ProductRepository repository) // Using Results<T>
{
    var product = repository.GetProductById(id);
    return product is not null ? TypedResults.Ok(product) : TypedResults.NotFound();
}

app.MapGet("/api/products-le-tr/{id:guid}",
Results<Ok<Product>, NotFound> (Guid id, ProductRepository repository) => // Using Results<T>
{
    var product = repository.GetProductById(id);
    return product is not null ? TypedResults.Ok(product) : TypedResults.NotFound();
});

app.Run();