using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    public interface IEstadoVueloService
    {
        void Crear(EstadoVuelo EstadoVuelo);
        List<EstadoVuelo> Leer();
        void Actualizar(EstadoVuelo EstadoVuelo);
        void Eliminar(string id);
        EstadoVuelo Buscar(string id);
        EstadoVuelo BuscarEstadoVuelo(string Codigo);

    }

    public class EstadoVueloService : IEstadoVueloService
    {
        //Establece propiedades para acceso a datos
        private readonly DatosEstadoVuelo accesoDatos;

        public EstadoVueloService(DatosEstadoVuelo accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }
        #region CRUD

        public void Crear(EstadoVuelo EstadoVuelo)
        {
            accesoDatos.Crear(EstadoVuelo);
        }

        public List<EstadoVuelo> Leer()
        {
            return accesoDatos.Leer();
        }

        public void Actualizar(EstadoVuelo EstadoVuelo)
        {
            accesoDatos.Actualizar(EstadoVuelo);
        }

        public void Eliminar(string Codigo)
        {
            accesoDatos.Eliminar(Codigo);
        }
        #endregion

        public EstadoVuelo Buscar(string Codigo)
        {
            return accesoDatos.Buscar(Codigo);
        }

        public EstadoVuelo BuscarEstadoVuelo(string Descripcion)
        {
            return accesoDatos.Buscar(Descripcion);
        }


    }
}
