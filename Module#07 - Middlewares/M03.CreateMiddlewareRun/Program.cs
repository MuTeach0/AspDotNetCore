var builder = WebApplication.CreateBuilder(args);
// ← DI Container goes here (Configuring Dependency)

var app = builder.Build();

// ← Middleware setup goes here
// Like Run middleware
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Like Run middleware \n");
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("This is san end of pipeline (terminal middleware)");
});

app.Run();
