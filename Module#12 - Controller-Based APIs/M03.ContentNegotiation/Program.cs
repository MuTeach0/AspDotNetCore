using System.Text.Json.Serialization;
using M03.ContentNegotiation.Data;
using M03.ContentNegotiation.Formatters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true; // لإرجاع 406 Not Acceptable إذا لم يكن هناك تنسيق مدعوم
    options.OutputFormatters.Add(new PlainTextTableOutputFormatter());
}).AddXmlSerializerFormatters();
// مع كل Request يتم اعادة نفس النسخة من ProductRepository
builder.Services.AddSingleton<ProductRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();