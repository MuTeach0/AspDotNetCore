using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OrderServiceApi.Data;
using OrderServiceApi.Exceptions;
using OrderServiceApi.HealthChecks;
using OrderServiceApi.Repositories;
using OrderServiceApi.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddHealthChecks();

builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddOpenTelemetry()
    .ConfigureResource(res => res.AddService("orderservice"))
    .WithTracing(tracing =>
    {
        tracing.AddAspNetCoreInstrumentation(). // Trace incoming HTTP requests To the asp.net core app
                AddHttpClientInstrumentation(); // Trace outgoing HTTP requests made by HttpClient

        tracing.AddOtlpExporter(); // Export traces to an OTLP collector (OpenTelemetry Protocol)
    }).
    WithMetrics(metrics =>
    {
        metrics.AddAspNetCoreInstrumentation(). // Trace incoming HTTP requests To the asp.net core app
                AddHttpClientInstrumentation(); // Trace outgoing HTTP requests made by HttpClient

        metrics.AddOtlpExporter().   // Export metrics to an OTLP collector (OpenTelemetry Protocol)
            AddPrometheusExporter(); // Export metrics to Prometheus
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

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=app.db");
}).AddHealthChecks().AddCheck<DBHealthCheck>("Database");

builder.Services.AddHttpClient<IOrderService, OrderService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["PaymentService:BaseUrl"]!);
});

var app = builder.Build();

// app.MapHealthChecks("/health");
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";

        var response = new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(entry => new
            {
                name = entry.Key,
                status = entry.Value.Status.ToString(),
                exception = entry.Value.Exception?.Message,
                duration = entry.Value.Duration.ToString()
            })
        };

        await context.Response.WriteAsJsonAsync(response);
    }
});

app.UseExceptionHandler();

app.UseStatusCodePages();

app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.UseSerilogRequestLogging();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.Run();