using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Movimientos.Commands;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Movimientos.Handlers;
public class CreateMovimientoCommandHandler : IRequestHandler<CreateMovimientoCommand>
{
    private readonly ICuentaRepository _cuentaRepository;
    private readonly IMovimientoRepository _movimientoRepository;

    public CreateMovimientoCommandHandler(ICuentaRepository cuentaRepository, IMovimientoRepository movimientoRepository)
    {
        _cuentaRepository = cuentaRepository;
        _movimientoRepository = movimientoRepository;
    }

    public async Task Handle(CreateMovimientoCommand command, CancellationToken cancellationToken)
    {
        var cuenta = await _cuentaRepository.GetCuentaByNumeroAsync(command.NumeroCuenta, cancellationToken)
            ?? throw new NotFoundException(nameof(Cuenta), command.NumeroCuenta);
        ValidateSaldo(cuenta, command.Valor);
        await ValidateLimiteDiarioAsync(cuenta, command.Valor, cancellationToken);

        decimal newSaldoDisponible = cuenta.SaldoDisponible + command.Valor;

        var newMovimiento = new Movimiento()
        {
            CuentaId = cuenta.CuentaId,
            Fecha = DateTime.UtcNow,
            Saldo = newSaldoDisponible,
            Valor = command.Valor,
            Tipo = command.Valor > 0
                ? $"Deposito de {command.Valor}"
                : $"Retiro de {Math.Abs(command.Valor)}"
        };

        cuenta.SaldoDisponible = newSaldoDisponible;

        await _movimientoRepository.CreateMovimientoAsync(newMovimiento, cancellationToken);
        await _cuentaRepository.UpdateCuentaAsync(cuenta, cancellationToken);
    }

    private static bool EsDebito(decimal monto) => monto < 0;

    private static void ValidateSaldo(Cuenta cuenta, decimal monto)
    {
        bool tieneSaldoDisponible = cuenta.SaldoDisponible >= Math.Abs(monto);
        if (EsDebito(monto) && !tieneSaldoDisponible)
        {
            throw new BusinessException(ConstantMessages.SaldoNoDisponible);
        }
    }

    private async Task ValidateLimiteDiarioAsync(Cuenta cuenta, decimal monto, CancellationToken cancellationToken)
    {
        if (!EsDebito(monto))
        {
            return;
        }

        DateTime fechaActual = DateTime.UtcNow;
        var totalRetiroDia = await _cuentaRepository.GetTotalRetiroFecha(cuenta.NumeroCuenta, fechaActual, cancellationToken);

        bool excedeLimiteDiario = Math.Abs(totalRetiroDia) + Math.Abs(monto) > Parametros.LimiteDiario;

        if (excedeLimiteDiario)
        {
            throw new BusinessException(ConstantMessages.CupoDiarioExcedido);
        }
    }
}
