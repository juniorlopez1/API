using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosUsuario : AccesoDatosBase
    {
        public DatosUsuario(string cadenaConexion, string nombreBD) : base(cadenaConexion, nombreBD)
        {
            //Hereda del base que establece todos los metodos de conexion
        }
        

        public void Crear(Usuario Usuario)
        {
            Crear(nameof(Usuario), Usuario);
        }

        public List<Usuario> Leer()
        {
            return Leer<Usuario>(nameof(Usuario));
        }

        public void Actualizar(Usuario Usuario)
        {
            var filter = Builders<Usuario>.Filter.Eq(x => x.Codigo, Usuario.Codigo);
            Actualizar<Usuario>(nameof(Usuario), filter, Usuario);
        }

        public void Eliminar(string Codigo)
        {
            var filter = Builders<Usuario>.Filter.Eq(x => x.Codigo, Codigo);
            Eliminar<Usuario>(nameof(Usuario), filter);
        }

        public Usuario Buscar(string Codigo)
        {
            return Buscar<Usuario>(nameof(Usuario), (u) => u.Codigo == Codigo).FirstOrDefault();
        }

        public Usuario BuscarPorNombreUsuarioContrasena(string nombreUsuario, string contrasenna)
        {
            return Buscar<Usuario>(nameof(Usuario), (u) => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasenna).FirstOrDefault();
        }

        public Usuario BuscarEstadoUsuario (string estadoUsuario)
        {
            return Buscar<Usuario>(nameof(Usuario), (u) => u.Estado  ).FirstOrDefault();
        }

        public Usuario BuscarPorNombreUsuario(string nombreUsuario)
        {
            return Buscar<Usuario>(nameof(Usuario), (u) => u.NombreUsuario == nombreUsuario).FirstOrDefault();
        }

        public Usuario BuscarPorId(string id)
        {
            return Buscar<Usuario>(nameof(Usuario), (u) => u.Id == id).FirstOrDefault();
        }

        public List<Usuario> BuscarPorEstado(bool estado)
        {
            return Buscar<Usuario>(nameof(Usuario), (u) => u.Estado == estado).ToList();
        }
    }
}
