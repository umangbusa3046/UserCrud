using FluentValidation.AspNetCore;
using UserCrud.API;
using Serilog;
using UserCrud.API.Middleware;

Log.Logger =
    new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File(
            "Logs/log-.txt",
            rollingInterval:
                RollingInterval.Day)
        .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Log.Logger =
    new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File(
            "Logs/log-.txt",
            rollingInterval:
                RollingInterval.Day)
        .CreateLogger();


builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();
builder.Services.AddAppDI(builder.Configuration);

var app = builder.Build();


app.UseSwagger();

app.UseSwaggerUI();

app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
