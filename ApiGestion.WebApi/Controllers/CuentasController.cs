using ApiGestion.ApplicationCore.Features.Cuentas.Commands;
using ApiGestion.ApplicationCore.Features.Cuentas.Queries;
using ApiGestion.ApplicationCore.Features.Cuentas.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestion.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CuentasController : ControllerBase
{
    private readonly IMediator _mediator;

    public CuentasController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet]
    public Task<List<GetCuentaQueryResponse>> GetCuentas() =>
        _mediator.Send(new GetCuentasQuery());

    [HttpGet("{NumeroCuenta}")]
    public Task<GetCuentaQueryResponse> GetCuentaByNumero([FromRoute] GetCuentaQuery query) =>
        _mediator.Send(query);

    [HttpGet("Cliente/{IdentificacionCliente}")]
    public Task<List<GetCuentaQueryResponse>> GetCuentasCliente([FromRoute] GetCuentasClienteQuery query) =>
        _mediator.Send(query);

    [HttpPost]
    public async Task<IActionResult> CreateCuenta([FromBody] CreateCuentaCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpDelete("{NumeroCuenta}")]
    public async Task<IActionResult> DeleteCuenta([FromRoute] DeleteCuentaCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status204NoContent);
    }

    [HttpPut("{NumeroCuenta}")]
    public async Task<IActionResult> UpdateCuenta(UpdateCuentaCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status204NoContent);
    }
}