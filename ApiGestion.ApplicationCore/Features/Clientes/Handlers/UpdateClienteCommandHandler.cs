using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Domain;
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
        var cliente = await _clienteRepository.GetClienteByIdentificacionAsync(command.Identificacion, cancellationToken)
                    ?? throw new NotFoundException(nameof(Cliente), command.Identificacion);

        cliente.Persona.Nombre = command.Body.Nombre;
        cliente.Persona.Genero = command.Body.Genero;
        cliente.Persona.FechaNacimiento = command.Body.FechaNacimiento;
        cliente.Persona.Direccion = command.Body.Direccion;
        cliente.Persona.Telefono = command.Body.Telefono;
        cliente.Contrasena = command.Body.Contrasena;
        cliente.Estado = command.Body.Estado!.Value;

        await _clienteRepository.UpdateClienteAsync(cliente, cancellationToken);
    }
}