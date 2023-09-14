using ApiGestion.ApplicationCore.Domain;
using ApiGestion.ApplicationCore.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiGestion.ApplicationCore.Infrastructure.Persistence;

public class GestionDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public GestionDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuenta> Cuenta { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonaEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ClienteEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CuentaEntityConfiguration());
        modelBuilder.ApplyConfiguration(new MovimientoEntityConfiguration());
    }
}