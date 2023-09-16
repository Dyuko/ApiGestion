namespace ApiGestion.ApplicationCore.Domain;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Contrasena { get; set; } = null!;

    public bool Estado { get; set; }

    public int PersonaId { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();

    public virtual Persona Persona { get; set; } = null!;
}