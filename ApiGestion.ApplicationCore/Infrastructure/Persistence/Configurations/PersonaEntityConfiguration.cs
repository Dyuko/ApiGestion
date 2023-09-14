using ApiGestion.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiGestion.ApplicationCore.Infrastructure.Persistence.Configurations;

public class PersonaEntityConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> entity)
    {
        entity.ToTable("Persona");

        entity.HasKey(e => e.PersonaId);

        entity.HasIndex(e => e.Identificacion)
            .IsUnique();

        entity.Property(e => e.Direccion)
            .HasMaxLength(255)
            .IsUnicode(false);

        entity.Property(e => e.FechaNacimiento)
            .HasColumnType("date");

        entity.Property(e => e.Genero)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();

        entity.Property(e => e.Identificacion)
            .HasMaxLength(20)
            .IsUnicode(false);

        entity.Property(e => e.Nombre)
            .HasMaxLength(100)
            .IsUnicode(false);

        entity.Property(e => e.Telefono)
            .HasMaxLength(20)
            .IsUnicode(false);
    }
}
