using ApiGestion.ApplicationCore.Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace ApiGestion.Tests;
public class TestBase
{
    protected ApiWebApplicationFactory Application;

    /// <summary>
    /// Al terminar cada prueba, se resetea la base de datos
    /// </summary>
    /// <returns></returns>
    [TearDown]
    public async Task Down() => await ResetState();

    /// <summary>
    /// Libera recursos al terminar todas las pruebas
    /// </summary>
    [OneTimeTearDown]
    public void RunAfterAnyTests() => Application.Dispose();

    /// <summary>
    /// Inicializa la API y la BD antes de iniciar las pruebas
    /// </summary>
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        Application = new ApiWebApplicationFactory();

        EnsureDatabase();
    }

    /// <summary>
    /// Crea un HttpClient
    /// </summary>
    public HttpClient GetClient() =>
        Application.CreateClient();

    /// <summary>
    /// Shortcut para ejecutar IRequests con el Mediador
    /// </summary>
    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        using var scope = Application.Services.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        return await mediator.Send(request);
    }

    /// <summary>
    /// Se asegura de crear la BD
    /// </summary>
    private void EnsureDatabase()
    {
        using var scope = Application.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<GestionDbContext>();

        context!.Database.EnsureCreated();
    }

    /// <summary>
    /// Se asegura de limpiar la BD
    /// </summary>
    /// <returns></returns>
    private async Task ResetState()
    {
        using var scope = Application.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<GestionDbContext>();

        context!.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        await GestionDbContextSeed.SeedDataAsync(context);
    }
}