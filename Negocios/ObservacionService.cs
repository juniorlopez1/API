using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    public interface IObservacionService
    {
        #region CREATE
        void Crear(Observacion Observacion);
        #endregion

        #region READ
        List<Observacion> Leer();
        #endregion

        #region UPDATE
        void Actualizar(Observacion Observacion);
        #endregion

        #region DELETE
        void Eliminar(string id);
        #endregion

        #region SEARCH
        Observacion Buscar(string id);
        #endregion
    }

    public class ObservacionService : IObservacionService
    {
        #region Members
        //Establece propiedades para acceso a datos
        private readonly DatosObservacion accesoDatos;
        #endregion

        #region Constructor
        //Inicializa el servicio
        public ObservacionService (DatosObservacion accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }
        #endregion



        #region CREATE
        public void Crear(Observacion Observacion)
        {
            accesoDatos.Crear(Observacion);
        }
        #endregion

        #region READ
        public List<Observacion> Leer()
        {
            return accesoDatos.Leer();
        }
        #endregion

        #region UPDATE
        public void Actualizar(Observacion Observacion)
        {
            accesoDatos.Actualizar(Observacion);
        }
        #endregion

        #region DELETE
        public void Eliminar(string Codigo)
        {
            accesoDatos.Eliminar(Codigo);
        }
        #endregion

        #region SEARCH
        public Observacion Buscar(string Codigo)
        {
            return accesoDatos.Buscar(Codigo);
        }
        #endregion
    }
}
