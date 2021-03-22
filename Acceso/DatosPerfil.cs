using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosPerfil : AccesoDatosBase
    {
        public DatosPerfil(string cadenaConexion, string nombreBD) : base(cadenaConexion, nombreBD)
        {
            //Hereda del base que establece todos los metodos de conexion
        }

        public void Crear(Perfil Perfil)
        {
            Crear(nameof(Perfil), Perfil);
        }

        public List<Perfil> Leer()
        {
            return Leer<Perfil>(nameof(Perfil));
        }

        public void Actualizar(Perfil Perfil)
        {
            var filter = Builders<Perfil>.Filter.Eq(x => x.Codigo, Perfil.Codigo);
            Actualizar<Perfil>(nameof(Perfil), filter, Perfil);
        }

        public void Eliminar(string Codigo)
        {
            Eliminar<Perfil>(nameof(Perfil), (u) => u.Codigo == Codigo);
        }

        public Perfil Buscar(string Codigo)
        {
            return Buscar<Perfil>(nameof(Perfil), (u) => u.Codigo == Codigo).FirstOrDefault();
        }

    }
}
