using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace sistemaAS.Entidades.Wherehouse
{
    public class DetalleIngreso
    {
        public int idDetalleIngreso { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Error")]
        public int idArticulo { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Error")]
        public int idCategoria { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Error")]
        public string cantidad { get; set; }
        [StringLength(50)]
        public string precioDetalle { get; set; }
      
    }
}
