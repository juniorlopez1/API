using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class DatosUsuario : AccesoDatosBase
    {
        #region Constructor
        public DatosUsuario(string cadenaConexion, string nombreBD)
    : base(cadenaConexion, nombreBD)
        {

        }
        #endregion

        #region CRUD


        #region CREATE
        public void Crear(Usuario Usuario)
        {
            Crear(nameof(Usuario), Usuario);
        }
        #endregion

        #region READ
        public List<Usuario> Leer()
        {
            return Leer<Usuario>(nameof(Usuario));
        }
        #endregion

        #region UPDATE
        public void Actualizar(Usuario Usuario)
        {
            var filter = Builders<Usuario>.Filter.Eq(x => x.Id, Usuario.Id);
            Actualizar<Usuario>(nameof(Usuario), filter, Usuario);
        }
        #endregion

        #region DELETE
        public void Eliminar(string id)
        {
            Eliminar<Usuario>(nameof(Usuario), (u) => u.Id == id);
        }
        #endregion

        #region SEARCH
        public Usuario Buscar(string id)
        {
            return Buscar<Usuario>(nameof(Usuario), (u) => u.Id == id);
        }
        #endregion 


        #endregion
    }
}
