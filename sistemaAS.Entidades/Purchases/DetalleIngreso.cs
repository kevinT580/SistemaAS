using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace sistemaAS.Entidades.Purchases
{
    public class DetalleIngreso
    {
        public int idDetalleIngreso { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Error")]
        public int cantidad { get; set; }
    
        public decimal precioDetalle { get; set; }
      
       public List<Ingreso> Ingresos { get; set; }
        public List<Articulo> Articulos { get; set; }
    }
}
