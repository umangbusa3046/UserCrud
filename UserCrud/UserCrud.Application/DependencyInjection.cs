using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using UserCrud.Application.Interfaces;
using UserCrud.Application.Services;
using UserCrud.Domain.Interfaces;

namespace UserCrud.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDI(
        this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        services.AddValidatorsFromAssembly(
            typeof(DependencyInjection).Assembly);

        return services;
    }
}