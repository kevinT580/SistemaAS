using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using sistemaAS.Entidades.Purchases;

namespace sistemaAS.Entidades.Sales
{
   public class DetalleVenta
    {
        public int idDetalleVenta { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage = "ERROR")]
        
        public string cantidad { get; set; }
        [StringLength(50)]
        public decimal PrecioDetalleVenta { get; set; }
       
        public decimal descuentoDetalleVenta { get; set; }
        //FK PARA TBL VENTAS Y ARTICULOS
        public List<Venta> Ventas { get; set; }
        public List<Articulo> Articulos { get; set; }

    }
}
