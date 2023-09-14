using ApiGestion.ApplicationCore.Features.Clientes.Queries;
using ApiGestion.ApplicationCore.Features.Clientes.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestion.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ClientesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Identificacion}")]
    public Task<GetClienteQueryResponde> GetClienteByIdentificacion([FromRoute] GetClienteQuery query) =>
        _mediator.Send(query);
}
