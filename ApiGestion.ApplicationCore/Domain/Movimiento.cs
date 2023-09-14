namespace ApiGestion.ApplicationCore.Domain;

public partial class Movimiento
{
    public int MovimientoId { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Tipo { get; set; }

    public decimal? Valor { get; set; }

    public decimal? Saldo { get; set; }

    public int CuentaId { get; set; }

    public virtual Cuenta Cuenta { get; set; } = null!;
}
