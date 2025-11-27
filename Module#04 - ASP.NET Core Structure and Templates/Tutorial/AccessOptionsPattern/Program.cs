using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(AppSettings.Name));
//
builder.Services.AddOptions<AppSettings>().Bind(builder.Configuration.GetSection(AppSettings.Name));

var app = builder.Build();
// singleton snapshot take at startup
app.Map("/ioptions", (IOptions<AppSettings> options) =>
{
    return options.Value;
});

// per scop (fresh per request)
app.Map("/ioptions-snapshot", (IOptionsSnapshot<AppSettings> options) =>
{
    return options.Value;
});

// fresh on change
app.Map("/ioptions-monitor", (IOptionsMonitor<AppSettings> options) =>
{
    return options.CurrentValue;
});
app.MapGet("/", () => "Hello World!");

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