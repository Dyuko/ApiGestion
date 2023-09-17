using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Infrastructure.Persistence;

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
}