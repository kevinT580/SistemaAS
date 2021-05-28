using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAS.Entidades.Sales;
namespace sistemaAS.Datos.Mapeo.Sales
{
    public class VentaMap : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("venta")
                 .HasKey(i => i.idVenta);
            builder.Property(i => i.tipoComprobante)
            .HasMaxLength(20);
            builder.Property(i => i.serieComprobante)
                .HasMaxLength(7);
            builder.Property(i => i.numComprobante)
                .HasMaxLength(10);
            builder.Property(i => i.fechaHora);
            builder.Property(i => i.impuesto);
            builder.Property(i => i.total);
            builder.Property(i => i.estado)
                .HasMaxLength(20);

            //RELACIONES
            builder.HasOne(U => U.Personas)
                .WithOne();
            builder.HasOne(u => u.Usuarios)
                .WithOne();
        }
    }
}
