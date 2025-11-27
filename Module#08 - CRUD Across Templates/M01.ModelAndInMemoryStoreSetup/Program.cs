using M01.ModelAndInMemoryStoreSetup.Models;
using M01.ModelAndInMemoryStoreSetup.Store;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ProductStore>();

var app = builder.Build();

app.Run();
