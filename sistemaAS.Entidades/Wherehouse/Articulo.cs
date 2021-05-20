using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace sistemaAS.Entidades.Wherehouse
{
    public class Articulo
    {


        public int idArticulo { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Error")]
        public int idCategoria { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Error")]
        public string codigoArticulo { get; set; }
        [StringLength(50)]
        public string nombreArticulo { get; set; }
        [StringLength(50)]
        public string precioVenta { get; set; }
        [StringLength(80)]
        public string stock { get; set; }
        [StringLength(50)]
        public string descripcionArticulo { get; set;}
        [StringLength(256)]
        public string condicion { get; set; }
    }
}
