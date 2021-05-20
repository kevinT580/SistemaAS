using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace sistemaAS.Entidades.Users
{
   public class Usuario
    {
        public int idUsuario { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage ="DATOS ERRONEOS")]
        public int idRol { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage = "DATOS ERRONEOS")]
        public string nombreUsuario { get; set; }
        [StringLength(100)]
        public string tipoDocumento { get; set; }
        [StringLength(20)]
        public string numDocumento { get; set; }
        [StringLength(20)]
        public string direccion { get; set; }
        [StringLength(70)]
        public string telefono { get; set; }
        [StringLength(20)]
        public string email { get; set; }
        [StringLength(50)]
        public string password_hash { get; set; }
        public string password_sal { get; set; }
        public string condicion { get; set; }
    }
}
