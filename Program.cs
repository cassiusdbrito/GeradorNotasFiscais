using DotNetEnv;
using GeradorNotaFiscal.Data;
using GeradorNotaFiscal.exceptions;
using GeradorNotaFiscal.interfaces.mappers;
using GeradorNotaFiscal.interfaces.repositories;
using GeradorNotaFiscal.interfaces.services;
using GeradorNotaFiscal.mappers;
using GeradorNotaFiscal.repositories;
using GeradorNotaFiscal.services;
using Microsoft.AspNetCore.Mvc;
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

builder.Services.AddDataProtection();

builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .SelectMany(e => e.Value.Errors)
            .Select(e => string.IsNullOrEmpty(e.ErrorMessage)
                ? "Valor inválido"
                : e.ErrorMessage
            );

        var message = string.Join(Environment.NewLine, errors);

        throw new BadRequestException(message);
    };
});


builder.Services.AddSingleton<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddSingleton<IPaymentMapper, PaymentMapper>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddSingleton<IInvoiceMapper, InvoiceMapper>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
