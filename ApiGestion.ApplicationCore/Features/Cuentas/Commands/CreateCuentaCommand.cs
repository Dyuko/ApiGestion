using FluentValidation;
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

public class CreateCuentaCommandValidator : AbstractValidator<CreateCuentaCommand>
{
    public CreateCuentaCommandValidator()
    {
        RuleFor(command => command.NumeroCuenta).NotEmpty().MaximumLength(20);
        RuleFor(command => command.Tipo).NotEmpty().MaximumLength(50);
        RuleFor(command => command.SaldoInicial).GreaterThanOrEqualTo(0);
        RuleFor(command => command.IdentificacionCliente).NotEmpty().MaximumLength(20);
    }
}