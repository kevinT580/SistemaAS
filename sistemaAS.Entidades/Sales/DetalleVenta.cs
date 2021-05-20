using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace sistemaAS.Entidades.Sales
{
   public class DetalleVenta
    {
        public int idDetalleVenta { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage = "ERROR")]
        public int idVenta { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Error")]
        public int idArticulo { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage = "ERROR")]
        public string cantidad { get; set; }
        [StringLength(50)]
        public string PrecioDetalleVenta { get; set; }
        [StringLength(50)]
        public string descuentoDetalleVenta { get; set; }
    }
}
