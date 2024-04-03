using Viajeros.Data.Context;
using Viajeros.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<CommentService>();
//builder.Services.AddScoped<NoticeService>();
//builder.Services.AddScoped<UserService>();
var app = builder.Build();


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
