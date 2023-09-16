using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Cuentas.Commands;
using AutoMapper;

namespace ApiGestion.ApplicationCore.Features.Clientes.MapsProfile;

public class CreateCuentaCommandProfile : Profile
{
    public CreateCuentaCommandProfile() =>
        CreateMap<CreateCuentaCommand, Cuenta>()
            .ForMember(dest => dest.CuentaId, opt => opt.Ignore())
            .ForMember(dest => dest.SaldoDisponible, opt => opt.MapFrom(src => src.SaldoInicial))
            .ForMember(dest => dest.ClienteId, opt => opt.Ignore())
            .ForMember(dest => dest.Cliente, opt => opt.Ignore())
            .ForMember(dest => dest.Movimientos, opt => opt.Ignore());
}