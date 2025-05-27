using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseDeveloperExceptionPage();


app.MapDefaultControllerRoute();

app.Run();
