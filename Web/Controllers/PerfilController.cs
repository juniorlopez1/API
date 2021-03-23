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
        private readonly IPerfilService servicio; 

        public PerfilController(IPerfilService servicio)
        {
            this.servicio = servicio;
        }


        #region CRUD
        [HttpGet]
        public async Task<IActionResult> Editar(string codigo)
        {
            PerfilViewModel view = null;

            if (string.IsNullOrEmpty(codigo))
            {
                view = new PerfilViewModel();
            }
            else
            {
                view = await servicio.Buscar(codigo);
            }

            return View(view);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var view = await servicio.Listar();
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

        [HttpGet]
        public async Task<IActionResult> Eliminar(string codigo)
        {
            await servicio.Eliminar(codigo);
            return RedirectToAction("Lista");
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> Buscar(string codigo)
        {
            var view = await servicio.Buscar(codigo);
            return View(view);
        }



        

    }
}
