using Acceso;
using Entidades;
using System.Collections.Generic;

namespace Negocios
{

    //Consta del servicio e interfaz


    //-------------------------Servicio -------------------------
    public class VueloService : IVueloService
    {
        #region Members
        //Establece propiedades para acceso a datos
        private readonly AccesoDatos accesoDatos;
        #endregion

        #region Constructor
        //Inicializa el servicio
        public VueloService(AccesoDatos accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }
        #endregion



        #region CREATE
        public void CrearVuelos (Vuelo vuelo)
        {
            accesoDatos.CrearVuelos(vuelo);
        }
        #endregion

        #region READ
        public List<Vuelo> LeerVuelos ()
        {
            return accesoDatos.LeerVuelos();
        }
        #endregion

        #region UPDATE
        public void ActualizarVuelos (Vuelo vuelo)
        {
            accesoDatos.ActualizarVuelos(vuelo);
        }
        #endregion

        #region DELETE
        public void EliminarVuelos (string Codigo)
        {
            accesoDatos.EliminarVuelos(Codigo);
        }
        #endregion

        #region SEARCH
        public Vuelo BuscarVuelos (string Codigo)
        {
            return accesoDatos.BuscarVuelos(Codigo);
        }
        #endregion
    }









    //-------------------------Interfaz -------------------------
    public interface IVueloService
    {
        //Metodos exponen el servicio atraves de la interfaz

        #region CREATE
        void CrearVuelos (Vuelo vuelo);
        #endregion

        #region READ
        List<Vuelo> LeerVuelos ();
        #endregion

        #region UPDATE
        void ActualizarVuelos (Vuelo vuelo);
        #endregion

        #region DELETE
        void EliminarVuelos (string Codigo);
        #endregion

        #region SEARCH
        Vuelo BuscarVuelos (string Codigo);
        #endregion

    }
}

