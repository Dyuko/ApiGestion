using FluentValidation;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Clientes.Commands;

public class DeleteClienteCommand : IRequest
{
    public string Identificacion { get; set; } = null!;
}

public class DeleteClienteValidator : AbstractValidator<DeleteClienteCommand>
{
    public DeleteClienteValidator() => RuleFor(cliente => cliente.Identificacion).NotEmpty().MaximumLength(20);
}
