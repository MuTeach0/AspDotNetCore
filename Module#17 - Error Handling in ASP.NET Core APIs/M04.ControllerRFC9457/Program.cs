
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// RFC 9457
builder.Services.AddProblemDetails();
var app = builder.Build();

// RFC 9457
app.UseExceptionHandler();
app.UseStatusCodePages();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapControllers();
app.Run();
