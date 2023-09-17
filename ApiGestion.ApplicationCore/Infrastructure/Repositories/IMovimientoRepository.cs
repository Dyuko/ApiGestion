using ApiGestion.ApplicationCore.Domain;

namespace ApiGestion.ApplicationCore.Infrastructure.Repositories;
public interface IMovimientoRepository
{
    public Task CreateMovimientoAsync(Movimiento movimiento, CancellationToken cancellationToken);
}
