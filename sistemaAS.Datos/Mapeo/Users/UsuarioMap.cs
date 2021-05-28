using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAS.Entidades.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace sistemaAS.Datos.Mapeo.Users
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario")
                 .HasKey(h => h.idUsuario);
            builder.Property(h => h.nombreUsuario)
                .HasMaxLength(100);
            builder.Property(h => h.tipoDocumento)
                .HasMaxLength(20);
            builder.Property(h => h.numDocumento)
                .HasMaxLength(20);
            builder.Property(h => h.direccion)
                .HasMaxLength(70);
            builder.Property(h => h.telefono)
                .HasMaxLength(20);
            builder.Property(h => h.email)
                .HasMaxLength(50);
            builder.Property(h => h.password_hash);
            builder.Property(h => h.password_sal);
            builder.Property(h => h.condicion);
            //relaciones
            builder.HasOne(v => v.Roles)
                .WithOne();
               
        }
    }
}
