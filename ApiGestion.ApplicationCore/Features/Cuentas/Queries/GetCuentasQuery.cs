using ApiGestion.ApplicationCore.Features.Cuentas.Responses;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Queries;

public class GetCuentasQuery : IRequest<List<GetCuentaQueryResponse>>
{
}