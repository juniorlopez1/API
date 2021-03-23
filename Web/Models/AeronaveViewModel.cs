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

        [Required(ErrorMessage = "Requerido")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Requerido")]
        public int Capacidad { get; set; }

        public bool Estado { get; set; }

        //!
        public bool Observacion { get; set; }

        //!
        public bool Desperfecto { get; set; }


        //Otras entidades
        public AeronaveTipoViewModel AeronaveTipo { get; set; }

        public AeronaveViewModel()
        {
            AeronaveTipo = new AeronaveTipoViewModel();
        }
    }
}
