using Microsoft.EntityFrameworkCore;
using MySmartHomeWebApi.Data;
using MySmartHomeWebApi.Data.Interfaces;
using MySmartHomeWebApi.Models;
using WebApiClients.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
var connectionString = builder.Configuration.GetConnectionString("MySmartHomeWebApiContext");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

var webApiAddr = builder.Configuration.GetSection("WebApi").Value;
builder.Services.AddHttpClient<IEntityRepository<Lamps>, WebRepository<Lamps>>(client => 
    client.BaseAddress = new Uri(webApiAddr + "/api/Lamps/"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
