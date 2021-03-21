using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Servicios;

namespace Web.Controllers
{
    public class PerfilController : Controller
    {
        #region Miembros
        private readonly IPerfilService servicio; 
        #endregion

        #region Constructor
        public PerfilController(IPerfilService servicio)
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
        public async Task<IActionResult> Guardar(PerfilViewModel var)
        {
            if (string.IsNullOrEmpty(var.Id))
            {
                await servicio.Crear(var);
            }
            else
            {
                await servicio.Actualizar(var);
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
