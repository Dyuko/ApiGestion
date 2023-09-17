using ApiGestion.ApplicationCore.Domain;

namespace ApiGestion.ApplicationCore.Infrastructure.Repositories;

public interface ICuentaRepository
{
    public Task CreateCuentaAsync(Cuenta cuenta, CancellationToken cancellationToken);
    public Task<Cuenta?> GetCuentaByNumeroAsync(string numeroCuenta, CancellationToken cancellationToken);
    public Task UpdateCuentaAsync(Cuenta cuenta, CancellationToken cancellationToken);
    public Task<List<Cuenta>> GetCuentasCliente(string identificacionCliente, CancellationToken cancellationToken);
    public Task DeleteCuentaAsync(Cuenta cuenta, CancellationToken cancellationToken);
    public Task<List<Cuenta>> GetCuentas(CancellationToken cancellationToken);
    public Task<decimal> GetTotalRetiroFecha(string numeroCuenta, DateTime fecha, CancellationToken cancellationToken);
}
