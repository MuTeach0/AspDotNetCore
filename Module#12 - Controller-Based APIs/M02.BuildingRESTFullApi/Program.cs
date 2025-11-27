using System.Text.Json.Serialization;
using M02.BuildingRESTFullApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
// مع كل Request يتم اعادة نفس النسخة من ProductRepository
builder.Services.AddSingleton<ProductRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapControllers();

app.Run();