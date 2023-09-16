using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Cuentas.Commands;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Handlers;

public class DeleteCuentaCommandHandler : IRequestHandler<DeleteCuentaCommand>
{
    private readonly ICuentaRepository _cuentaRepository;

    public DeleteCuentaCommandHandler(ICuentaRepository cuentaRepository)
    {
        _cuentaRepository = cuentaRepository;
    }

    public async Task Handle(DeleteCuentaCommand command, CancellationToken cancellationToken)
    {
        var cuenta = await _cuentaRepository.GetCuentaByNumeroAsync(command.NumeroCuenta, cancellationToken)
            ?? throw new NotFoundException(nameof(Cuenta), command.NumeroCuenta);

        await _cuentaRepository.DeleteCuentaAsync(cuenta, cancellationToken);
    }
}