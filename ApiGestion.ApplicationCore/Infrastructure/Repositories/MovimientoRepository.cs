using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ApiGestion.ApplicationCore.Infrastructure.Repositories;

public class MovimientoRepository : IMovimientoRepository
{
    private readonly GestionDbContext _context;

    public MovimientoRepository(GestionDbContext context) => _context = context;

    public async Task CreateMovimientoAsync(Movimiento movimiento, CancellationToken cancellationToken)
    {
        _context.Movimientos.Add(movimiento);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Movimiento>> GetMovimientosAsync(CancellationToken cancellationToken) => 
        await _context.Movimientos.AsNoTracking()
            .Include(movimiento => movimiento.Cuenta)
            .ThenInclude(cuenta => cuenta.Cliente)
            .ThenInclude(cliente => cliente.Persona)
            .ToListAsync(cancellationToken);
}