namespace ApiGestion.ApplicationCore.Domain;

public partial class Cuenta
{
    public int CuentaId { get; set; }

    public string? NumeroCuenta { get; set; }

    public string? Tipo { get; set; }

    public decimal SaldoInicial { get; set; }

    public bool Estado { get; set; }

    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
