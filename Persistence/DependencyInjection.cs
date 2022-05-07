using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];

        services.AddDbContext<WorkBookDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString!);
        });
        services.AddScoped<IWorkBookDbContext>(provider => provider.GetService<WorkBookDbContext>()!);

        return services;
    }
}