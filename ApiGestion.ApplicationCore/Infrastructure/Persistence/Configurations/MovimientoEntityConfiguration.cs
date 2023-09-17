using ApiGestion.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiGestion.ApplicationCore.Infrastructure.Persistence.Configurations;

public class MovimientoEntityConfiguration : IEntityTypeConfiguration<Movimiento>
{
    public void Configure(EntityTypeBuilder<Movimiento> entity)
    {
        entity.ToTable("Movimiento");

        entity.HasKey(e => e.MovimientoId);

        entity.Property(e => e.Fecha)
            .HasColumnType("datetime");

        entity.Property(e => e.Saldo)
            .HasColumnType("decimal(18, 2)");

        entity.Property(e => e.Tipo)
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.Property(e => e.Valor)
            .HasColumnType("decimal(18, 2)");

        entity.HasOne(d => d.Cuenta)
            .WithMany(p => p.Movimientos)
            .HasForeignKey(d => d.CuentaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}