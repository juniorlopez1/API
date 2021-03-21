using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class DatosAeronave : AccesoDatosBase
    {

        #region Constructor
        public DatosAeronave (string cadenaConexion, string nombreBD) : base(cadenaConexion, nombreBD)
        {

        }
        #endregion

        #region CRUD


        #region CREATE
        public void Crear(Aeronave Aeronave)
        {
            Crear(nameof(Aeronave), Aeronave);
        }
        #endregion

        #region READ
        public List<Aeronave> Leer()
        {
            return Leer<Aeronave>(nameof(Aeronave));
        }
        #endregion

        #region UPDATE
        public void Actualizar(Aeronave aeronave)
        {
            var filter = Builders<Aeronave>.Filter.Eq(x => x.Codigo, aeronave.Codigo);
            Actualizar<Aeronave>(nameof(Aeronave), filter, aeronave);
        }
        #endregion

        #region DELETE
        public void Eliminar(string Codigo)
        {
            Eliminar<Aeronave>(nameof(Aeronave), (u) => u.Codigo == Codigo);
        }
        #endregion

        #region SEARCH
        public Aeronave Buscar(string Codigo)
        {
            return Buscar<Aeronave>(nameof(Aeronave), (u) => u.Codigo == Codigo);
        }
        #endregion 


        #endregion
    }
}
