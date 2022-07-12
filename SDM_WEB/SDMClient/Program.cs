using Microsoft.AspNetCore.Server.Kestrel.Core;
using Rotativa.AspNetCore;
using SDMClient.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddTransient<APICALL>();
RotativaConfiguration.ReferenceEquals(builder.Services[0], builder.Services[1]);
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
// If using Kestrel:
builder.Services.Configure<KestrelServerOptions>(options =>
{
options.AllowSynchronousIO = true;
});

// If using IIS:
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

string _pdf = config.GetSection("pdfpath").Value;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseDeveloperExceptionPage();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
RotativaConfiguration.Setup(_pdf);
RotativaConfiguration.Setup(_pdf);
app.Run();
