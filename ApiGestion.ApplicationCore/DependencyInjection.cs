using ApiGestion.ApplicationCore.Infrastructure.Persistence;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApiGestion.ApplicationCore;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddDbContext<GestionDbContext>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<ICuentaRepository, CuentaRepository>();
        services.AddScoped<IMovimientoRepository, MovimientoRepository>();
        services.AddScoped<IReporteRepository, ReporteRepository>();
        return services;
    }
}
