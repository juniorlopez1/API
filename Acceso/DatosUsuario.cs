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
            Eliminar<Usuario>(nameof(Usuario), (u) => u.Codigo == Codigo);
        }

        public Usuario Buscar(string Codigo)
        {
            return Buscar<Usuario>(nameof(Usuario), (u) => u.Codigo == Codigo).FirstOrDefault();
        }

        public Usuario BuscarPorNombreUsuarioContrasena(string nombreUsuario, string contrasenna)
        {
            return Buscar<Usuario>(nameof(Usuario), (u) => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasenna).FirstOrDefault();
        }

    }
}
