
using Datos;
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
        private readonly DatosAeronave accesoDatos;
        #endregion

        #region Constructor
        //Inicializa el servicio
        public AeronaveService(DatosAeronave accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }
        #endregion



        #region CREATE
        public void Crear (Aeronave aeronave)
        {
            accesoDatos.Crear(aeronave);
        }
        #endregion

        #region READ
        public List<Aeronave> Leer()
        {
            return accesoDatos.Leer();
        }
        #endregion

        #region UPDATE
        public void Actualizar (Aeronave aeronave)
        {
            accesoDatos.Actualizar(aeronave);
        }
        #endregion

        #region DELETE
        public void Eliminar (string Codigo)
        {
            accesoDatos.Eliminar(Codigo);
        }
        #endregion

        #region SEARCH
        public Aeronave Buscar (string Codigo)
        {
            return accesoDatos.Buscar(Codigo);
        }

        public List<Aeronave> BuscarPorTipoAeronave(string Codigo)
        {
            return accesoDatos.BuscarPorTipoAeronave(Codigo);
        }
        #endregion
    }









    //-------------------------Interfaz -------------------------
    public interface IAeronaveService
    {
        //Metodos exponen el servicio atraves de la interfaz

        #region CREATE
        void Crear (Aeronave aeronave);
        #endregion

        #region READ
        List<Aeronave> Leer();
        #endregion

        #region UPDATE
        void Actualizar(Aeronave aeronave);
        #endregion

        #region DELETE
        void Eliminar(string Codigo);
        #endregion

        #region SEARCH
        Aeronave Buscar(string Codigo);
        List<Aeronave> BuscarPorTipoAeronave(string Codigo);
        #endregion

    }
}
