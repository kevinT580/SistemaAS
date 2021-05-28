using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAS.Entidades.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace sistemaAS.Datos.Mapeo.Users
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("personas")
                .HasKey(f => f.idPersona);
            builder.Property(f => f.tipoPersona)
                .HasMaxLength(20);
            builder.Property(f => f.primerNombre)
                .HasMaxLength(100);
            builder.Property(f => f.segundoNombre)
                .HasMaxLength(100);
            builder.Property(f => f.tercerNombre)
                .HasMaxLength(100);
            builder.Property(f => f.primerApellido)
                .HasMaxLength(100);
            builder.Property(f => f.segundoApellido)
                .HasMaxLength(100);
            builder.Property(f => f.tercerApellido)
                .HasMaxLength(100);
            builder.Property(f => f.tipoDocumento)
                .HasMaxLength(50);
            builder.Property(f => f.numDocumento)
                .HasMaxLength(70);
            builder.Property(f => f.telefonoPersona)
                .HasMaxLength(20);
            builder.Property(f => f.email)
                .HasMaxLength(50);

        }
    }
}
