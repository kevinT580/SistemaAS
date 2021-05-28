using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using sistemaAS.Entidades.Purchases;

namespace sistemaAS.Entidades.Wherehouse
{
    public class Articulo
    {


        public int idArticulo { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Error")]
        public string codigoArticulo { get; set; }
        [StringLength(50)]
        public string nombreArticulo { get; set; }
        [StringLength(50)]
        public decimal precioVenta { get; set; }
        public int stock { get; set; }
        public string descripcionArticulo { get; set;}
        [StringLength(256)]
        public bool condicion { get; set; }
        //ESTA ES LA RELACION CON LA TABLA CATEGORIAS PARA HACER LA FK
        public List <Categoria> Categorias { get; set; }


    }
}
