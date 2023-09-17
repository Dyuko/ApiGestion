using ApiGestion.ApplicationCore.Common.Helpers;
using ApiGestion.ApplicationCore.Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestion.ApplicationCore.Features.Clientes.Commands;

public class UpdateClienteCommand : IRequest
{
    [FromRoute]
    public string Identificacion { get; set; } = null!;
    [FromBody]
    public UpdateClienteCommandBody Body { get; set; } = null!;
}

public class UpdateClienteCommandBody
{
    public string Nombre { get; set; } = null!;
    public Genero Genero { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string Contrasena { get; set; } = null!;
    public bool? Estado { get; set; } = null!;
}

public class UpdateClienteCommandBodyValidator : AbstractValidator<UpdateClienteCommandBody>
{
    public UpdateClienteCommandBodyValidator()
    {
        RuleFor(body => body.Nombre).NotEmpty().MaximumLength(50);
        RuleFor(body => body.Genero).IsInEnum();
        RuleFor(body => body.FechaNacimiento).NotNull().Must(DateHelpers.BeAValidDate);
        RuleFor(body => body.Direccion).MaximumLength(100);
        RuleFor(body => body.Telefono).MaximumLength(15);
        RuleFor(body => body.Contrasena).NotEmpty().MinimumLength(8);
        RuleFor(body => body.Estado).NotEmpty();
    }
}

public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
{
    public UpdateClienteCommandValidator()
    {
        RuleFor(command => command.Identificacion).NotEmpty().MaximumLength(20);
        RuleFor(command => command.Body).SetValidator(new UpdateClienteCommandBodyValidator());
    }
}