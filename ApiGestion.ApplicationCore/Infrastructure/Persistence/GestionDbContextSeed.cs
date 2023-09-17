using ApiGestion.ApplicationCore.Domain;

namespace ApiGestion.ApplicationCore.Infrastructure.Persistence;
public static class GestionDbContextSeed
{
    public static async Task SeedDataAsync(GestionDbContext context)
    {

        if (!context.Personas.Any())
        {
            context.Personas.AddRange(new List<Persona>
            {
                new Persona
                {
                    Nombre = "Persona 1",
                    Genero = Genero.M,
                    FechaNacimiento = DateTime.Now,
                    Identificacion = "001",
                    Direccion = "Direccion 1",
                    Telefono = "000000001",
                    Clientes = new List<Cliente>
                    {
                        new Cliente
                        {
                            Contrasena = "0001",
                            Estado = true,
                        }
                    }
                },
                new Persona
                {
                    Nombre = "Persona 2",
                    Genero = Genero.F,
                    FechaNacimiento = DateTime.Now,
                    Identificacion = "002",
                    Direccion = "Direccion 2",
                    Telefono = "000000002",
                    Clientes = new List<Cliente>
                    {
                        new Cliente
                        {
                            Contrasena = "0002",
                            Estado = true,
                        }
                    }
                },
            });

            await context.SaveChangesAsync();
        }
    }
}