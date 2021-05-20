using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace sistemaAS.Entidades.Users
{
    public class Person
    {
        public int idPersona { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="ERROR DATOS")]
        public string tipoPersona { get; set; }
        [StringLength(20)]
        public string primerNombre { get; set; }
        [StringLength(100)]
        public string segundoNombre { get; set; }
        [StringLength(100)]
        public string tercerNombre { get; set; }
        [StringLength(100)]
        public string primerApellido { get; set; }
        [StringLength(100)]
        public string segundoApellido { get; set; }
        [StringLength(100)]
        public string tercerApellido { get; set; }
        [StringLength(100)]
        public string tipoDocumento { get; set; }
        [StringLength(50)]
        public string numDocumento { get; set; }
        [StringLength(70)]
        public string telefonoPersona { get; set; }
        [StringLength(20)]
        public string email { get; set; }
    }
}
