using ApiGestion.ApplicationCore.Features.Cuentas.Responses;
using FluentValidation;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Queries;

public class GetCuentasClienteQuery : IRequest<List<GetCuentaQueryResponse>>
{
    public string IdentificacionCliente { get; set; } = null!;
}

public class GetCuentasClienteQueryValidator : AbstractValidator<GetCuentasClienteQuery>
{
    public GetCuentasClienteQueryValidator() => 
        RuleFor(query => query.IdentificacionCliente)
            .NotEmpty()
            .MaximumLength(20);
}