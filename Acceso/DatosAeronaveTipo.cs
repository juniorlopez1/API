using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class DatosAeronaveTipo : AccesoDatosBase
    {
        #region Constructor
        public DatosAeronaveTipo(string cadenaConexion, string nombreBD)
    : base(cadenaConexion, nombreBD)
        {

        }
        #endregion

        #region CRUD


        #region CREATE
        public void Crear(AeronaveTipo aeronaveTipo)
        {
            Crear(nameof(AeronaveTipo), aeronaveTipo);
        }
        #endregion

        #region READ
        public List<AeronaveTipo> Leer()
        {
            return Leer<AeronaveTipo>(nameof(AeronaveTipo));
        }
        #endregion

        #region UPDATE
        public void Actualizar(AeronaveTipo aeronaveTipo)
        {
            var filter = Builders<AeronaveTipo>.Filter.Eq(x => x.Id, aeronaveTipo.Id);
            Actualizar<AeronaveTipo>(nameof(AeronaveTipo), filter, aeronaveTipo);
        }
        #endregion

        #region DELETE
        public void Eliminar(string id)
        {
            Eliminar<AeronaveTipo>(nameof(AeronaveTipo), (u) => u.Id == id);
        }
        #endregion

        #region SEARCH
        public AeronaveTipo Buscar(string id)
        {
            return Buscar<AeronaveTipo>(nameof(AeronaveTipo), (u) => u.Id == id);
        }
        #endregion 


        #endregion
    }
}
