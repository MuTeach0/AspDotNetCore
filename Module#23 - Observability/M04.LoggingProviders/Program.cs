using M04.LoggingProviders.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddControllers();

builder.Services.AddScoped<OrderService>();

var app = builder.Build();

app.MapControllers();

app.Run();