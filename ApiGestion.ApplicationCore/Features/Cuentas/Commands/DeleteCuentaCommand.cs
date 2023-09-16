using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Commands;

public class DeleteCuentaCommand : IRequest
{
    public string NumeroCuenta { get; set; } = null!;
}