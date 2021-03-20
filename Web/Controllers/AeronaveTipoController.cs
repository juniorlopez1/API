using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Servicios;

namespace Web.Controllers
{
    public class AeronaveTipoController : Controller
    {
        #region Miembros
        private readonly IwebAeronaveTipoService servicio;
        #endregion

        #region Constructor
        public AeronaveTipoController(IwebAeronaveTipoService servicio)
        {
            this.servicio = servicio;
        }
        #endregion

        #region CRUD

        #region READ
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var view = await servicio.Listar();

            //Si no existe la coleccion en mongodb
            //var view = await servicio.Listar() ?? new List<AeronaveTipoViewModel>();
            return View(view);
        }
        #endregion

        #region CREATE OR UPDATE
        [HttpGet]
        public async Task<IActionResult> Editar(string codigo)
        {
            var view = await servicio.Buscar(codigo);
            return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(AeronaveTipoViewModel entidad)
        {
            if (string.IsNullOrEmpty(entidad.Id))
            {
                await servicio.Crear(entidad);
            }
            else
            {
                await servicio.Actualizar(entidad);
            }

            return RedirectToAction("Lista");
        }
        #endregion

        #region SEARCH
        [HttpGet]
        public async Task<IActionResult> Buscar(string codigo)
        {
            var view = await servicio.Buscar(codigo);
            return View(view);
        }
        #endregion

        #region DELETE
        [HttpGet]
        public async Task<IActionResult> Eliminar(string codigo)
        {
            await servicio.Eliminar(codigo);
            return RedirectToAction("Lista");
        }
        #endregion

        #endregion
    }
}
