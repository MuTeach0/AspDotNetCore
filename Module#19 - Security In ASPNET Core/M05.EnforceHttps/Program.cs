var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status404NotFound;
});
var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();
