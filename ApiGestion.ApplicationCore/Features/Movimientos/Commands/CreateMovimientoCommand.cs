using MediatR;

namespace ApiGestion.ApplicationCore.Features.Movimientos.Commands;

public class CreateMovimientoCommand : IRequest
{
    public decimal Valor { get; set; }
    public string NumeroCuenta { get; set; } = null!;
}
