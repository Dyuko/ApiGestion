using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Features.Clientes.Queries;
using ApiGestion.ApplicationCore.Features.Clientes.Responses;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Clientes.Handlers;

public class GetClientesQueryHandler : IRequestHandler<GetClientesQuery, List<GetClienteQueryResponde>>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;

    public GetClientesQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
    }

    public async Task<List<GetClienteQueryResponde>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
    {
        var clientes = await _clienteRepository.GetClientesListAsync(cancellationToken);

        if (clientes.Count == 0)
        {
            throw new NotFoundException();
        }

        return _mapper.Map<List<GetClienteQueryResponde>>(clientes);
    }
}