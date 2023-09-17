using ApiGestion.ApplicationCore.Features.Cuentas.Responses;
using FluentValidation;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Queries;

public class GetCuentaQuery : IRequest<GetCuentaQueryResponse>
{
    public string NumeroCuenta { get; set; } = null!;
}

public class GetCuentaQueryValidator : AbstractValidator<GetCuentaQuery>
{
    public GetCuentaQueryValidator() => RuleFor(query => query.NumeroCuenta).NotEmpty().MaximumLength(20);
}