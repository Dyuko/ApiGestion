namespace ApiGestion.ApplicationCore.Domain;

public partial class Persona
{
    public int PersonaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public string Identificacion { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
