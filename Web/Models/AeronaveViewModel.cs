using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class AeronaveViewModel
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public int Capacidad { get; set; }

        //Otras entidades
        public AeronaveTipoViewModel AeronaveTipoViewModel { get; set; }
    }
}
