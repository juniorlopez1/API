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
    public class AeronaveController : Controller
    {
        #region Miembros
        private readonly IAeronaveService servicio;
        private readonly IAeronaveTipoService servicioaeronavetipo;
        #endregion

        #region Constructor
        public AeronaveController(IAeronaveService servicio, IAeronaveTipoService aeronavetiposvc)
        {
            this.servicio = servicio;
            this.servicioaeronavetipo = aeronavetiposvc;
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
            ViewBag.ListaAeronaveTipo = (await servicioaeronavetipo.Listar()).Select(p => new SelectListItem()
            {
                Text = p.Descripcion,
                Value = p.Codigo.ToString()
            }).ToList();

            AeronaveViewModel view = null;

            if(string.IsNullOrEmpty(codigo))
            {
                view = new AeronaveViewModel();
            }
            else
            {
                view = await servicio.Buscar(codigo);
            }


            return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(AeronaveViewModel entidad)
        {
            entidad.AeronaveTipo = await servicioaeronavetipo.Buscar(entidad.AeronaveTipo.Codigo);       

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

        public async Task<IActionResult> Filtrar()
        {

            var listaAeronaveTipo = new List<SelectListItem>();
            listaAeronaveTipo.Add(new SelectListItem() { Text = "Todos", Selected = true, Value = "" });

            (await servicioaeronavetipo.Listar()).ForEach(p => listaAeronaveTipo.Add(new SelectListItem()
            {
                Text = p.Descripcion,
                Value = p.Codigo.ToString()
            }));

            ViewBag.ListaAeronaveTipo = listaAeronaveTipo;

            return View();
        }

        public async Task<IActionResult> Reporte(string codigo)
        {
            List<AeronaveViewModel> resultado = null;

            if (string.IsNullOrEmpty(codigo))
            {
                resultado = await servicio.Listar();
            }
            else
            {
                resultado = await servicio.BuscarPorTipoAeronave(codigo);
            }

            return View(resultado);
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
