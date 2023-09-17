using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Infrastructure.Persistence;
using ApiGestion.ApplicationCore.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace ApiGestion.Tests.Features.Clientes;
public class ClienteRepositoryUnitTests : TestBase
{
    [Test]
    public async Task GetClienteByIdentificacionAsync_WithValidIdentificacion_ReturnsCliente()
    {
        // Arrange
        using var scope = Application.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<GestionDbContext>();
        var clienteRepository = new ClienteRepository(context!);
        var cancellationToken = CancellationToken.None;

        // Act
        string identificacion = "001";
        var result = await clienteRepository.GetClienteByIdentificacionAsync(identificacion, cancellationToken);

        // Assert
        Assert.That(result, Is.Not.Null); // Asegurarse de que el resultado no sea nulo
        Assert.That(result.Persona.Identificacion, Is.EqualTo(identificacion)); // Asegurarse de que la identificación coincida
    }

    [Test]
    public async Task GetClientesListAsync_ReturnsListOfClientes()
    {
        // Arrange
        using var scope = Application.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<GestionDbContext>();
        var clienteRepository = new ClienteRepository(context!);
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await clienteRepository.GetClientesListAsync(cancellationToken);

        // Assert
        Assert.That(result, Is.Not.Null); // Asegurarse de que el resultado no sea nulo
        Assert.IsAssignableFrom<List<Cliente>>(result); // Asegurarse de que el resultado sea una lista de Clientes
        Assert.That(result.Count > 0, Is.True); // Asegurarse de que la lista contenga elementos
    }
}