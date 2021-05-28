using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAS.Entidades.Purchases;

namespace sistemaAS.Datos.Mapeo.Wherehouse
{
    public class ArticuloMap : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.ToTable("articulo")
                .HasKey(b => b.idArticulo);
            builder.Property(b => b.codigoArticulo)
              .HasMaxLength(50);
            builder.Property(b => b.nombreArticulo)
                .HasMaxLength(50);
            builder.Property(b => b.precioVenta);
            builder.Property(b => b.stock);
            builder.Property(b => b.descripcionArticulo)
                .HasMaxLength(256);
            builder.Property(b => b.condicion);
            //RELACION CON CATEGORIA 1 A 1 
            builder.HasOne(z => z.Categorias)
                .WithOne();
                


        }
    }
}
