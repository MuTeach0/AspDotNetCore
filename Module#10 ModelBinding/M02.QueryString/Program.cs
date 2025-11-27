using M02.QueryString.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.MapGet("/product-minimal", (int page, int pageSize) =>
{
    return Results.Ok($"Showing {pageSize} items of page # {page}");
});

app.MapGet("/product-minimal-1", ([FromQuery(Name = "Page")] int p, [FromQuery(Name = "PageSize")] int ps) =>
{
    return Results.Ok($"Showing {ps} items of page # {p}");
});

app.MapGet("/product-minimal-as-parameters", ([AsParameters] SearchRequest request) =>
{
    return Results.Ok(request);
});

app.MapGet("/product-minimal-array", (Guid[] ids) =>
{
    return Results.Ok(ids);
});

app.MapGet("/Guid", () => Results.Ok(Guid.NewGuid()));

app.MapGet("/date-range-minimal", (DateRangeQuery dateRange) =>
{
    return Results.Ok(dateRange);
});
app.Run();

public class SearchRequest
{
    public string Query { get; set; } = null!;
    public int Page { get; set; }
    public int PageSize { get; set; }
}
