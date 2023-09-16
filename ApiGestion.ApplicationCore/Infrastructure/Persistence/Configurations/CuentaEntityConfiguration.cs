using ApiGestion.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiGestion.ApplicationCore.Infrastructure.Persistence.Configurations;

public class CuentaEntityConfiguration : IEntityTypeConfiguration<Cuenta>
{
    public void Configure(EntityTypeBuilder<Cuenta> entity)
    {
        entity.ToTable("Cuenta");

        entity.HasKey(e => e.CuentaId);

        entity.HasIndex(e => e.NumeroCuenta)
            .IsUnique();

        entity.Property(e => e.NumeroCuenta)
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.Property(e => e.SaldoInicial)
            .HasColumnType("decimal(18, 2)");
        
        entity.Property(e => e.SaldoDisponible)
            .HasColumnType("decimal(18, 2)");

        entity.Property(e => e.Tipo)
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.HasOne(d => d.Cliente).WithMany(p => p.Cuenta)
            .HasForeignKey(d => d.ClienteId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}