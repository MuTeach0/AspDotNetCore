var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/weather/city/{cityName}", (string cityName) =>
{
	IWeatherClient weatherClient = new WeatherClient(); // abstraction
	IWeatherService weatherService = new WeatherService(weatherClient); // abstraction
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
	public string GetWeatherInfo(string cityName) => weatherClient.GetWeatherInfo(cityName);
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