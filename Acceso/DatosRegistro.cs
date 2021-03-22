using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosRegistro : AccesoDatosBase
    {
        public DatosRegistro(string cadenaConexion, string nombreBD) : base(cadenaConexion, nombreBD)
        {
            //Hereda del base que establece todos los metodos de conexion
        }


        public void Crear(Registro Registro)
        {
            Crear(nameof(Registro), Registro);
        }

        public List<Registro> Leer()
        {
            return Leer<Registro>(nameof(Registro));
        }

        public void Actualizar(Registro Registro)
        {
            var filter = Builders<Registro>.Filter.Eq(x => x.Codigo, Registro.Codigo);
            Actualizar<Registro>(nameof(Registro), filter, Registro);
        }
 
        public void Eliminar(string Codigo)
        {
            Eliminar<Registro>(nameof(Registro), (u) => u.Codigo == Codigo);
        }

        public Registro Buscar(string Codigo)
        {
            return Buscar<Registro>(nameof(Registro), (u) => u.Codigo == Codigo).FirstOrDefault();
        }

    }
}
