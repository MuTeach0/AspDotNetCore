using System.Collections.Immutable;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/products", () => Results.Ok(new[]{
            "Product #1",
            "Product #2"
        }
    )
);

app.MapGet("/rout-table", (IServiceProvider sp) =>
{
    var endpoints = sp.GetRequiredService<EndpointDataSource>().Endpoints.Select(ep =>
     ep.DisplayName);
    return Results.Ok(endpoints);
});

app.Run();
