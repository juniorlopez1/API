using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosObservacion : AccesoDatosBase
    {
        public DatosObservacion(string cadenaConexion, string nombreBD) : base(cadenaConexion, nombreBD)
        {
            //Hereda del base que establece todos los metodos de conexion
        }

        public void Crear(Observacion Observacion)
        {
            Crear(nameof(Observacion), Observacion);
        }

        public List<Observacion> Leer()
        {
            return Leer<Observacion>(nameof(Observacion));
        }

        public void Actualizar(Observacion Observacion)
        {
            var filter = Builders<Observacion>.Filter.Eq(x => x.Codigo, Observacion.Codigo);
            Actualizar<Observacion>(nameof(Observacion), filter, Observacion);
        }

        public void Eliminar(string Codigo)
        {
            var filter = Builders<Observacion>.Filter.Eq(x => x.Codigo, Codigo);
            Eliminar<Observacion>(nameof(Observacion), filter);
        }
   
        public Observacion Buscar(string Codigo)
        {
            return Buscar<Observacion>(nameof(Observacion), (u) => u.Codigo == Codigo).FirstOrDefault();
        }

    }
}
