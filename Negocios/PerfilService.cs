using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    //Consta del servicio e interfaz


    //-------------------------Servicio -------------------------
    public class PerfilService : IPerfilService
    {
        #region Members
        //Establece propiedades para acceso a datos
        private readonly DatosPerfil accesoDatos;
        #endregion

        #region Constructor
        //Inicializa el servicio
        public PerfilService(DatosPerfil accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }
        #endregion



        #region CREATE
        public void Crear(Perfil Perfil)
        {
            accesoDatos.Crear(Perfil);
        }
        #endregion

        #region READ
        public List<Perfil> Leer()
        {
            return accesoDatos.Leer();
        }
        #endregion

        #region UPDATE
        public void Actualizar(Perfil Perfil)
        {
            accesoDatos.Actualizar(Perfil);
        }
        #endregion

        #region DELETE
        public void Eliminar(string Codigo)
        {
            accesoDatos.Eliminar(Codigo);
        }
        #endregion

        #region SEARCH
        public Perfil Buscar(string Codigo)
        {
            return accesoDatos.Buscar(Codigo);
        }
        #endregion
    }









    //-------------------------Interfaz -------------------------
    public interface IPerfilService
    {
        //Metodos exponen el servicio atraves de la interfaz

        #region CREATE
        void Crear(Perfil Perfil);
        #endregion

        #region READ
        List<Perfil> Leer();
        #endregion

        #region UPDATE
        void Actualizar(Perfil Perfil);
        #endregion

        #region DELETE
        void Eliminar(string Codigo);
        #endregion

        #region SEARCH
        Perfil Buscar(string Codigo);
        #endregion

    }
}
