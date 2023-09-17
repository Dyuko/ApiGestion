namespace ApiGestion.ApplicationCore.Features.Movimientos.Responses;
public class GetMovimientoQueryResponse
{
    public string NumeroCuenta { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public string Tipo { get; set; } = null!;
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
    public bool EstadoCuenta { get; set; }
    public string NombreCliente { get; set; } = null!;
}