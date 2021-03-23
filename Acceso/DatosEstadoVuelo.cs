using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosEstadoVuelo : AccesoDatosBase
    {
        public DatosEstadoVuelo(string cadenaConexion, string nombreBD) : base(cadenaConexion, nombreBD)
        {
            //Hereda del base que establece todos los metodos de conexion
        }

        public void Crear(EstadoVuelo EstadoVuelo)
        {
            Crear(nameof(EstadoVuelo), EstadoVuelo);
        }

        public List<EstadoVuelo> Leer()
        {
            return Leer<EstadoVuelo>(nameof(EstadoVuelo));
        }

        public void Actualizar(EstadoVuelo EstadoVuelo)
        {
            var filter = Builders<EstadoVuelo>.Filter.Eq(x => x.Codigo, EstadoVuelo.Codigo);
            Actualizar<EstadoVuelo>(nameof(EstadoVuelo), filter, EstadoVuelo);
        }

        public void Eliminar(string Codigo)
        {
            var filter = Builders<EstadoVuelo>.Filter.Eq(x => x.Codigo, Codigo);
            Eliminar<EstadoVuelo>(nameof(EstadoVuelo), filter);
        }

        public EstadoVuelo Buscar(string Codigo)
        {
            return Buscar<EstadoVuelo>(nameof(EstadoVuelo), (u) => u.Codigo == Codigo).FirstOrDefault();
        }

        public List<EstadoVuelo> BuscarPorEstadoVuelo(string codigo)
        {
            return Buscar<EstadoVuelo>(nameof(EstadoVuelo), (u) => u.Codigo == codigo);
        }

    }
}
