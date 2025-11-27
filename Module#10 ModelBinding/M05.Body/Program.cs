using M05.Body.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddXmlSerializerFormatters();

var app = builder.Build();

app.MapControllers();

app.MapPost("/product-minimal", (ProductRequest product) =>
{
    return Results.Ok(product);
});

app.Run();