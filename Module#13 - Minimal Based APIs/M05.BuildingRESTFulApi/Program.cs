using System.Text.Json.Serialization;
using M05.BuildingRESTFulApi.Data;
using M05.BuildingRESTFulApi.Endpoints;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddSingleton<ProductRepository>();

var app = builder.Build();

app.MapProductEndpoints();

app.Run();