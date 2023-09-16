﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Commands;

public class UpdateCuentaCommand : IRequest
{
    [FromRoute]
    public string NumeroCuenta { get; set; } = null!;
    [FromBody]
    public UpdateCuentaCommandBody Body { get; set; } = null!;
}

public class UpdateCuentaCommandBody
{
    public string Tipo { get; set; } = null!;
    public decimal SaldoInicial { get; set; }
    public decimal SaldoDisponible { get; set; }
    public bool Estado { get; set; }
    public string IdentificacionCliente { get; set; } = null!;
}