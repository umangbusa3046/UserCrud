using FluentValidation.AspNetCore;

using UserCrud.API;
using Serilog;
using UserCrud.API.Middleware;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(context.Configuration)
        .WriteTo.Console()
        .WriteTo.File(
            "Logs/ApplicationLogs.txt",
            shared: true);
});


builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApiDI(builder.Configuration);

var app = builder.Build();


app.UseSwagger();

app.UseSwaggerUI();

app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
