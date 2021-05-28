using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAS.Entidades.Sales;
namespace sistemaAS.Datos.Mapeo.Sales
{
    public class DetalleVentaMap : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("detalleventa")
                 .HasKey(d => d.idDetalleVenta);
            builder.Property(d => d.cantidad);
            builder.Property(d => d.PrecioDetalleVenta);
            builder.Property(d => d.descuentoDetalleVenta);
            //relaciones fk
            builder.HasOne(x => x.Ventas)
                .WithOne();
            builder.HasOne(x => x.Articulos)
                .WithOne();
        }
    }
}
