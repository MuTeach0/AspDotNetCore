using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/product-minimal", ([FromForm] string name, [FromForm] decimal price) =>
     Results.Ok(new { name, price })).DisableAntiforgery();

app.MapPost("/upload-minimal", async (IFormFile file) =>
{
     if (file is null || file.Length == 0)
          return Results.BadRequest("No file uploaded.");

     // Process the file (e.g., save it to a location)
     // For demonstration, we'll just return a success message.
     var uploads = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
     Directory.CreateDirectory(uploads);

     var path = Path.Combine(uploads, file.FileName);

     using var stream = new FileStream(path, FileMode.Create);
     await file.CopyToAsync(stream);

     return Results.Ok("File uploaded successfully.");

}).DisableAntiforgery();
app.MapControllers();
app.Run();
