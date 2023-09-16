using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Clientes.Queries;
using ApiGestion.ApplicationCore.Features.Clientes.Responses;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Clientes.Handlers;

public class GetClienteQueryHandler : IRequestHandler<GetClienteQuery, GetClienteQueryResponde>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;

    public GetClienteQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
    }

    public async Task<GetClienteQueryResponde> Handle(GetClienteQuery request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.GetClienteByIdentificacionAsync(request.Identificacion, cancellationToken) 
            ?? throw new NotFoundException(nameof(Cliente), request.Identificacion);
        return _mapper.Map<GetClienteQueryResponde>(cliente);
    }
}