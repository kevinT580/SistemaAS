using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using sistemaAS.Entidades.Users;

namespace sistemaAS.Entidades.Sales
{
    public class Venta
    {
        public int idVenta { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3,ErrorMessage = "ERROR")]
        
        public string tipoComprobante { get; set; }
        [StringLength(20)]
        public string serieComprobante { get; set; }
        [StringLength(7)]
        public string numComprobante { get; set; }
        [StringLength(10)]
        public DateTime fechaHora { get; set; }
        
        public decimal impuesto { get; set; }
     
        public decimal total { get; set; }
   
        public string estado { get; set; }

        public List<Person> Personas { get; set; }
        public List<Usuario> Usuarios { get; set; }

    }
}
