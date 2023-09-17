using ApiGestion.ApplicationCore.Common.Exceptions;
using ApiGestion.ApplicationCore.Features.Movimientos.Queries;
using ApiGestion.ApplicationCore.Features.Movimientos.Responses;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Movimientos.Handlers;
public class GetMovimientosQueryHandler : IRequestHandler<GetMovimientoQuery, List<GetMovimientoQueryResponse>>
{
    private readonly IMovimientoRepository _movimientoRepository;
    private readonly IMapper _mapper;

    public GetMovimientosQueryHandler(IMovimientoRepository movimientoRepository, IMapper mapper)
    {
        _movimientoRepository = movimientoRepository;
        _mapper = mapper;
    }

    public async Task<List<GetMovimientoQueryResponse>> Handle(GetMovimientoQuery request, CancellationToken cancellationToken)
    {
        var movimientos = await _movimientoRepository.GetMovimientosAsync(cancellationToken);

        if (movimientos.Count == 0)
        {
            throw new NoContentException();
        }

        return _mapper.Map<List<GetMovimientoQueryResponse>>(movimientos);
    }
}