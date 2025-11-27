var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<DbInitializer>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var sp = scope.ServiceProvider;
    var initialize = sp.GetRequiredService<DbInitializer>();
    initialize.Initialize();

}
app.MapGet("/pay/{amount}", () => "");

app.Run();

public class DbInitializer(ILogger<DbInitializer> logger)
{
    public void Initialize()
    {
        // logic for seeding 1000 items
        logger.LogInformation("1000 items were seeded successfully");
    }
}