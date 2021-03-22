using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    public interface IPerfilService
    {
        void Crear(Perfil Perfil);
        List<Perfil> Leer();
        void Actualizar(Perfil Perfil);
        void Eliminar(string Codigo);
        Perfil Buscar(string Codigo);

    }

    public class PerfilService : IPerfilService
    {

        private readonly DatosPerfil accesoDatos;

        public PerfilService(DatosPerfil accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }

        #region CRUD
        public void Crear(Perfil Perfil)
        {
            accesoDatos.Crear(Perfil);
        }

        public List<Perfil> Leer()
        {
            return accesoDatos.Leer();
        }

        public void Actualizar(Perfil Perfil)
        {
            accesoDatos.Actualizar(Perfil);
        }

        public void Eliminar(string Codigo)
        {
            accesoDatos.Eliminar(Codigo);
        }

        public Perfil Buscar(string Codigo)
        {
            return accesoDatos.Buscar(Codigo);
        } 
        #endregion

    }


}
