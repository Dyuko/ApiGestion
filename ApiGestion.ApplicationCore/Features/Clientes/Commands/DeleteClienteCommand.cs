using MediatR;

namespace ApiGestion.ApplicationCore.Features.Clientes.Commands;

public class DeleteClienteCommand : IRequest
{
    public string Identificacion { get; set; } = null!;
}
