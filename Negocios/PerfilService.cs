using Acceso;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    public class PerfilService : IPerfilService
    {
        #region Members
        //Establece propiedades para acceso a datos
        private readonly AccesoDatos accesoDatos;
        #endregion

        #region Constructor
        //Inicializa el servicio
        public PerfilService(AccesoDatos accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }
        #endregion



        #region CREATE
        public void CrearPerfiles (Pista perfil)
        {
            accesoDatos.CrearPerfiles (perfil);
        }
        #endregion

        #region READ
        public List<Pista> LeerPerfiles ()
        {
            return accesoDatos.LeerPerfiles();
        }
        #endregion

        #region UPDATE
        public void ActualizarPerfiles (Pista perfil)
        {
            accesoDatos.ActualizarPerfiles(perfil);
        }
        #endregion

        #region DELETE
        public void EliminarPerfiles (string Codigo)
        {
            accesoDatos.EliminarPerfiles(Codigo);
        }
        #endregion

        #region SEARCH
        public Pista BuscarPerfiles (string Codigo)
        {
            return accesoDatos.BuscarPerfiles(Codigo);
        }
        #endregion
    }









    //-------------------------Interfaz -------------------------
    public interface IPerfilService
    {
        //Metodos exponen el servicio atraves de la interfaz

        #region CREATE
        void CrearPerfiles (Pista perfil);
        #endregion

        #region READ
        List<Pista> LeerPerfiles ();
        #endregion

        #region UPDATE
        void ActualizarPerfiles (Pista perfil);
        #endregion

        #region DELETE
        void EliminarPerfiles (string Codigo);
        #endregion

        #region SEARCH
        Pista BuscarPerfiles (string Codigo);
        #endregion

    }
}

