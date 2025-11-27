var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("mycustomeconfig.json",
optional: false,
reloadOnChange: true);
builder.Configuration.AddIniFile("config.INI",
optional: false,
reloadOnChange: true);

var app = builder.Build();

app.MapGet("/{key}", (string key, IConfiguration config) =>
{
    return config[key];
});
app.MapGet("/ini/{key}", (string key, IConfiguration config) =>
{
    return config[key];
});

app.Run(); // 5238