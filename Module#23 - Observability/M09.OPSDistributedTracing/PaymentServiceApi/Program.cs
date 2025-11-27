using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using PaymentServiceApi.Data;
using PaymentServiceApi.Exceptions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddOpenTelemetry()
    .ConfigureResource(res => res.AddService("paymentservice"))
    .WithTracing(tracing =>
    {
        tracing.AddAspNetCoreInstrumentation(). // Trace incoming HTTP requests To the asp.net core app
                AddHttpClientInstrumentation(); // Trace outgoing HTTP requests made by HttpClient

        tracing.AddOtlpExporter(); // Export traces to an OTLP collector (OpenTelemetry Protocol)
    });


builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = (context) =>
    {
        context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
        context.ProblemDetails.Extensions.Add("requestId", context.HttpContext.TraceIdentifier);
    };
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source = app.db");
});


var app = builder.Build();

app.UseExceptionHandler();

app.UseStatusCodePages();

app.UseSerilogRequestLogging();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.Run();