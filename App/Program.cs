using App.Services;
using App.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.Configure<GmailSettings>(builder.Configuration.GetSection(nameof(GmailSettings)));

builder.Services.AddSingleton<IEmailService, GmailService>();


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
