using System.Data;
using Dapper;
using M01.EFCoreCodeFirst.Endpoints;
using M02.Dapper.Data;
using M02.Dapper.Data.Handlers;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProductRepository>();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddScoped<IDbConnection>(_ =>
    new SqliteConnection("Data Source=app.db"));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbConnection = scope.ServiceProvider.GetRequiredService<IDbConnection>();
DatabaseInitializer.Initialize(dbConnection);
SqlMapper.AddTypeHandler(new GuidHandler());
app.MapProductEndpoints();

app.Run();
