using ApiGestion.ApplicationCore.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApiGestion.ApplicationCore;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddDbContext<GestionDbContext>();
        return services;
    }
}
