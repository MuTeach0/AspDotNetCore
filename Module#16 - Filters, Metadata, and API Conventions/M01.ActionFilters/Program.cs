using M01.ActionFilters.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    // 1- Global Filter Registration The Filter Work All Action in All Controller
    // options.Filters.Add<TrackActionTimeFilter>();
});

var app = builder.Build();

app.MapControllers();

app.Run();