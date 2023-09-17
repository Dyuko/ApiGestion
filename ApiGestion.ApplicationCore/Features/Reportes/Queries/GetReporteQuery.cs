using ApiGestion.ApplicationCore.Features.Reportes.Responses;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Reportes.Queries
{
    public class GetReporteQuery : IRequest<List<GetReporteQueryResponse>>
    {
        public string IdentificacionCliente { get; set; } = null!;
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
    }
}