using M05.EndpointFilters.Filters;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/api/products", () =>
// {
//     return new[] { "Keyboard: [$52.99]", "Mouse: [$34.99]" };
// }).AddEndpointFilter<EnvelopeResultFilter>() // Endpoint level Filter Registration
// .AddEndpointFilter<TrackActionTimeEndpointFilter>(); // Endpoint level Filter Registration

// var globalGroup = app.MapGroup("").AddEndpointFilter<EnvelopeResultFilter>() // Global Filter Registration
// .AddEndpointFilter<TrackActionTimeEndpointFilter>(); // Global Filter Registration

// globalGroup.MapGet("/api/products", () =>
// {
//     return new[] { "Keyboard: [$52.99]", "Mouse: [$34.99]" };
// });

// globalGroup.MapGet("/api/customers", () =>
// {
//     return new[] { "Ahmed: [HR]", "Maisa: [Finance]" };
// });

var productGroup = app.MapGroup("/api/products")
    .AddEndpointFilter<EnvelopeResultFilter>() // Rout Group Level Filter Registration
    .AddEndpointFilter<TrackActionTimeEndpointFilter>(); // Rout Group Level Filter Registration

var customerGroup = app.MapGroup("/api/customers")
    .AddEndpointFilter<EnvelopeResultFilter>(); // Rout Group Level Filter Registration

productGroup.MapGet("", () =>
{
    return new[] { "Keyboard: [$52.99]", "Mouse: [$34.99]" };
});

customerGroup.MapGet("", () =>
{
    return new[] { "Ahmed: [HR]", "Maisa: [Finance]" };
});
app.Run();
