using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAS.Entidades.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace sistemaAS.Datos.Mapeo.Users
{
    public class RolMap : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("rol")
                .HasKey(g => g.idRol);
            builder.Property(g => g.nombreRol)
                 .HasMaxLength(50);
            builder.Property(g => g.descripcionRol)
                .HasMaxLength(100);
            builder.Property(g => g.condicion);
                
        }
    }
}
