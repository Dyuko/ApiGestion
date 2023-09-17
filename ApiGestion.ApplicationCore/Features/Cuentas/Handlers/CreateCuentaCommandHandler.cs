using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Cuentas.Commands;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Handlers;

public class CreateCuentaCommandHandler : IRequestHandler<CreateCuentaCommand>
{

    private readonly IMapper _mapper;
    private readonly ICuentaRepository _cuentaRepository;
    private readonly IClienteRepository _clienteRepository;

    public CreateCuentaCommandHandler(IMapper mapper, ICuentaRepository cuentaRepository, IClienteRepository clienteRepository)
    {
        _mapper = mapper;
        _cuentaRepository = cuentaRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task Handle(CreateCuentaCommand command, CancellationToken cancellationToken)
    {
        var newCuenta = _mapper.Map<Cuenta>(command);

        var cliente = await _clienteRepository.GetClienteByIdentificacionAsync(command.IdentificacionCliente, cancellationToken)
            ?? throw new NotFoundException(nameof(Cliente), command.IdentificacionCliente);

        newCuenta.ClienteId = cliente.ClienteId;

        await _cuentaRepository.CreateCuentaAsync(newCuenta, cancellationToken);
    }
}