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
        public void CrearPerfiles (Perfil perfil)
        {
            accesoDatos.CrearPerfiles (perfil);
        }
        #endregion

        #region READ
        public List<Perfil> LeerPerfiles ()
        {
            return accesoDatos.LeerPerfiles();
        }
        #endregion

        #region UPDATE
        public void ActualizarPerfiles (Perfil perfil)
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
        public Perfil BuscarPerfiles (string Codigo)
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
        void CrearPerfiles (Perfil perfil);
        #endregion

        #region READ
        List<Perfil> LeerPerfiles ();
        #endregion

        #region UPDATE
        void ActualizarPerfiles (Perfil perfil);
        #endregion

        #region DELETE
        void EliminarPerfiles (string Codigo);
        #endregion

        #region SEARCH
        Perfil BuscarPerfiles (string Codigo);
        #endregion

    }
}

