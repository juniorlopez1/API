using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class DatosAeronave : AccesoDatosBase
    {
        public DatosAeronave(string cadenaConexion, string nombreBD) : base(cadenaConexion, nombreBD)
        {
            //Hereda del base que establece todos los metodos de conexion
        }

        public void Crear(Aeronave Aeronave)
        {
            Crear(nameof(Aeronave), Aeronave);
        }

        public List<Aeronave> Leer()
        {
            return Leer<Aeronave>(nameof(Aeronave));
        }

        public void Actualizar(Aeronave aeronave)
        {
            var filter = Builders<Aeronave>.Filter.Eq(x => x.Codigo, aeronave.Codigo);
            Actualizar<Aeronave>(nameof(Aeronave), filter, aeronave);
        }
  
        public void Eliminar(string Codigo)
        {
            var filter = Builders<Aeronave>.Filter.Eq(x => x.Codigo, Codigo);
            Eliminar<Aeronave>(nameof(Aeronave), filter);
        }

        public Aeronave Buscar(string Codigo)
        {
            return Buscar<Aeronave>(nameof(Aeronave), (u) => u.Codigo == Codigo).FirstOrDefault();
        }

        public List<Aeronave> BuscarPorTipoAeronave(string codigo)
        {
            return Buscar<Aeronave>(nameof(Aeronave), (u) => u.AeronaveTipo.Codigo == codigo);
        }

    }
}
