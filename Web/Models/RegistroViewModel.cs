using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class RegistroViewModel
    {
        public string Id { get; set; }

        public DateTime Ingreso { get; set; }

        public DateTime Salida { get; set; }
        public string Codigo { get; set; }

        //Otras entidades
        public AeronaveViewModel Aeronave { get; set; }

        public EstadoVueloViewModel EstadoVuelo { get; set; }

        public ObservacionViewModel Observacion { get; set; }

        public RegistroViewModel()
        {
            Aeronave = new AeronaveViewModel();
            EstadoVuelo = new EstadoVueloViewModel();
            Observacion = new ObservacionViewModel();
        }
    }
}
