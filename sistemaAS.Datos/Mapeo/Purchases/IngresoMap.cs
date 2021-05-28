using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAS.Entidades.Purchases;


namespace sistemaAS.Datos.Mapeo.Purchases
{
    public class IngresoMap : IEntityTypeConfiguration<Ingreso>
    {
        public void Configure(EntityTypeBuilder<Ingreso> builder)
        {
            builder.ToTable("Ingreso")
            .HasKey(e => e.idIngreso);
            builder.Property(e => e.tipoComprobante)
                .HasMaxLength(20);
            builder.Property(e => e.serieComprobante)
                .HasMaxLength(7);
            builder.Property(e => e.numComprobante)
                .HasMaxLength(10);
            builder.Property(e => e.fechaHora);
            builder.Property(e => e.impuesto);
            builder.Property(e => e.total);
            builder.Property(e => e.estado);

            //relaciones 
            builder.HasOne(w => w.Usuarios)
                .WithOne();
            builder.HasOne(w => w.Persons)
                .WithOne();

           
        }
    }
}
