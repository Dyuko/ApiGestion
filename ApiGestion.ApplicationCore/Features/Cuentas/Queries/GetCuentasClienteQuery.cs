using ApiGestion.ApplicationCore.Features.Cuentas.Responses;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Queries;

public class GetCuentasClienteQuery : IRequest<List<GetCuentaQueryResponse>>
{
    public string IdentificacionCliente { get; set; } = null!;
}
