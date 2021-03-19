using Acceso;
using Entidades;
using System;
using System.Collections.Generic;

namespace Negocios
{
    //Consta del servicio e interfaz


    //-------------------------Servicio -------------------------
    public class AeronaveService : IAeronaveService
    {
        #region Members
        //Establece propiedades para acceso a datos
        private readonly AccesoDatos accesoDatos;
        #endregion

        #region Constructor
        //Inicializa el servicio
        public AeronaveService (AccesoDatos accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }
        #endregion



        #region CREATE
        public void CrearAeronaves (Aeronave aeronave)
        {
            accesoDatos.CrearAeronaves(aeronave);
        }
        #endregion

        #region READ
        public List<Aeronave> LeerAeronaves()
        {
            return accesoDatos.LeerAeronaves();
        }
        #endregion

        #region UPDATE
        public void ActualizarAeronaves (Aeronave aeronave)
        {
            accesoDatos.ActualizarAeronaves(aeronave);
        }
        #endregion

        #region DELETE
        public void EliminarAeronaves (string Codigo)
        {
            accesoDatos.EliminarAeronaves(Codigo);
        }
        #endregion

        #region SEARCH
        public Aeronave BuscarAeronaves (string Codigo)
        {
            return accesoDatos.BuscarAeronaves(Codigo);
        }

        #endregion
    }









    //-------------------------Interfaz -------------------------
    public interface IAeronaveService
    {
        //Metodos exponen el servicio atraves de la interfaz

        #region CREATE
        void CrearAeronaves (Aeronave aeronave);
        #endregion

        #region READ
        List<Aeronave> LeerAeronaves();
        #endregion

        #region UPDATE
        void ActualizarAeronaves(Aeronave aeronave);
        #endregion

        #region DELETE
        void EliminarAeronaves(string Codigo);
        #endregion

        #region SEARCH
        Aeronave BuscarAeronaves(string Codigo);
        #endregion

    }
}
