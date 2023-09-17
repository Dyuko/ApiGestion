using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Movimientos.Responses;
using AutoMapper;

namespace ApiGestion.ApplicationCore.Features.Movimientos.MapsProfile;
public class GetMovimientoQueryProfile : Profile
{
    public GetMovimientoQueryProfile() =>
        CreateMap<Movimiento, GetMovimientoQueryResponse>()
            .ForMember(dest => dest.NumeroCuenta, opt => opt.MapFrom(src => src.Cuenta.NumeroCuenta))
            .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
            .ForMember(dest => dest.Saldo, opt => opt.MapFrom(src => src.Saldo))
            .ForMember(dest => dest.EstadoCuenta, opt => opt.MapFrom(src => src.Cuenta.Estado))
            .ForMember(dest => dest.NombreCliente, opt => opt.MapFrom(src => src.Cuenta.Cliente.Persona.Nombre));
}
