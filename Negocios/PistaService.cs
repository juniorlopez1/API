using Acceso;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    //Consta del servicio e interfaz


    //-------------------------Servicio -------------------------
    public class PistaService : IPistaService
    {
        #region Members
        //Establece propiedades para acceso a datos
        private readonly AccesoDatos accesoDatos;
        #endregion

        #region Constructor
        //Inicializa el servicio
        public PistaService(AccesoDatos accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }
        #endregion



        #region CREATE
        public void CrearPistas (Pista pista)
        {
            accesoDatos.CrearPistas(pista);
        }
        #endregion

        #region READ
        public List<Pista> LeerPistas ()
        {
            return accesoDatos.LeerPistas();
        }
        #endregion

        #region UPDATE
        public void ActualizarPistas (Pista pista)
        {
            accesoDatos.ActualizarPistas(pista);
        }
        #endregion

        #region DELETE
        public void EliminarPistas (string Codigo)
        {
            accesoDatos.EliminarPistas(Codigo);
        }
        #endregion

        #region SEARCH
        public Pista BuscarPistas (string Codigo)
        {
            return accesoDatos.BuscarPistas(Codigo);
        }
        #endregion
    }









    //-------------------------Interfaz -------------------------
    public interface IPistaService
    {
        //Metodos exponen el servicio atraves de la interfaz

        #region CREATE
        void CrearPistas (Pista pista);
        #endregion

        #region READ
        List<Pista> LeerPistas ();
        #endregion

        #region UPDATE
        void ActualizarPistas (Pista pista);
        #endregion

        #region DELETE
        void EliminarPistas (string Codigo);
        #endregion

        #region SEARCH
        Pista BuscarPistas (string Codigo);
        #endregion

    }
}
