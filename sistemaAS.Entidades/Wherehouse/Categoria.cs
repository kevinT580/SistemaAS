﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sistemaAS.Entidades.Wherehouse
{
    public class Categoria
    {
        public int idcategoria { get; set; }
        [Required]
        [StringLength(50,MinimumLength =3, ErrorMessage ="Error")]
        public string nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }

        public bool condicion { get; set; }
        List<Articulo> Articulos { get; set; }
    }
}
