using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAS.Entidades.Purchases;
using System;
using System.Collections.Generic;
using System.Text;



namespace sistemaAS.Datos.Mapeo.Wherehouse
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria")
                .HasKey(a => a.idcategoria);
            builder.Property(a => a.nombre)
            .HasMaxLength(50);
            builder.Property(a => a.descripcion)
                .HasMaxLength(256);

            builder.Property(b => b.condicion);
            //RELACION CON CATEGORIA 1 A 1 
          

        }
    }
}
