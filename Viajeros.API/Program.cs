using Viajeros.Data.Context;
using Viajeros.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Viajeros.UnitOfWork;
using Viajeros.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

// Add services to the container.
builder.Services.AddDbContext<ViajerosContext>(options =>
    options.UseSqlServer(config.GetConnectionString("SqlConnection"),
                          b => b.MigrationsAssembly("Viajeros.API")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<VideoService>();
builder.Services.AddScoped<ImageService>();

builder.Services.AddSingleton(ServiceProvider => new TokenService(jwtSettings));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidAudience = config["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!))
    };
});

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin(); // Permitir solicitudes desde cualquier origen
    options.AllowAnyMethod(); // Permitir cualquier método HTTP (GET, POST, etc.)
    options.AllowAnyHeader(); // Permitir cualquier encabezado en la solicitud
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
