using ApiGestion.ApplicationCore.Features.Clientes.Responses;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Clientes.Queries;

public class GetClientesQuery : IRequest<List<GetClienteQueryResponde>>
{
}
