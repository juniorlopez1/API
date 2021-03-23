
using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Negocios
{
    public interface IAeronaveService
    {
        void Crear(Aeronave aeronave);
        List<Aeronave> Leer();
        void Actualizar(Aeronave aeronave);
        void Eliminar(string Codigo);
        Aeronave Buscar(string Codigo);
        List<Aeronave> BuscarPorTipoAeronave(string Codigo);

    }

    public class AeronaveService : IAeronaveService
    {
        private readonly DatosAeronave accesoDatos;

        public AeronaveService(DatosAeronave accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }

        #region CRUD
        public void Crear (Aeronave aeronave)
        {
            accesoDatos.Crear(aeronave);
        }

        public List<Aeronave> Leer()
        {
            return accesoDatos.Leer();
        }

        public void Actualizar (Aeronave aeronave)
        {
            accesoDatos.Actualizar(aeronave);
        }

        public void Eliminar (string Codigo)
        {
            accesoDatos.Eliminar(Codigo);
        }

        #endregion


        public Aeronave Buscar (string Codigo)
        {
            return accesoDatos.Buscar(Codigo);
        }

        public List<Aeronave> BuscarPorTipoAeronave(string Codigo)
        {
            return accesoDatos.BuscarPorTipoAeronave(Codigo);
        }
        
    }
}
