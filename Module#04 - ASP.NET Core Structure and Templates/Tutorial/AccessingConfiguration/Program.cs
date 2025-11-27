var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/get-value-by-Key", (IConfiguration config) =>
{
    return config["ServiceName"];
});

app.MapGet("/get-value-by-Path", (IConfiguration config) =>
{
    return config["ConnectionStrings:DefaultConnection"];
});

app.MapGet("/get-connection-string", (IConfiguration config) =>
{
    return config.GetConnectionString("DefaultConnection");
});

app.MapGet("/get-value", (IConfiguration config) =>
{
    return config.GetValue<string>("ServiceName");
});

app.MapGet("/get", (IConfiguration config) =>
{
    var appSettings = config.GetSection(AppSettings.Name).Get<AppSettings>();
    return appSettings;
});

app.MapGet("/bind", (IConfiguration config) =>
{
    var appSettings = new AppSettings();

    config.GetSection(AppSettings.Name).Bind(appSettings);
    return appSettings;
});
app.Run();

public class AppSettings
{
    public const string Name = "AppSettings";
    public TimeSpan OpenAt { get; set; }
    public TimeSpan CloseAt { get; set; }
    public TimeSpan DaysOpen { get; set; }
    public bool EnableOnlineBooking { get; set; }
    public int MaxDailyAppointment { get; set; }
}