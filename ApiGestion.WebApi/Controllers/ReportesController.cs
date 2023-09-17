using ApiGestion.ApplicationCore.Features.Reportes.Queries;
using ApiGestion.ApplicationCore.Features.Reportes.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestion.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportesController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet]
    public Task<List<GetReporteQueryResponse>> GetReporte([FromQuery] GetReporteQuery query) => 
        _mediator.Send(query);
}
