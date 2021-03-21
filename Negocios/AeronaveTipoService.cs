using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocios
{
    public interface IAeronaveTipoService
    {
        #region CREATE
        void Crear(AeronaveTipo aeronaveTipo);
        #endregion

        #region READ
        List<AeronaveTipo> Leer();
        #endregion

        #region UPDATE
        void Actualizar(AeronaveTipo aeronaveTipo);
        #endregion

        #region DELETE
        void Eliminar(string Codigo);
        #endregion

        #region SEARCH
        AeronaveTipo Buscar(string id);
        #endregion
    }

    public class AeronaveTipoService : IAeronaveTipoService
    {
        #region Members
        //Establece propiedades para acceso a datos
        private readonly DatosAeronaveTipo accesoDatos;
        #endregion

        #region Constructor
        //Inicializa el servicio
        public AeronaveTipoService(DatosAeronaveTipo accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }
        #endregion



        #region CREATE
        public void Crear(AeronaveTipo aeronaveTipo)
        {
            accesoDatos.Crear(aeronaveTipo);
        }
        #endregion

        #region READ
        public List<AeronaveTipo> Leer()
        {
            return accesoDatos.Leer();
        }
        #endregion

        #region UPDATE
        public void Actualizar(AeronaveTipo aeronaveTipo)
        {
            accesoDatos.Actualizar(aeronaveTipo);
        }
        #endregion

        #region DELETE
        public void Eliminar(string Codigo)
        {
            accesoDatos.Eliminar(Codigo);
        }
        #endregion

        #region SEARCH
        public AeronaveTipo Buscar(string Codigo)
        {
            return accesoDatos.Buscar(Codigo);
        }
        #endregion
    }
}
