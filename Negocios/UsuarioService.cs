using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    public interface IUsuarioService
    {
        void Crear(Usuario Usuario);
        List<Usuario> Leer();
        void Actualizar(Usuario Usuario);
        void Eliminar(string Codigo);
        Usuario Buscar(string Codigo);
        Usuario BuscarPonombreUsuarioContrasena(string nombreUsuario, string contrasenna);
        Usuario BuscarPorNombreUsuario(string nombreUsuario);
        Usuario BuscarPorId(string id);
        List<Usuario> BuscarPorEstado(bool estado);
    }

    public class UsuarioService : IUsuarioService
    {

        private readonly DatosUsuario accesoDatos;

        public UsuarioService (DatosUsuario accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }


        #region CRUD

        public void Crear(Usuario Usuario)
        {
            accesoDatos.Crear(Usuario);
        }
        public List<Usuario> Leer()
        {
            return accesoDatos.Leer();
        }
        public void Actualizar(Usuario Usuario)
        {
            accesoDatos.Actualizar(Usuario);
        }
        public void Eliminar(string Codigo)
        {
            accesoDatos.Eliminar(Codigo);
        }

        #endregion


        public Usuario Buscar(string Codigo)
        {
            return accesoDatos.Buscar(Codigo);
        }

        public Usuario BuscarPonombreUsuarioContrasena(string nombreUsuario, string contrasenna)
        {
            return accesoDatos.BuscarPorNombreUsuarioContrasena(nombreUsuario, contrasenna);
        }

        public Usuario BuscarEstadoUsuario(string estadoUsuario)
        {
            return accesoDatos.BuscarEstadoUsuario(estadoUsuario);
        }

        public Usuario BuscarPorNombreUsuario(string nombreUsuario)
        {
            return accesoDatos.BuscarPorNombreUsuario(nombreUsuario);
        }

        public Usuario BuscarPorId(string id)
        {
            return accesoDatos.BuscarPorId(id);
        }

        public List<Usuario> BuscarPorEstado(bool estado)
        {
            return accesoDatos.BuscarPorEstado(estado);
        }
    }



}

