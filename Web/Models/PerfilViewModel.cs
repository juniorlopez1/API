using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class PerfilViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Tipo { get; set; }

        public bool Estado { get; set; }
    }
}
