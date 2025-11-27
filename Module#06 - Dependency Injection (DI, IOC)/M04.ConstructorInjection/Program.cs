using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddTransient<IWeatherClient, WeatherClient>();

builder.Services.AddTransient<IWeatherService, WeatherService>();

var app = builder.Build();

app.MapGet("/weather/city/{cityName}",
(string cityName, [FromServices] IWeatherService weatherService) =>
{
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