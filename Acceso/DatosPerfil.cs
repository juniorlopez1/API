using Acceso;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class DatosPerfil : AccesoDatosBase
    {

        #region Constructor
        public DatosPerfil(string cadenaConexion, string nombreBD)
    : base(cadenaConexion, nombreBD)
        {

        }
        #endregion

        #region CRUD


        #region CREATE
        public void Crear(Perfil Perfil)
        {
            Crear(nameof(Perfil), Perfil);
        }
        #endregion

        #region READ
        public List<Perfil> Leer()
        {
            return Leer<Perfil>(nameof(Perfil));
        }
        #endregion

        #region UPDATE
        public void Actualizar(Perfil Perfil)
        {
            Actualizar<Perfil>(nameof(Perfil), (u) => u.Id == u.Id, Perfil);
        }
        #endregion

        #region DELETE
        public void Eliminar(string id)
        {
            Eliminar<Perfil>(nameof(Perfil), (u) => u.Id == id);
        }
        #endregion

        #region SEARCH
        public Perfil Buscar(string id)
        {
            return Buscar<Perfil>(nameof(Perfil), (u) => u.Id == id);
        }
        #endregion 


        #endregion

    }
}
