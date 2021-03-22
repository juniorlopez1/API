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
    public class RegistroController : Controller
    {
        private readonly IRegistroService servicioRegistro;
        private readonly IEstadoVueloService servicioVuelo;
        private readonly IObservacionService servicioObservacion;
        private readonly IAeronaveService servicioAeronave;

        public RegistroController(IRegistroService servicioRegistro, IEstadoVueloService servicioVuelo, IObservacionService servicioObservacion, IAeronaveService servicioAeronave)
        {
            this.servicioRegistro = servicioRegistro;
            this.servicioVuelo = servicioVuelo;
            this.servicioObservacion = servicioObservacion;
            this.servicioAeronave = servicioAeronave;
        }


        #region CRUD

        [HttpGet]
        public async Task<IActionResult> Editar(string codigo)
        {

            #region dropdowns
            ViewBag.ListaEstadoVuelo = (await servicioVuelo.Listar()).Select(p => new SelectListItem()
            {
                Text = p.Descripcion,
                Value = p.Codigo.ToString()
            }).ToList();

            ViewBag.ListaAeronave = (await servicioAeronave.Listar()).Select(p => new SelectListItem()
            {
                Text = p.Codigo,
                Value = p.Codigo.ToString()
            }).ToList();

            ViewBag.ListaObservacion = (await servicioObservacion.Listar()).Select(p => new SelectListItem()
            {
                Text = p.Descripcion,
                Value = p.Codigo.ToString()
            }).ToList();
            #endregion


            RegistroViewModel view = null;

            if (string.IsNullOrEmpty(codigo))
            {
                view = new RegistroViewModel();
            }
            else
            {
                view = await servicioRegistro.Buscar(codigo);
            }

            return View(view);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var view = await servicioRegistro.Listar();
            return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(RegistroViewModel entidad)
        {
            #region dropdowns
            entidad.Aeronave = await servicioAeronave.Buscar(entidad.Aeronave.Codigo);
            entidad.Observacion = await servicioObservacion.Buscar(entidad.Observacion.Codigo);
            entidad.EstadoVuelo = await servicioVuelo.Buscar(entidad.EstadoVuelo.Codigo);
            #endregion


            if (string.IsNullOrEmpty(entidad.Id))
            {
                await servicioRegistro.Crear(entidad);
            }
            else
            {
                await servicioRegistro.Actualizar(entidad);
            }

            return RedirectToAction("Lista");
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(string codigo)
        {
            await servicioRegistro.Eliminar(codigo);
            return RedirectToAction("Lista");
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> Buscar(string codigo)
        {
            var perfil = await servicioRegistro.Buscar(codigo);
            return View(perfil);
        }


        

        
    }
}
