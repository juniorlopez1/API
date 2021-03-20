using Acceso;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class DatosAeronave : AccesoDatosBase
    {

        #region Constructor
        public DatosAeronave (string cadenaConexion, string nombreBD)
    : base(cadenaConexion, nombreBD)
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
            Actualizar<Aeronave>(nameof(Aeronave), (u) => u.Id == u.Id, aeronave);
        }
        #endregion

        #region DELETE
        public void Eliminar(string id)
        {
            Eliminar<Aeronave>(nameof(Aeronave), (u) => u.Id == id);
        }
        #endregion

        #region SEARCH
        public Aeronave Buscar(string id)
        {
            return Buscar<Aeronave>(nameof(Aeronave), (u) => u.Id == id);
        }
        #endregion 


        #endregion
    }
}
