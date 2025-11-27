using System.Threading.RateLimiting;
using M06.RateLimiting.Data;
using M06.RateLimiting.Services;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRateLimiter(options =>
{
    // Fixed Window Limiter
    options.AddFixedWindowLimiter("DefaultPolicy", config => // Policy name is "Fixed"
    {
        config.Window = TimeSpan.FromMinutes(1); // 1 minute window
        config.PermitLimit = 100; // 100 requests per window
        config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; // Process oldest requests first
        config.QueueLimit = 10; // Queue up to 10 requests
    });

    // Sliding Window Limiter
    options.AddSlidingWindowLimiter("SlidingPolicy", config =>
    {
        config.Window = TimeSpan.FromMinutes(1); // 1 minute window
        config.PermitLimit = 100; // 100 requests per window
        config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; // Process oldest requests first
        config.QueueLimit = 10; // Queue up to 10 requests
        config.SegmentsPerWindow = 6; // Divide window into 6 segments
        config.AutoReplenishment = true; // Automatically replenish tokens
    });

    // Concurrency Limiter
    options.AddConcurrencyLimiter("ConcurrencyPolicy", config =>
    {
        config.PermitLimit = 50; // Allow up to 50 concurrent requests
        config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; // Process oldest requests first
        config.QueueLimit = 100; // Queue up to 100 requests
    });

    // ApiPolicy - Rate limit based on authenticated user
    options.AddPolicy("ApiUserPolicy", context =>
    RateLimitPartition.GetFixedWindowLimiter(
        partitionKey: context.User.Identity?.Name ?? "anonymous", // Use username or "anonymous" if not authenticated
        factory: _ => new FixedWindowRateLimiterOptions // Fixed window limiter
        {
            Window = TimeSpan.FromMinutes(1), // 1 minute window
            PermitLimit = 1000, // 1000 requests per window
            AutoReplenishment = true, // Automatically replenish tokens
        }));

    // IpPolicy - Rate limit based on client IP address
    options.AddPolicy("IpPolicy", context =>
        RateLimitPartition.GetSlidingWindowLimiter(
            partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "unknown", // Use client IP address or "unknown" if not available
            factory: _ => new SlidingWindowRateLimiterOptions // Sliding window limiter
            {
                Window = TimeSpan.FromMinutes(1), // 1 minute window
                PermitLimit = 1000, // 1000 requests per window
                SegmentsPerWindow = 6, // Divide window into 6 segments
                AutoReplenishment = true, // Automatically replenish tokens,
            }));
});
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=app.db"));
var app = builder.Build();
app.UseRateLimiter(); // Enable rate limiting middleware

app.MapControllers(); // Map controller routes

app.MapGet("/api/products-mn", async (IProductService productService, int page = 1, int pageSize = 10) =>
    {
        Console.WriteLine("Minimal Endpoint Invoked");
        var response = await productService.GetProductsAsync(page, pageSize);
        return Results.Ok(response);
    }).RequireRateLimiting("DefaultPolicy"); // Apply rate limiting policy to this endpoint

app.MapGet("/api/products-mn/{productId:int}", async (IProductService productService, int productId) =>
    {
        Console.WriteLine("Minimal Endpoint(Get By Id) Invoked");
        var response = await productService.GetProductByIdAsync(productId);
        return response is null
            ? Results.NotFound($"Product with Id '{productId}' not found")
            : Results.Ok(response);
    });
app.Run();
