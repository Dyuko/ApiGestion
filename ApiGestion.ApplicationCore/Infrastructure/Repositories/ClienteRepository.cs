using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Infrastructure.Persistence;
using EntityFramework.Exceptions.Common;
using Microsoft.EntityFrameworkCore;

namespace ApiGestion.ApplicationCore.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly GestionDbContext _context;

    public ClienteRepository(GestionDbContext context) => _context = context;

    public async Task CreateClienteAsync(Cliente cliente, CancellationToken cancellationToken)
    {
        _context.Clientes.Add(cliente);
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (UniqueConstraintException)
        {
            throw new DuplicateIdentifierException(nameof(Cliente), cliente.Persona.Identificacion);
        }
    }

    public async Task<Cliente?> GetClienteByIdentificacionAsync(string identificacion, CancellationToken cancellationToken) => 
        await _context.Clientes.AsNoTracking()
            .Include(cliente => cliente.Persona)
            .FirstOrDefaultAsync(cliente => cliente.Persona.Identificacion.Equals(identificacion), cancellationToken: cancellationToken);

    public async Task<List<Cliente>> GetClientesListAsync(CancellationToken cancellationToken) => 
        await _context.Clientes.AsNoTracking()
            .Include(cliente => cliente.Persona)
            .ToListAsync(cancellationToken);

    public async Task UpdateClienteAsync(Cliente cliente, CancellationToken cancellationToken)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteClienteAsync(Cliente cliente, CancellationToken cancellationToken)
    {
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
