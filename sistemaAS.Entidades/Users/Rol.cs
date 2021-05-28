using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace sistemaAS.Entidades.Users
{
    public class Rol
    {
       public int idRol { get; set; }
       [Required]
       [StringLength(50, MinimumLength =3, ErrorMessage = "DATO INCORRECTO")]
       public string nombreRol { get; set; }
        [StringLength(50)]
        public string descripcionRol { get; set; }
        [StringLength(100)]
        public bool condicion { get; set; }
    }
}
