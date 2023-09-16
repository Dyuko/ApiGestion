﻿using ApiGestion.ApplicationCore.Features.Cuentas.Responses;
using MediatR;

namespace ApiGestion.ApplicationCore.Features.Cuentas.Queries;

public class GetCuentaQuery : IRequest<GetCuentaQueryResponse>
{
    public string NumeroCuenta { get; set; } = null!;
}