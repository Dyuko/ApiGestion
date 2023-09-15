using ApiGestion.ApplicationCore.Domain;
using AutoMapper;

namespace ApiGestion.ApplicationCore.Features.Clientes.Responses;

public class GetClienteQueryResponde : GetPersonaQueryResponse
{
    public string Contrasena { get; set; } = null!;
    public bool Estado { get; set; }
}

public class GetPersonaQueryResponse
{
    public string Nombre { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public string Identificacion { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }
}