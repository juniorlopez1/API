using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class AeronaveViewModel
    {
        public string Id { get; set; }

        [Required (ErrorMessage ="Requerido")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Requerido")]
        public int Capacidad { get; set; }

        //Otras entidades
        public AeronaveTipoViewModel AeronaveTipoViewModel { get; set; }
    }
}
