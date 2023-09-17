using ApiGestion.ApplicationCore.Features.Reportes.Responses;

namespace ApiGestion.ApplicationCore.Infrastructure.Repositories;
public interface IReporteRepository
{
    public Task<List<GetReporteQueryResponse>> GetReporteCuenta(string identificacionCliente, DateTime FechaDesde, DateTime FechaHasta);
}