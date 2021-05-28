using Microsoft.EntityFrameworkCore;
using sistemaAS.Datos.Mapeo.Wherehouse;
using sistemaAS.Datos.Mapeo.Sales;
using sistemaAS.Datos.Mapeo.Purchases;
using sistemaAS.Entidades.Purchases;
using sistemaAS.Entidades.Sales;
using sistemaAS.Entidades.Users;
using System;
using System.Collections.Generic;
using System.Text;
using sistemaAS.Datos.Mapeo.Users;
using sistemaAS.Entidades.Wherehouse;

namespace sistemaAS.Datos
{
    public class DbContextSistema : DbContext
    
   
    {
      
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<DetalleIngreso> DetalleIngresos { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> ventas { get; set; }
        public DbContextSistema(DbContextOptions<DbContextSistema>options) : base(options)
        {


        }
      
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //NACEN TODAS LAS ENTIDADES MAPEADAS QUE UTILIZAREMOS
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ArticuloMap());
            modelBuilder.ApplyConfiguration(new DetalleIngresoMap());
            modelBuilder.ApplyConfiguration(new DetalleVentaMap());
            modelBuilder.ApplyConfiguration(new IngresoMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new VentaMap());


            //para cuando hay una relación

        }
    
    
    }

}
