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

        //Otras entidades
        public AeronaveViewModel AeronaveViewModel { get; set; }

        public EstadoVueloViewModel EstadoVueloViewModel { get; set; }

        public ObservacionViewModel ObservacionViewModel { get; set; }
    }
}
