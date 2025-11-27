var builder = WebApplication.CreateBuilder(args);
// DI(Ioc Container)
// Service Registration
builder.Services.AddTransient<IWeatherClient, WeatherClient>();
builder.Services.AddTransient<IWeatherService, WeatherService>();
var app = builder.Build();
// Pipeline
app.MapGet("/weather/city/{cityName}", (string cityName, IWeatherService weatherService) =>
{
	// IWeatherClient weatherClient = new WeatherClient(); // abstraction
	// IWeatherService weatherService = new WeatherService(weatherClient); // abstraction

	string? weatherInfo = weatherService.GetWeatherInfo(cityName);
	return Results.Ok(weatherInfo);
});

app.Run();

interface IWeatherService
{
	string GetWeatherInfo(string cityName);
}

class WeatherService(IWeatherClient weatherClient) : IWeatherService
{
	public string GetWeatherInfo(string cityName) => weatherClient.GetWeatherInfo(cityName); // InversionOfControlPrinciple
}

interface IWeatherClient
{
	string GetWeatherInfo(string cityName);
}

class WeatherClient : IWeatherClient
{
	public string GetWeatherInfo(string cityName)
	{
		return $"Weather for {cityName} is {Random.Shared.Next(-10, 40)} C.";
	}
}