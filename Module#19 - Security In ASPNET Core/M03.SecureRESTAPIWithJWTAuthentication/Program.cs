using System.Text;
using M03.SecureRESTAPIWithJWTAuthentication.Permissions;
using M03.SecureRESTAPIWithJWTAuthentication.Services;
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
        ValidateIssuerSigningKey = true,
        ValidIssuer = JwtSettings["Issuer"],
        ValidAudience = JwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(JwtSettings["SecretKey"]!))
    };
});
// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));
// });

// builder.Services.AddAuthorization(options =>
// {
//     // Project Manager Permission
//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));
//     options.AddPolicy(Permission.Project.Read, policy => policy.RequireClaim("permission", Permission.Project.Read));
//     options.AddPolicy(Permission.Project.Update, policy => policy.RequireClaim("permission", Permission.Project.Update));
//     options.AddPolicy(Permission.Project.Delete, policy => policy.RequireClaim("permission", Permission.Project.Delete));
//     options.AddPolicy(Permission.Project.AssignMember, policy => policy.RequireClaim("permission", Permission.Project.AssignMember));
//     options.AddPolicy(Permission.Project.ManageBudget, policy => policy.RequireClaim("permission", Permission.Project.ManageBudget));

//     // Task Manager Permission (demonstrating granularity)
//     options.AddPolicy(Permission.Task.Create, policy => policy.RequireClaim("permission", Permission.Task.Create));
//     options.AddPolicy(Permission.Task.Read, policy => policy.RequireClaim("permission", Permission.Task.Read));
//     options.AddPolicy(Permission.Task.Update, policy => policy.RequireClaim("permission", Permission.Task.Update));
//     options.AddPolicy(Permission.Task.Delete, policy => policy.RequireClaim("permission", Permission.Task.Delete));
//     options.AddPolicy(Permission.Task.AssignUser, policy => policy.RequireClaim("permission", Permission.Task.AssignUser));
//     options.AddPolicy(Permission.Task.UpdateStatus, policy => policy.RequireClaim("permission", Permission.Task.UpdateStatus));
// });

// builder.Services.AddAuthorization(options =>
// {
//     options.AddAllPermissions();
// });

// builder.Services.AddAuthorizationBuilder()
//     .AddPolicy(Permission.Project.Create, policy =>
//         policy.RequireClaim("permission", Permission.Project.Create));


// builder.Services.AddAuthorizationBuilder()
// // builder.Services.AddAuthorization(options =>// {//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));// });// builder.Services.AddAuthorizationBuilder()//     .AddPolicy(Permission.Project.Create, policy =>//         policy.RequireClaim("permission", Permission.Project.Create));
// .AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create))
// // builder.Services.AddAuthorization(options =>// {//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));// });// builder.Services.AddAuthorizationBuilder()//     .AddPolicy(Permission.Project.Create, policy =>//         policy.RequireClaim("permission", Permission.Project.Create));
// .AddPolicy(Permission.Project.Read, policy => policy.RequireClaim("permission", Permission.Project.Read))
// // builder.Services.AddAuthorization(options =>// {//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));// });// builder.Services.AddAuthorizationBuilder()//     .AddPolicy(Permission.Project.Create, policy =>//         policy.RequireClaim("permission", Permission.Project.Create));
// .AddPolicy(Permission.Project.Update, policy => policy.RequireClaim("permission", Permission.Project.Update))
// // builder.Services.AddAuthorization(options =>// {//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));// });// builder.Services.AddAuthorizationBuilder()//     .AddPolicy(Permission.Project.Create, policy =>//         policy.RequireClaim("permission", Permission.Project.Create));
// .AddPolicy(Permission.Project.Delete, policy => policy.RequireClaim("permission", Permission.Project.Delete))
// // builder.Services.AddAuthorization(options =>// {//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));// });// builder.Services.AddAuthorizationBuilder()//     .AddPolicy(Permission.Project.Create, policy =>//         policy.RequireClaim("permission", Permission.Project.Create));
// .AddPolicy(Permission.Project.AssignMember, policy => policy.RequireClaim("permission", Permission.Project.AssignMember))
// // builder.Services.AddAuthorization(options =>// {//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));// });// builder.Services.AddAuthorizationBuilder()//     .AddPolicy(Permission.Project.Create, policy =>//         policy.RequireClaim("permission", Permission.Project.Create));
// .AddPolicy(Permission.Project.ManageBudget, policy => policy.RequireClaim("permission", Permission.Project.ManageBudget))
// // builder.Services.AddAuthorization(options =>// {//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));// });// builder.Services.AddAuthorizationBuilder()//     .AddPolicy(Permission.Project.Create, policy =>//         policy.RequireClaim("permission", Permission.Project.Create));
// .AddPolicy(Permission.Task.Create, policy => policy.RequireClaim("permission", Permission.Task.Create))
// // builder.Services.AddAuthorization(options =>// {//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));// });// builder.Services.AddAuthorizationBuilder()//     .AddPolicy(Permission.Project.Create, policy =>//         policy.RequireClaim("permission", Permission.Project.Create));
// .AddPolicy(Permission.Task.Read, policy => policy.RequireClaim("permission", Permission.Task.Read))
// // builder.Services.AddAuthorization(options =>// {//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));// });// builder.Services.AddAuthorizationBuilder()//     .AddPolicy(Permission.Project.Create, policy =>//         policy.RequireClaim("permission", Permission.Project.Create));
// .AddPolicy(Permission.Task.Update, policy => policy.RequireClaim("permission", Permission.Task.Update))
// // builder.Services.AddAuthorization(options =>// {//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));// });// builder.Services.AddAuthorizationBuilder()//     .AddPolicy(Permission.Project.Create, policy =>//         policy.RequireClaim("permission", Permission.Project.Create));
// .AddPolicy(Permission.Task.Delete, policy => policy.RequireClaim("permission", Permission.Task.Delete))
// // builder.Services.AddAuthorization(options =>// {//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));// });// builder.Services.AddAuthorizationBuilder()//     .AddPolicy(Permission.Project.Create, policy =>//         policy.RequireClaim("permission", Permission.Project.Create));
// .AddPolicy(Permission.Task.AssignUser, policy => policy.RequireClaim("permission", Permission.Task.AssignUser))
// // builder.Services.AddAuthorization(options =>// {//     options.AddPolicy(Permission.Project.Create, policy => policy.RequireClaim("permission", Permission.Project.Create));// });// builder.Services.AddAuthorizationBuilder()//     .AddPolicy(Permission.Project.Create, policy =>//         policy.RequireClaim("permission", Permission.Project.Create));
// .AddPolicy(Permission.Task.UpdateStatus, policy => policy.RequireClaim("permission", Permission.Task.UpdateStatus));


builder.Services.AddAuthorizationBuilder()
    .AddAllPermissions(); // 👈 Extension method تستخدم Reflection لتوليد كل السياسات تلقائيًا


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();