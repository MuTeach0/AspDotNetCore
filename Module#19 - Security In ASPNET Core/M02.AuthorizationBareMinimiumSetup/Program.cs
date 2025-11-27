using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication()
    .AddCookie(); // AddJwtBearer, AddOpenId, ....
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Supervisor-With-Driver-License-A", policy =>
    {
        policy.RequireClaim("driver-license-class", "A");
        policy.RequireRole("Supervisor");
    });
});
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("login", async (httpContext) =>
{
    List<Claim> claims = [
        new("name","Mahmoud A."),
        new("email","mamhoud@localhost"),
        new("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin"),
        new(ClaimTypes.Role, "Supervisor"),
        new(ClaimTypes.Role, "Moderator"),
        new("driver-license-class", "A"),
        new("sub", Guid.NewGuid().ToString())
    ];

    var identity = new ClaimsIdentity(claims, "Cookies");

    var principal = new ClaimsPrincipal(identity);

    await httpContext.SignInAsync(scheme: "Cookies", principal: principal);
});

app.MapGet("/logout", async (httpContext) => await httpContext.SignOutAsync());

app.MapGet("/user", [Authorize] (HttpContext httpContext) =>
{
    var principal = httpContext.User;

    // if (principal.Identity is { IsAuthenticated: true })
    // {
    var claims = principal.Claims.Select(c => new { c.Type, c.Value });
    return Results.Ok(claims);
    // }
    // return Results.Unauthorized();
});

app.MapGet("/secure", () =>
{
    return Results.Ok("Secure Page");
}).RequireAuthorization();

app.MapGet("/supervisor-only", [Authorize(Roles = "Admin, Supervisor")] () =>
{
    return Results.Ok("Supervisor Page");
});

app.MapGet("/admin-only", () =>
{
    return Results.Ok("Admin Page");
}).RequireAuthorization(a => a.RequireRole("Admin"));

app.MapPost("/drive/bus", () =>
{
    return Results.Ok("Only Class A driver can drive bus");
}).RequireAuthorization("Supervisor-With-Driver-License-A");

app.MapGet("/account/login", () => "Login Page.");
app.Run();
