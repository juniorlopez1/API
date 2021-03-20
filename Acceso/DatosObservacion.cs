﻿using Acceso;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class DatosObservacion : AccesoDatosBase
    {
        #region Constructor
        public DatosObservacion(string cadenaConexion, string nombreBD)
    : base(cadenaConexion, nombreBD)
        {

        }
        #endregion

        #region CRUD


        #region CREATE
        public void Crear(Observacion Observacion)
        {
            Crear(nameof(Observacion), Observacion);
        }
        #endregion

        #region READ
        public List<Observacion> Leer()
        {
            return Leer<Observacion>(nameof(Observacion));
        }
        #endregion

        #region UPDATE
        public void Actualizar(Observacion Observacion)
        {
            Actualizar<Observacion>(nameof(Observacion), (u) => u.Id == u.Id, Observacion);
        }
        #endregion

        #region DELETE
        public void Eliminar(string id)
        {
            Eliminar<Observacion>(nameof(Observacion), (u) => u.Id == id);
        }
        #endregion

        #region SEARCH
        public Observacion Buscar(string id)
        {
            return Buscar<Observacion>(nameof(Observacion), (u) => u.Id == id);
        }
        #endregion 


        #endregion
    }
}
