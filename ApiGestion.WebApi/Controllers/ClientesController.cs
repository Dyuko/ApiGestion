using ApiGestion.ApplicationCore.Features.Clientes.Commands;
using ApiGestion.ApplicationCore.Features.Clientes.Queries;
using ApiGestion.ApplicationCore.Features.Clientes.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestion.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ClientesController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet]
    public Task<List<GetClienteQueryResponde>> GetClientes() =>
        _mediator.Send(new GetClientesQuery());

    [HttpGet("{Identificacion}")]
    public Task<GetClienteQueryResponde> GetClienteByIdentificacion([FromRoute] GetClienteQuery query) =>
        _mediator.Send(query);

    [HttpPost]
    public async Task<IActionResult> CreateCliente([FromBody] CreateClienteCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{Identificacion}")]
    public async Task<IActionResult> UpdateCliente(UpdateClienteCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status204NoContent);
    }

    [HttpDelete("{Identificacion}")]
    public async Task<IActionResult> DeleteCliente([FromRoute] DeleteClienteCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status204NoContent);
    }
}
