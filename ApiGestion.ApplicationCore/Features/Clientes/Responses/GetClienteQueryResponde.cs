using ApiGestion.ApplicationCore.Features.Clientes.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestion.ApplicationCore.Features.Clientes.Responses;

public class GetClienteQueryResponde : GetPersonaQueryResponse
{
    public string Contrasena { get; set; } = null!;
    public string Estado { get; set; } = null!;
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