using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class DatosEstadoVuelo : AccesoDatosBase
    {
        #region Constructor
        public DatosEstadoVuelo(string cadenaConexion, string nombreBD)
    : base(cadenaConexion, nombreBD)
        {

        }
        #endregion

        #region CRUD


        #region CREATE
        public void Crear(EstadoVuelo EstadoVuelo)
        {
            Crear(nameof(EstadoVuelo), EstadoVuelo);
        }
        #endregion

        #region READ
        public List<EstadoVuelo> Leer()
        {
            return Leer<EstadoVuelo>(nameof(EstadoVuelo));
        }
        #endregion

        #region UPDATE
        public void Actualizar(EstadoVuelo EstadoVuelo)
        {
            var filter = Builders<EstadoVuelo>.Filter.Eq(x => x.Id, EstadoVuelo.Id);
            Actualizar<EstadoVuelo>(nameof(EstadoVuelo), filter, EstadoVuelo);
        }
        #endregion

        #region DELETE
        public void Eliminar(string id)
        {
            Eliminar<EstadoVuelo>(nameof(EstadoVuelo), (u) => u.Id == id);
        }
        #endregion

        #region SEARCH
        public EstadoVuelo Buscar(string id)
        {
            return Buscar<EstadoVuelo>(nameof(EstadoVuelo), (u) => u.Id == id);
        }
        #endregion 


        #endregion
    }
}
