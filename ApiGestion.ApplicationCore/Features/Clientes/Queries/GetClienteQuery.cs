using ApiGestion.ApplicationCore.Features.Clientes.Responses;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Clientes.Queries;

public class GetClienteQuery : IRequest<GetClienteQueryResponde>
{
    public string Identificacion { get; set; } = null!;
}