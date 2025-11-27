using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/product-minimal", ([FromHeader(Name = "X-API-Version")] string apiVersion) =>
   Results.Ok($"API Version: {apiVersion}"));
app.MapControllers();
app.Run();
