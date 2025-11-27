using BackgroundAndHosted.TraditionalTimer.BackgroundJobs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<BlobStorageCleanupBackgroundService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();