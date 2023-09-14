using ApiGestion.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiGestion.ApplicationCore.Infrastructure.Persistence.Configurations;

public class ClienteEntityConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> entity)
    {
        entity.ToTable("Cliente");

        entity.HasKey(e => e.ClienteId);

        entity.Property(e => e.Contrasena)
            .HasMaxLength(255)
            .IsUnicode(false);

        entity.Property(e => e.Estado)
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.HasOne(d => d.Persona)
            .WithMany(p => p.Clientes)
            .HasForeignKey(d => d.PersonaId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}