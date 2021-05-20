using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace sistemaAS.Entidades.Sales
{
    public class Venta
    {
        public int idVenta { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3,ErrorMessage = "ERROR")]
        public int idCliente { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage = "NO ENCONTRADO")]
        public int idUsuario { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage = "ERROR")]
        public string tipoComprobante { get; set; }
        [StringLength(20)]
        public string serieComprobante { get; set; }
        [StringLength(7)]
        public string numComprobante { get; set; }
        [StringLength(10)]
        public DateTime fechaHora { get; set; }
        
        public string impuesto { get; set; }
        [StringLength(50)]
        public string total { get; set; }
        [StringLength(50)]
        public string estado { get; set; }
    }
}
