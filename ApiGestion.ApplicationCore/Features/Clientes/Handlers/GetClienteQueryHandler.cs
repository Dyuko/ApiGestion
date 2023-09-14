using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Clientes.Queries;
using ApiGestion.ApplicationCore.Features.Clientes.Responses;
using ApiGestion.ApplicationCore.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;

namespace ApiGestion.ApplicationCore.Features.Clientes.Handlers;

public class GetClienteQueryHandler : IRequestHandler<GetClienteQuery, GetClienteQueryResponde>
{
    private readonly GestionDbContext _context;

    public GetClienteQueryHandler(GestionDbContext context)
    {
        _context = context;
    }

    public async Task<GetClienteQueryResponde> Handle(GetClienteQuery request, CancellationToken cancellationToken)
    {
        var cliente = await _context.Clientes.AsNoTracking()
                    .Include(cliente => cliente.Persona)
                    .FirstOrDefaultAsync(cliente => cliente.Persona.Identificacion.Equals(request.Identificacion), cancellationToken: cancellationToken)
                    ?? throw new NotFoundException(nameof(Cliente), request.Identificacion);

        return TinyMapper.Map<GetClienteQueryResponde>(cliente);
    }
}