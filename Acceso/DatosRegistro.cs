using Acceso;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class DatosRegistro : AccesoDatosBase
    {
        #region Constructor
        public DatosRegistro(string cadenaConexion, string nombreBD)
    : base(cadenaConexion, nombreBD)
        {

        }
        #endregion

        #region CRUD


        #region CREATE
        public void Crear(Registro Registro)
        {
            Crear(nameof(Registro), Registro);
        }
        #endregion

        #region READ
        public List<Registro> Leer()
        {
            return Leer<Registro>(nameof(Registro));
        }
        #endregion

        #region UPDATE
        public void Actualizar(Registro Registro)
        {
            var filter = Builders<Registro>.Filter.Eq(x => x.Codigo, Registro.Codigo);
            Actualizar<Registro>(nameof(Registro), filter, Registro);
        }
        #endregion

        #region DELETE
        public void Eliminar(string Codigo)
        {
            Eliminar<Registro>(nameof(Registro), (u) => u.Codigo == Codigo);
        }
        #endregion

        #region SEARCH
        public Registro Buscar(string Codigo)
        {
            return Buscar<Registro>(nameof(Registro), (u) => u.Codigo == Codigo);
        }
        #endregion 


        #endregion
    }
}
