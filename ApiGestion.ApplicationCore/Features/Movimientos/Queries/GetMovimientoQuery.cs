using ApiGestion.ApplicationCore.Features.Movimientos.Responses;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Movimientos.Queries;

public class GetMovimientoQuery : IRequest<List<GetMovimientoQueryResponse>>
{
}