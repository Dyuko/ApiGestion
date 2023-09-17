namespace ApiGestion.ApplicationCore.Features.Reportes.Responses;
public class GetReporteQueryResponse
{
    public DateTime Fecha { get; set; }
    public string NombreCliente { get; set; } = null!;
    public string NumeroCuenta { get; set; } = null!;
    public string TipoCuenta { get; set; } = null!;
    public bool EstadoCuenta { get; set; }
    public decimal SaldoInicial { get; set; }
    public decimal SaldoDisponible { get; set; }
    public decimal SumaMovimientos { get; set; }
}