using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UserCrud.Domain.Interfaces;
using UserCrud.Infrastructure.Options;
using UserCrud.Infrastructure.Persistence;
using UserCrud.Infrastructure.Repositories;

namespace UserCrud.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDI(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(
            configuration.GetSection(DatabaseOptions.SectionName));

        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            var dbOptions =
                sp.GetRequiredService<IOptions<DatabaseOptions>>()
                  .Value;

            options.UseSqlServer(
                dbOptions.ConnectionString);
        });

        services.AddScoped<IUserRepository,UserRepository>();

        return services;
    }
}