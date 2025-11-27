var builder = WebApplication.CreateBuilder(args);
// ← DI Container goes here (Configuring Dependency)

var app = builder.Build();
// ← Middleware setup goes here
app.Run();
