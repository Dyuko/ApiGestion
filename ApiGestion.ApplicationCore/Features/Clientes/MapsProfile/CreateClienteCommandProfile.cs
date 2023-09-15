using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Features.Clientes.Commands;
using AutoMapper;

namespace ApiGestion.ApplicationCore.Features.Clientes.MapsProfile;

public class CreateClienteCommandProfile : Profile
{
    public CreateClienteCommandProfile() =>
        CreateMap<CreateClienteCommand, Cliente>()
            .ForMember(dest => dest.ClienteId, opt => opt.Ignore())
            .ForMember(dest => dest.Persona, opt => opt.MapFrom(src => new Persona
            {
                Nombre = src.Nombre,
                Genero = src.Genero,
                FechaNacimiento = src.FechaNacimiento,
                Identificacion = src.Identificacion,
                Direccion = src.Direccion,
                Telefono = src.Telefono
            }))
            .ForMember(dest => dest.Contrasena, opt => opt.MapFrom(src => src.Contrasena))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado));
}