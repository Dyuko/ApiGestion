﻿using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Clientes.Commands;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Clientes.Handlers;

public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public DeleteClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task Handle(DeleteClienteCommand command, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.GetClienteByIdentificacionAsync(command.Identificacion, cancellationToken)
            ?? throw new NotFoundException(nameof(Cliente), command.Identificacion);
        await _clienteRepository.DeleteClienteAsync(cliente, cancellationToken);
    }
}