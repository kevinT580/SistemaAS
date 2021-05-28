using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAS.Entidades.Purchases;
using sistemaAS.Entidades.Wherehouse;

using sistemaAS.Entidades.Users;

using sistemaAS.Entidades.Sales;


namespace sistemaAS.Datos.Mapeo.Purchases
{
    public class DetalleIngresoMap : IEntityTypeConfiguration<DetalleIngreso>
    {
        public void Configure(EntityTypeBuilder<DetalleIngreso> builder)
        {
            builder.ToTable("DetalleIngreso")
                .HasKey(c => c.idDetalleIngreso);
            builder.Property(c => c.cantidad);
            builder.Property(c => c.precioDetalle);
            //fk de ingreso
            builder.HasOne(y => y.Ingresos)
                .WithOne();
            //fk de articulo
            builder.HasOne(y => y.Articulos)
                .WithOne();
        }
    }
}
