using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    public interface IRestablecimientoService
    {
        void Crear(Restablecimiento restablecimiento);
        Restablecimiento Buscar(string codigo);
        void Eliminar(string codigo);
    }

    public class RestablecimientoService : IRestablecimientoService
    {
        private readonly DatosRestablecimiento accesoDatos;
        public RestablecimientoService(DatosRestablecimiento accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }

        public Restablecimiento Buscar(string codigo)
        {
            return accesoDatos.Buscar(codigo);
        }

        public void Crear(Restablecimiento restablecimiento)
        {
            accesoDatos.Crear(restablecimiento);
        }

        public void Eliminar(string codigo)
        {
            accesoDatos.Eliminar(codigo);
        }
    }
}
