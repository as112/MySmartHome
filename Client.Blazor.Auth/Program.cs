using Client.Blazor.Auth.Areas.Identity;
using Client.Blazor.Auth.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySmartHome.DAL.Data;
using MySmartHome.DAL.Models;
using MySmartHome.DAL.Repositories;
using MySmartHome.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("UserDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.AllowedUserNameCharacters =
            "������������������������������������������������������������abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;

});
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages().AddNewtonsoftJson(options => 
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<ITokenStorage, TokenInMemoryCache>();

var webApiAddr = builder.Configuration.GetSection("WebApi").Value;
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(webApiAddr + "/api/")
    });
builder.Services.AddHttpClient<IEntityRepository<Lamps>, WebRepository<Lamps>>(client => client.BaseAddress = new Uri(webApiAddr + "/api/Lamps/"));
builder.Services.AddHttpClient<IEntityRepository<Sensors>, WebRepository<Sensors>>(client => client.BaseAddress = new Uri(webApiAddr + "/api/Sensors/"));
builder.Services.AddHttpClient<IEntityRepository<Rooms>, WebRepository<Rooms>>(client => client.BaseAddress = new Uri(webApiAddr + "/api/Rooms/"));

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
