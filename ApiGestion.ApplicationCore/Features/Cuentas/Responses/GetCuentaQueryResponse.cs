namespace ApiGestion.ApplicationCore.Features.Cuentas.Responses;
public class GetCuentaQueryResponse
{
    public string NumeroCuenta { get; set; } = null!;
    public string Tipo { get; set; } = null!;
    public decimal SaldoInicial { get; set; }
    public decimal SaldoDisponible { get; set; }
    public bool Estado { get; set; }
    public string IdentificacionCliente { get; set; } = null!;
    public string NombreCliente { get; set; } = null!;
}