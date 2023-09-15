using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Clientes.Responses;
using AutoMapper;

namespace ApiGestion.ApplicationCore.Features.Clientes.MapsProfile;

public class GetClienteQueryProfile : Profile
{
    public GetClienteQueryProfile() =>
        CreateMap<Cliente, GetClienteQueryResponde>()
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Persona.Nombre))
            .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Persona.Genero))
            .ForMember(dest => dest.FechaNacimiento, opt => opt.MapFrom(src => src.Persona.FechaNacimiento))
            .ForMember(dest => dest.Identificacion, opt => opt.MapFrom(src => src.Persona.Identificacion))
            .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Persona.Direccion))
            .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Persona.Telefono))
            .ForMember(dest => dest.Contrasena, opt => opt.MapFrom(src => src.Contrasena))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado));
}