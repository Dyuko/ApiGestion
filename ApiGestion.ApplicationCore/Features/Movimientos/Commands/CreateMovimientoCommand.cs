using FluentValidation;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Movimientos.Commands;

public class CreateMovimientoCommand : IRequest
{
    public decimal Valor { get; set; }
    public string NumeroCuenta { get; set; } = null!;
}

public class CreateMovimientoCommandValidator : AbstractValidator<CreateMovimientoCommand>
{
    public CreateMovimientoCommandValidator()
    {
        RuleFor(command => command.Valor).NotEqual(decimal.Zero);
        RuleFor(command => command.NumeroCuenta).NotEmpty().MaximumLength(20);
    }
}