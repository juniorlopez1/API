using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocios
{
    public interface IAeronaveTipoService
    {
        void Crear(AeronaveTipo aeronaveTipo);
        List<AeronaveTipo> Leer();
        void Actualizar(AeronaveTipo aeronaveTipo);
        void Eliminar(string Codigo);
        AeronaveTipo Buscar(string id);
    }

    public class AeronaveTipoService : IAeronaveTipoService
    {

        private readonly DatosAeronaveTipo accesoDatos;

        public AeronaveTipoService(DatosAeronaveTipo accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }

        #region CRUD

        public void Crear(AeronaveTipo aeronaveTipo)
        {
            accesoDatos.Crear(aeronaveTipo);
        }

        public List<AeronaveTipo> Leer()
        {
            return accesoDatos.Leer();
        }

        public void Actualizar(AeronaveTipo aeronaveTipo)
        {
            accesoDatos.Actualizar(aeronaveTipo);
        }

        public void Eliminar(string Codigo)
        {
            accesoDatos.Eliminar(Codigo);
        }

        public AeronaveTipo Buscar(string Codigo)
        {
            return accesoDatos.Buscar(Codigo);
        } 
        #endregion

    }
}
