using DotNetEnv;
using GeradorNotaFiscal.Data;
using Microsoft.EntityFrameworkCore;

Env.Load();

var server = Environment.GetEnvironmentVariable("DATABASESERVER");
var user = Environment.GetEnvironmentVariable("DATABASEUSER");
var password = Environment.GetEnvironmentVariable("DATABASEPASSWORD");
var database = Environment.GetEnvironmentVariable("DATABASENAME");
var port = Environment.GetEnvironmentVariable("PORT");

var connectionString =
    $"Server={server};Port={port};Database={database};User={user};Password={password};";


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    )
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
