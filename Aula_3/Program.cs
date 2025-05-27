var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();

// Este é um exemplo simples de configuração de uma aplicação ASP.NET Core.