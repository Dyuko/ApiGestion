using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Commands;

public class UpdateCuentaCommand : IRequest
{
    [FromRoute]
    public string NumeroCuenta { get; set; } = null!;
    [FromBody]
    public UpdateCuentaCommandBody Body { get; set; } = null!;
}

public class UpdateCuentaCommandBody
{
    public string Tipo { get; set; } = null!;
    public decimal SaldoInicial { get; set; }
    public decimal SaldoDisponible { get; set; }
    public bool Estado { get; set; }
    public string IdentificacionCliente { get; set; } = null!;
}

public class UpdateCuentaCommandValidator : AbstractValidator<UpdateCuentaCommand>
{
    public UpdateCuentaCommandValidator()
    {
        RuleFor(command => command.NumeroCuenta).NotEmpty().MaximumLength(20);
        RuleFor(command => command.Body).SetValidator(new UpdateCuentaCommandBodyValidator());
    }
}

public class UpdateCuentaCommandBodyValidator : AbstractValidator<UpdateCuentaCommandBody>
{
    public UpdateCuentaCommandBodyValidator()
    {
        RuleFor(body => body.Tipo).NotEmpty();
        RuleFor(body => body.SaldoInicial).GreaterThanOrEqualTo(0);
        RuleFor(body => body.SaldoDisponible).GreaterThanOrEqualTo(0);
        RuleFor(body => body.IdentificacionCliente).NotEmpty().MaximumLength(20);
    }
}