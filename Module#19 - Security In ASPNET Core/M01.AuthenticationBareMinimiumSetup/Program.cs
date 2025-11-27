using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddAuthentication("Cookies")
// .AddCookie();

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = "Cookies";
// })
// .AddCookie();

// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
// .AddCookie();

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
// })
// .AddCookie();

builder.Services.AddAuthentication()
    .AddCookie(); // AddJwtBearer, AddOpenId, ....

var app = builder.Build();

app.UseAuthentication();

app.MapGet("login", async (httpContext) =>
{
    List<Claim> claims = [
        new("name","Mahmoud A."),
        new("email","mamhoud@localhost"),
        new("sub", Guid.NewGuid().ToString())
    ];

    var identity = new ClaimsIdentity(claims, "Cookies");

    var principal = new ClaimsPrincipal(identity);

    await httpContext.SignInAsync(scheme: "Cookies", principal: principal);
});

app.MapGet("/logout", async (httpContext) => await httpContext.SignOutAsync());

app.MapGet("/user", (HttpContext httpContext) =>
{
    var principal = httpContext.User;

    if (principal.Identity is { IsAuthenticated: true })
    {
        var claims = principal.Claims.Select(c => new { c.Type, c.Value });
        return Results.Ok(claims);
    }
    return Results.Unauthorized();
});

app.Run();
