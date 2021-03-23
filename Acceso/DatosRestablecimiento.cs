using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosRestablecimiento : AccesoDatosBase
    {
        public DatosRestablecimiento(string cadenaConexion, string nombreBD) 
            : base(cadenaConexion, nombreBD)
        {
        }

        public void Crear(Restablecimiento restablecimiento)
        {
            Crear(nameof(Restablecimiento), restablecimiento);
        }

        public Restablecimiento Buscar(string codigo)
        {
            return Buscar<Restablecimiento>(nameof(Restablecimiento), (u) => u.Codigo == codigo).FirstOrDefault();
        }

        public void Eliminar(string codigo)
        {
            var filter = Builders<Restablecimiento>.Filter.Eq(x => x.Codigo, codigo);
            Eliminar(nameof(Restablecimiento), filter);
        }
    }
}
