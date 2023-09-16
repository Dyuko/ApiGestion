using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Cuentas.Responses;
using AutoMapper;

namespace ApiGestion.ApplicationCore.Features.Cuentas.MapsProfile;
public class GetCuentaQueryProfile : Profile
{
    public GetCuentaQueryProfile() =>
        CreateMap<Cuenta, GetCuentaQueryResponse>()
            .ForMember(dest => dest.NumeroCuenta, opt => opt.MapFrom(src => src.NumeroCuenta))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.SaldoInicial, opt => opt.MapFrom(src => src.SaldoInicial))
            .ForMember(dest => dest.SaldoDisponible, opt => opt.MapFrom(src => src.SaldoDisponible))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
            .ForMember(dest => dest.IdentificacionCliente, opt => opt.MapFrom(src => src.Cliente.Persona.Identificacion))
            .ForMember(dest => dest.NombreCliente, opt => opt.MapFrom(src => src.Cliente.Persona.Nombre));
}
