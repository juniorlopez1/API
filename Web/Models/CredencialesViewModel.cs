using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CredencialesViewModel
    {
        [Required( ErrorMessage = "Requerido")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Requerido")]
        public string Contrasena { get; set; }
    }
}
