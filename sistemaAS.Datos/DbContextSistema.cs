using Microsoft.EntityFrameworkCore;
using sistemaAS.Datos.Mapeo.Wherehouse;
using sistemaAS.Entidades.Purchases;
using System;
using System.Collections.Generic;
using System.Text;

namespace sistemaAS.Datos
{
    public class DbContextSistema : DbContext
    
   
    {
      
        public DbSet<Categoria> Categorias { get; set; }
        public DbContextSistema(DbContextOptions<DbContextSistema>options) : base(options)
        {

        }
      
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //NACEN TODAS LAS ENTIDADES MAPEADAS QUE UTILIZAREMOS
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            //para cuando hay una relación
            modelBuilder.Entity
        }
    
    
    }

}
