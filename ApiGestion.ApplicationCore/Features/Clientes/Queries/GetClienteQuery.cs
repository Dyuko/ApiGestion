using ApiGestion.ApplicationCore.Features.Clientes.Responses;
using FluentValidation;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Clientes.Queries;

public class GetClienteQuery : IRequest<GetClienteQueryResponde>
{
    public string Identificacion { get; set; } = null!;
}

public class GetClienteQueryValidator : AbstractValidator<GetClienteQuery>
{
    public GetClienteQueryValidator() => RuleFor(query => query.Identificacion).NotEmpty();
}