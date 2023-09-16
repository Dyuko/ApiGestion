using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Cuentas.Queries;
using ApiGestion.ApplicationCore.Features.Cuentas.Responses;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Handlers;
public class GetCuentaQueryHandler : IRequestHandler<GetCuentaQuery, GetCuentaQueryResponse>
{
    private readonly ICuentaRepository _cuentaRepository;
    private readonly IMapper _mapper;

    public GetCuentaQueryHandler(ICuentaRepository cuentaRepository, IMapper mapper)
    {
        _cuentaRepository = cuentaRepository;
        _mapper = mapper;
    }

    public async Task<GetCuentaQueryResponse> Handle(GetCuentaQuery request, CancellationToken cancellationToken)
    {
        var cuenta = await _cuentaRepository.GetCuentaByNumeroAsync(request.NumeroCuenta, cancellationToken)
            ?? throw new NotFoundException(nameof(Cuenta), request.NumeroCuenta);

        return _mapper.Map<GetCuentaQueryResponse>(cuenta);
    }
}