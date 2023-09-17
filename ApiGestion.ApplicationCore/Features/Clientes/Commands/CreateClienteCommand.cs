using ApiGestion.ApplicationCore.Common.Helpers;
using ApiGestion.ApplicationCore.Domain;
using FluentValidation;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Clientes.Commands;

public class CreateClienteCommand : IRequest
{
    public string Nombre { get; set; } = null!;
    public Genero Genero { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Identificacion { get; set; } = null!;
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string Contrasena { get; set; } = null!;
    public bool Estado { get; set; } = true;
}

public class CreateClienteValidator : AbstractValidator<CreateClienteCommand>
{
    public CreateClienteValidator()
    {
        RuleFor(cliente => cliente.Nombre).NotEmpty().MaximumLength(50);
        RuleFor(cliente => cliente.Genero).IsInEnum();
        RuleFor(cliente => cliente.FechaNacimiento).Must(DateHelpers.BeAValidDate);
        RuleFor(cliente => cliente.Identificacion).NotEmpty().MaximumLength(20);
        RuleFor(cliente => cliente.Direccion).MaximumLength(100);
        RuleFor(cliente => cliente.Telefono).MaximumLength(15);
        RuleFor(cliente => cliente.Contrasena).NotEmpty().MinimumLength(8);
    }
}