using System.Text;
using M04.RefreshingAccessToken.Permissions;
using M04.RefreshingAccessToken.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<JwtTokenProvider>();
builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // "Bearer"
    options.DefaultChallengeScheme = "Bearer"; // JwtBearerDefaults.AuthenticationScheme
}).AddJwtBearer(options =>
{
    var JwtSettings = builder.Configuration.GetSection("JwtSettings");

    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuerSigningKey = true,
        ValidIssuer = JwtSettings["Issuer"],
        ValidAudience = JwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(JwtSettings["SecretKey"]!))
    };
});

builder.Services.AddAuthorizationBuilder()
    .AddAllPermissions(); // 👈 Extension method تستخدم Reflection لتوليد كل السياسات تلقائيًا


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();