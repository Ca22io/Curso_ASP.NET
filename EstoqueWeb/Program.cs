using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var Configuration = builder.Configuration;

builder.Services.AddDbContext<EstoqueWeb.Models.EstoqueWebContext>( options => options.UseSqlite(Configuration.GetConnectionString("EstoqueWebContext")));

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
