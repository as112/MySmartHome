using Client.Blazor.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MySmartHomeWebApi.Data.Interfaces;
using MySmartHomeWebApi.Data;
using WebApiClients.Repositories;
using MySmartHomeWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient(typeof(IEntityRepository<>), typeof(WebRepository<>));
builder.Services.AddSingleton<WeatherForecastService>();
var webApiAddr = builder.Configuration.GetSection("WebApi").Value;
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(webApiAddr + "/api/")
    });
builder.Services.AddHttpClient<IEntityRepository<Lamps>, WebRepository<Lamps>>(client =>
{
    var token = Token.tokens["user"];
    client.BaseAddress = new Uri(webApiAddr + "/api/Lamps/");
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers
                .AuthenticationHeaderValue("Bearer", token);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
