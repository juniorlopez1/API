using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    public interface IapiEstadoVueloService
    {
        #region CREATE
        void Crear(EstadoVuelo EstadoVuelo);
        #endregion

        #region READ
        List<EstadoVuelo> Leer();
        #endregion

        #region UPDATE
        void Actualizar(EstadoVuelo EstadoVuelo);
        #endregion

        #region DELETE
        void Eliminar(string id);
        #endregion

        #region SEARCH
        EstadoVuelo Buscar(string id);
        #endregion
    }

    public class apiEstadoVueloService : IapiEstadoVueloService
    {
        #region Members
        //Establece propiedades para acceso a datos
        private readonly DatosEstadoVuelo accesoDatos;
        #endregion

        #region Constructor
        //Inicializa el servicio
        public apiEstadoVueloService(DatosEstadoVuelo accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }
        #endregion



        #region CREATE
        public void Crear(EstadoVuelo EstadoVuelo)
        {
            accesoDatos.Crear(EstadoVuelo);
        }
        #endregion

        #region READ
        public List<EstadoVuelo> Leer()
        {
            return accesoDatos.Leer();
        }
        #endregion

        #region UPDATE
        public void Actualizar(EstadoVuelo EstadoVuelo)
        {
            accesoDatos.Actualizar(EstadoVuelo);
        }
        #endregion

        #region DELETE
        public void Eliminar(string id)
        {
            accesoDatos.Eliminar(id);
        }
        #endregion

        #region SEARCH
        public EstadoVuelo Buscar(string id)
        {
            return accesoDatos.Buscar(id);
        }
        #endregion
    }
}
