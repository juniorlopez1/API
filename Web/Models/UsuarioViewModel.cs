using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }

        public string NombreUsuario { get; set; }

        public string Contrasena { get; set; }

        public bool Estado { get; set; }

        //Otras entidades
        public PerfilViewModel PerfilViewModel { get; set; }
    }
}
