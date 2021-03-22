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
        private readonly IAeronaveTipoService servicio;

        public AeronaveTipoController(IAeronaveTipoService servicio)
        {
            this.servicio = servicio;
        }


        #region CRUD

        [HttpGet]
        public async Task<IActionResult> Editar(string codigo)
        {
            AeronaveTipoViewModel view = null;

            if (string.IsNullOrWhiteSpace(codigo))
            {
                view = new AeronaveTipoViewModel();
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

            //Si no existe la coleccion en mongodb
            //var view = await servicio.Listar() ?? new List<AeronaveTipoViewModel>();
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
