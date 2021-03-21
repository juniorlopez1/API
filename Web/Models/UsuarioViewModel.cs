using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Contrasena { get; set; }

        public bool Estado { get; set; }

        //Otras entidades
        public PerfilViewModel Perfil { get; set; }
    }
}
