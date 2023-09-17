using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Infrastructure.Persistence;
using EntityFramework.Exceptions.Common;
using Microsoft.EntityFrameworkCore;

namespace ApiGestion.ApplicationCore.Infrastructure.Repositories;

public class CuentaRepository : ICuentaRepository
{
    private readonly GestionDbContext _context;

    public CuentaRepository(GestionDbContext context) => _context = context;

    public async Task CreateCuentaAsync(Cuenta cuenta, CancellationToken cancellationToken)
    {
        _context.Cuenta.Add(cuenta);
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (UniqueConstraintException)
        {
            throw new DuplicateIdentifierException(nameof(Cuenta), cuenta.NumeroCuenta);
        }
    }

    public async Task<List<Cuenta>> GetCuentas(CancellationToken cancellationToken) =>
        await _context.Cuenta.AsNoTracking()
            .Include(cuenta => cuenta.Cliente)
            .Include(cuenta => cuenta.Cliente.Persona)
            .ToListAsync(cancellationToken);

    public async Task<Cuenta?> GetCuentaByNumeroAsync(string numeroCuenta, CancellationToken cancellationToken) =>
        await _context.Cuenta.AsNoTracking()
            .Include(cuenta => cuenta.Cliente)
            .Include(cuenta => cuenta.Cliente.Persona)
            .FirstOrDefaultAsync(cuenta => cuenta.NumeroCuenta.Equals(numeroCuenta), cancellationToken);

    public async Task UpdateCuentaAsync(Cuenta cuenta, CancellationToken cancellationToken)
    {
        _context.Cuenta.Update(cuenta);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Cuenta>> GetCuentasCliente(string identificacionCliente, CancellationToken cancellationToken) =>
        await _context.Cuenta.AsNoTracking()
            .Include(cuenta => cuenta.Cliente)
            .Include(cuenta => cuenta.Cliente.Persona)
            .Where(cuenta => cuenta.Cliente.Persona.Identificacion.Equals(identificacionCliente))
            .ToListAsync(cancellationToken: cancellationToken);

    public async Task DeleteCuentaAsync(Cuenta cuenta, CancellationToken cancellationToken)
    {
        _context.Cuenta.Remove(cuenta);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<decimal> GetTotalRetiroFecha(string numeroCuenta, DateTime fecha, CancellationToken cancellationToken) => 
        await _context.Movimientos
            .Include(movimiento => movimiento.Cuenta)
            .Where(m =>
                m.Cuenta.NumeroCuenta.Equals(numeroCuenta) &&
                m.Valor < 0 &&
                m.Fecha.Date == fecha.Date)
            .SumAsync(m => m.Valor, cancellationToken);
}