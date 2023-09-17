using ApiGestion.ApplicationCore.Features.Reportes.Responses;
using ApiGestion.ApplicationCore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ApiGestion.ApplicationCore.Infrastructure.Repositories;
public class ReporteRepository : IReporteRepository
{
    private readonly GestionDbContext _context;

    public ReporteRepository(GestionDbContext context) => _context = context;

    public async Task<List<GetReporteQueryResponse>> GetReporteCuenta(string identificacionCliente, DateTime FechaDesde, DateTime FechaHasta)
    {
        List<GetReporteQueryResponse> cuentasConSaldoYSumaMovimientos = await _context.Clientes
            .Where(c => c.Persona.Identificacion.Equals(identificacionCliente))
            .SelectMany(c => c.Cuenta)
            .SelectMany(c => c.Movimientos)
            .Where(m => m.Fecha.Date >= FechaDesde.Date && m.Fecha.Date <= FechaHasta.Date)
            .GroupBy(m => new { m.Fecha.Date, m.Cuenta.NumeroCuenta })
            .Select(group => new GetReporteQueryResponse
            {
                Fecha = group.Max(m => m.Fecha).Date,
                NombreCliente = group.First().Cuenta.Cliente.Persona.Nombre,
                NumeroCuenta = group.Key.NumeroCuenta,
                TipoCuenta = group.First().Cuenta.Tipo,
                EstadoCuenta = group.First().Cuenta.Estado,
                SaldoInicial = group.First().Cuenta.SaldoInicial,
                SaldoDisponible = group.First().Cuenta.SaldoDisponible,
                SumaMovimientos = group.Sum(g => g.Valor)
            })
            .ToListAsync();

        return cuentasConSaldoYSumaMovimientos;
    }
}