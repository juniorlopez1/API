using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    //Consta del servicio e interfaz


    //-------------------------Servicio -------------------------
    public class UsuarioService : IUsuarioService
    {
        #region Members
        //Establece propiedades para acceso a datos
        private readonly DatosUsuario accesoDatos;
        #endregion

        #region Constructor
        //Inicializa el servicio
        public UsuarioService (DatosUsuario accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }
        #endregion



        #region CREATE
        public void Crear(Usuario Usuario)
        {
            accesoDatos.Crear(Usuario);
        }
        #endregion

        #region READ
        public List<Usuario> Leer()
        {
            return accesoDatos.Leer();
        }
        #endregion

        #region UPDATE
        public void Actualizar(Usuario Usuario)
        {
            accesoDatos.Actualizar(Usuario);
        }
        #endregion

        #region DELETE
        public void Eliminar(string Codigo)
        {
            accesoDatos.Eliminar(Codigo);
        }
        #endregion

        #region SEARCH
        public Usuario Buscar(string Codigo)
        {
            return accesoDatos.Buscar(Codigo);
        }
        #endregion
    }









    //-------------------------Interfaz -------------------------
    public interface IUsuarioService
    {
        //Metodos exponen el servicio atraves de la interfaz

        #region CREATE
        void Crear(Usuario Usuario);
        #endregion

        #region READ
        List<Usuario> Leer();
        #endregion

        #region UPDATE
        void Actualizar(Usuario Usuario);
        #endregion

        #region DELETE
        void Eliminar(string Codigo);
        #endregion

        #region SEARCH
        Usuario Buscar(string Codigo);
        #endregion

    }
}

