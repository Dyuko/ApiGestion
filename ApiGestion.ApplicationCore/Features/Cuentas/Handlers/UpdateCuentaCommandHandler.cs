using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Cuentas.Commands;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Handlers;

public class UpdateCuentaCommandHandler : IRequestHandler<UpdateCuentaCommand>
{
    private readonly ICuentaRepository _cuentaRepository;
    private readonly IClienteRepository _clienteRepository;

    public UpdateCuentaCommandHandler(ICuentaRepository cuentaRepository, IClienteRepository clienteRepository)
    {
        _cuentaRepository = cuentaRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task Handle(UpdateCuentaCommand command, CancellationToken cancellationToken)
    {
        var cuenta = await _cuentaRepository.GetCuentaByNumeroAsync(command.NumeroCuenta, cancellationToken)
            ?? throw new NotFoundException(nameof(Cuenta), command.NumeroCuenta);

        var cliente = await _clienteRepository.GetClienteByIdentificacionAsync(command.Body.IdentificacionCliente, cancellationToken)
            ?? throw new NotFoundException(nameof(Cliente), command.Body.IdentificacionCliente);

        cuenta.Tipo = command.Body.Tipo;
        cuenta.SaldoInicial = command.Body.SaldoInicial;
        cuenta.SaldoDisponible = command.Body.SaldoDisponible;
        cuenta.Estado = command.Body.Estado;
        cuenta.ClienteId = cliente.ClienteId;

        await _cuentaRepository.UpdateCuentaAsync(cuenta, cancellationToken);
    }
}