﻿using ApiGestion.ApplicationCore.Domain;

namespace ApiGestion.ApplicationCore.Infrastructure.Repositories;

public interface IClienteRepository
{
    public Task CreateClienteAsync(Cliente cliente, CancellationToken cancellationToken);
    public Task<Cliente> GetClienteByIdentificacion(string identificacion, CancellationToken cancellationToken);
    public Task<List<Cliente>> GetClientesListAsync(CancellationToken cancellationToken);
    public Task UpdateClienteAsync(Cliente cliente, CancellationToken cancellationToken);
    public Task DeleteClienteAsync(string Identificacion, CancellationToken cancellationToken);
}
