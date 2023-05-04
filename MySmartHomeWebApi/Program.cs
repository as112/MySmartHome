using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MySmartHome.DAL.Data;
using MySmartHome.DAL.Repositories.Interfaces;
using MySmartHome.DAL.Models;
using MySmartHome.DAL.Repositories;
using MySmartHomeWebApi.Servises;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("MySmartHomeWebApiContext");
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddDbContext<HistoryContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped(typeof(IEntityRepository<>), typeof(DbEntityRepository<>));
builder.Services.AddScoped<IHistoryRepository<HistoryData>, DbHistoryRepository<HistoryData>>();

var userConnectionString = builder.Configuration.GetConnectionString("UserDbConnection");
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseNpgsql(userConnectionString));


builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });
//builder.WebHost.UseUrls(new[] { "http://*:5000" });
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Home API V1");
    c.RoutePrefix = string.Empty;
});

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Lifetime.ApplicationStarted.Register(async () =>
{
    var configuration = app.Services.GetRequiredService<IConfiguration>();
    var logger = app.Services.GetRequiredService<ILogger<HistoryData>>();
    
    try
    {
        await MQTTClient.MqttClientInit(configuration, logger);
        await MQTTClient.Run();
    }
    catch(Exception ex)
    {
        logger.LogError(ex.Message);
    }
    
});

app.Run();


public class AuthOptions
{
    public const string ISSUER = "MySmartHome"; // �������� ������
    public const string AUDIENCE = "MyAuthClient"; // ����������� ������
    const string KEY = "mysupersecret_secretkey!123";   // ���� ��� ��������
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}