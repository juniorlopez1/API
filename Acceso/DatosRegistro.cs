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
            var filter = Builders<Registro>.Filter.Eq(x => x.Id, Registro.Id);
            Actualizar<Registro>(nameof(Registro), filter, Registro);
        }
        #endregion

        #region DELETE
        public void Eliminar(string id)
        {
            Eliminar<Registro>(nameof(Registro), (u) => u.Id == id);
        }
        #endregion

        #region SEARCH
        public Registro Buscar(string id)
        {
            return Buscar<Registro>(nameof(Registro), (u) => u.Id == id);
        }
        #endregion 


        #endregion
    }
}
