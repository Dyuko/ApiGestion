using ApiGestion.ApplicationCore.Features.Movimientos.Commands;
using ApiGestion.ApplicationCore.Features.Movimientos.Queries;
using ApiGestion.ApplicationCore.Features.Movimientos.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestion.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovimientosController : ControllerBase
{
    private readonly IMediator _mediator;
    public MovimientosController(IMediator mediator) =>
        _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateMovimiento([FromBody] CreateMovimientoCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpGet]
    public Task<List<GetMovimientoQueryResponse>> GetMovimientos() =>
        _mediator.Send(new GetMovimientoQuery());
}