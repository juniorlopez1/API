using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Servicios;

namespace Web.Controllers
{
    public class ObservacionController : Controller
    {
        private readonly IObservacionService servicio;
        
        public ObservacionController (IObservacionService servicio)
        {
            this.servicio = servicio;
        }


        #region CRUD
        [HttpGet]
        public async Task<IActionResult> Editar(string codigo)
        {
            ObservacionViewModel view = null;

            if (string.IsNullOrEmpty(codigo))
            {
                view = new ObservacionViewModel();
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
        public async Task<IActionResult> Guardar(ObservacionViewModel var)
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

        public async Task<IActionResult> Filtrar()
        {

            var listaObservacion = new List<SelectListItem>();
            listaObservacion.Add(new SelectListItem() { Text = "Todos", Selected = true, Value = "" });

            (await servicio.Listar()).ForEach(p => listaObservacion.Add(new SelectListItem()
            {
                Text = p.Descripcion,
                Value = p.Codigo.ToString()
            }));

            ViewBag.ListaObservacion = listaObservacion;

            return View();
        }

        public async Task<IActionResult> Reporte(string codigo)
        {
            List<ObservacionViewModel> resultado = null;

            if (string.IsNullOrEmpty(codigo))
            {
                resultado = await servicio.Listar();
            }
            else
            {
                resultado = await servicio.BuscarPorCodigo(codigo);
            }

            return View(resultado);
        }


    }
}

