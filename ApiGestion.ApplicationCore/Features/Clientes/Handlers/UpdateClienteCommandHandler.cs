using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Features.Clientes.Commands;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Clientes.Handlers;

public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task Handle(UpdateClienteCommand command, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.GetClienteByIdentificacion(command.Identificacion, cancellationToken)
                    ?? throw new NotFoundException();

        cliente.Persona.Nombre = command.Nombre;
        cliente.Persona.Genero = command.Genero;
        cliente.Persona.FechaNacimiento = command.FechaNacimiento;
        cliente.Persona.Direccion = command.Direccion;
        cliente.Persona.Telefono = command.Telefono;
        cliente.Contrasena = command.Contrasena;
        cliente.Estado = command.Estado;

        await _clienteRepository.UpdateClienteAsync(cliente, cancellationToken);
    }
}