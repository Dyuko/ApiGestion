using FluentValidation;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Commands;

public class DeleteCuentaCommand : IRequest
{
    public string NumeroCuenta { get; set; } = null!;
}

public class DeleteCuentaCommandValidator : AbstractValidator<DeleteCuentaCommand>
{
    public DeleteCuentaCommandValidator()
    {
        RuleFor(command => command.NumeroCuenta).NotEmpty().MaximumLength(20);
    }
}