using ApiGestion.ApplicationCore.Features.Clientes.Responses;
using FluentAssertions;
using NUnit.Framework;
using System.Net.Http.Json;

namespace ApiGestion.Tests.Features.Clientes;
public class GetClientesQueryIntegrationTests : TestBase
{
    [Test]
    public async Task GetClientes()
    {
        // Arrenge
        var httpClient = GetClient();

        // Act
        var clientes = await httpClient.GetFromJsonAsync<List<GetClienteQueryResponde>>("/api/clientes");

        // Assert
        clientes.Should().NotBeNullOrEmpty();
        clientes?.Count.Should().Be(2);
    }
}