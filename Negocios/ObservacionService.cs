using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    public interface IObservacionService
    {
        void Crear(Observacion Observacion);
        List<Observacion> Leer();
        void Actualizar(Observacion Observacion);
        void Eliminar(string id);
        Observacion Buscar(string id);
    }

    public class ObservacionService : IObservacionService
    {

        private readonly DatosObservacion accesoDatos;

        public ObservacionService (DatosObservacion accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }


        #region CRUD
        public void Crear(Observacion Observacion)
        {
            accesoDatos.Crear(Observacion);
        }
        public List<Observacion> Leer()
        {
            return accesoDatos.Leer();
        }
        public void Actualizar(Observacion Observacion)
        {
            accesoDatos.Actualizar(Observacion);
        }

        public void Eliminar(string Codigo)
        {
            accesoDatos.Eliminar(Codigo);
        }

        public Observacion Buscar(string Codigo)
        {
            return accesoDatos.Buscar(Codigo);
        }

        #endregion
    }
}
