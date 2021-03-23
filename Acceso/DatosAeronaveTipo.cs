using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosAeronaveTipo : AccesoDatosBase
    {
        public DatosAeronaveTipo(string cadenaConexion, string nombreBD) : base(cadenaConexion, nombreBD)
        {
            //Hereda del base que establece todos los metodos de conexion
        }

        public void Crear(AeronaveTipo aeronaveTipo)
        {
            Crear(nameof(AeronaveTipo), aeronaveTipo);
        }

        public List<AeronaveTipo> Leer()
        {
            return Leer<AeronaveTipo>(nameof(AeronaveTipo));
        }

        public void Actualizar(AeronaveTipo aeronaveTipo)
        {
            var filter = Builders<AeronaveTipo>.Filter.Eq(x => x.Codigo, aeronaveTipo.Codigo);
            Actualizar<AeronaveTipo>(nameof(AeronaveTipo), filter, aeronaveTipo);
        }

        public void Eliminar(string Codigo)
        {
            var filter = Builders<AeronaveTipo>.Filter.Eq(x => x.Codigo, Codigo);
            Eliminar<AeronaveTipo>(nameof(AeronaveTipo), filter);
        }

        public AeronaveTipo Buscar(string Codigo)
        {
            return Buscar<AeronaveTipo>(nameof(AeronaveTipo), (u) => u.Codigo == Codigo).FirstOrDefault();
        }

    }
}
