using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Features.Cuentas.Queries;
using ApiGestion.ApplicationCore.Features.Cuentas.Responses;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Handlers;
public class GetCuentasQueryHandler : IRequestHandler<GetCuentasQuery, List<GetCuentaQueryResponse>>
{
    private readonly ICuentaRepository _cuentaRepository;
    private readonly IMapper _mapper;

    public GetCuentasQueryHandler(ICuentaRepository cuentaRepository, IMapper mapper)
    {
        _cuentaRepository = cuentaRepository;
        _mapper = mapper;
    }

    public async Task<List<GetCuentaQueryResponse>> Handle(GetCuentasQuery request, CancellationToken cancellationToken)
    {
        var cuentas = await _cuentaRepository.GetCuentas(cancellationToken);

        if (cuentas.Count == 0)
        {
            throw new NoContentException();
        }

        return _mapper.Map<List<GetCuentaQueryResponse>>(cuentas);
    }
}