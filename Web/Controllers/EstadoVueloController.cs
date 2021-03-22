using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Servicios;

namespace Web.Controllers
{
    public class EstadoVueloController : Controller
    {
        private readonly IEstadoVueloService servicio;

        public EstadoVueloController(IEstadoVueloService servicio)
        {
            this.servicio = servicio;
        }


        #region CRUD
        [HttpGet]
        public async Task<IActionResult> Editar(string codigo = null)
        {
            var view = default(EstadoVueloViewModel);

            if (string.IsNullOrEmpty(codigo))
            {
                view = new EstadoVueloViewModel();
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
        public async Task<IActionResult> Guardar(EstadoVueloViewModel var)
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
            var perfil = await servicio.Buscar(codigo);
            return View(perfil);
        }



        
    }
}
