using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Commands;

public class CreateCuentaCommand : IRequest
{
    public string NumeroCuenta { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public decimal SaldoInicial { get; set; }

    public bool Estado { get; set; }

    public string IdentificacionCliente { get; set; } = null!;
}