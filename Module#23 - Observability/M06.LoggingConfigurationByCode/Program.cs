using M06.LoggingConfigurationCode.Services;
using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.SetMinimumLevel(LogLevel.Error);

builder.Logging.AddFilter("Microsoft", LogLevel.Warning);
builder.Logging.AddFilter("Microsoft.Hosting.Lifetime", LogLevel.Information);
builder.Logging.AddFilter<ConsoleLoggerProvider>((category, level) =>
{
    if (category is not null && category.StartsWith("Microsoft"))
        return level >= LogLevel.Information;

    if(category is not null && category.StartsWith("M06.LoggingConfigurationByCode.Services"))
        return level >= LogLevel.Trace;

    return level >= LogLevel.Error;
});

builder.Services.AddControllers();

builder.Services.AddScoped<OrderService>();

var app = builder.Build();

app.MapControllers();

app.Run();