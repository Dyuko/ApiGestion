using ApiGestion.ApplicationCore.Features.Reportes.Queries;
using ApiGestion.ApplicationCore.Features.Reportes.Responses;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Reportes.Handlers;
public class GetReporteQueryHandler : IRequestHandler<GetReporteQuery, List<GetReporteQueryResponse>>
{
    private readonly IReporteRepository _reporteRepository;

    public GetReporteQueryHandler(IReporteRepository reporteRepository) => _reporteRepository = reporteRepository;

    public async Task<List<GetReporteQueryResponse>> Handle(GetReporteQuery request, CancellationToken cancellationToken) => 
        await _reporteRepository.GetReporteCuenta(request.IdentificacionCliente, request.FechaDesde, request.FechaHasta);
}
