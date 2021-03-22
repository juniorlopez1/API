using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    public interface IRegistroService
    {

        void Crear(Registro Registro);
        List<Registro> Leer();
        void Actualizar(Registro Registro);
        void Eliminar(string Codigo);
        Registro Buscar(string Codigo);
    }

    public class RegistroService : IRegistroService
    {
        private readonly DatosRegistro accesoDatos;
        public RegistroService(DatosRegistro accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }


        #region CRUD

        public void Crear(Registro Registro)
        {
            accesoDatos.Crear(Registro);
        }
        public List<Registro> Leer()
        {
            return accesoDatos.Leer();
        }
        public void Actualizar(Registro Registro)
        {
            accesoDatos.Actualizar(Registro);
        }
        public void Eliminar(string Codigo)
        {
            accesoDatos.Eliminar(Codigo);
        }
        public Registro Buscar(string Codigo)
        {
            return accesoDatos.Buscar(Codigo);
        } 
        #endregion

    }
}

