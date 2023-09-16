using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Clientes.Commands;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Clientes.Handlers;

public class CreateCuentaCommandHandler : IRequestHandler<CreateClienteCommand>
{

    private readonly IMapper _mapper;
    private readonly IClienteRepository _clienteRepository;

    public CreateCuentaCommandHandler(IMapper mapper, IClienteRepository clienteRepository)
    {
        _mapper = mapper;
        _clienteRepository = clienteRepository;
    }

    public async Task Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var newCliente = _mapper.Map<Cliente>(request);
        await _clienteRepository.CreateClienteAsync(newCliente, cancellationToken);
    }
}