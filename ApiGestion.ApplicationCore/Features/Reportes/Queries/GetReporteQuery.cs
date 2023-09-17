using ApiGestion.ApplicationCore.Common.Helpers;
using ApiGestion.ApplicationCore.Features.Reportes.Responses;
using FluentValidation;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Reportes.Queries;

public class GetReporteQuery : IRequest<List<GetReporteQueryResponse>>
{
    public string IdentificacionCliente { get; set; } = null!;
    public DateTime FechaDesde { get; set; }
    public DateTime FechaHasta { get; set; }
}

public class GetReporteQueryValidator : AbstractValidator<GetReporteQuery>
{
    public GetReporteQueryValidator()
    {
        RuleFor(query => query.IdentificacionCliente)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(query => query.FechaDesde)
            .NotNull()
            .Must(DateHelpers.BeAValidDate)
            .LessThanOrEqualTo(query => query.FechaHasta);

        RuleFor(query => query.FechaHasta)
            .NotNull()
            .Must(DateHelpers.BeAValidDate)
            .GreaterThanOrEqualTo(query => query.FechaDesde);
    }
}