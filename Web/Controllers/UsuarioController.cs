using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Servicios;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        #region Miembros
        private readonly IUsuarioService servicio;
        #endregion

        #region Constructor
        public UsuarioController(IUsuarioService servicio)
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
        public async Task<IActionResult> Guardar(UsuarioViewModel var)
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
            var perfil = await servicio.Buscar(codigo);
            return View(perfil);
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

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            var credenciales = new CredencialesViewModel();
            return View(credenciales);
        }

        [HttpPost]
        public async Task<IActionResult> Autenticar(CredencialesViewModel credenciales)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", credenciales);
            }

            var usuario = await servicio.Autenticar(credenciales);
            
            if(usuario == null)
            {
                ModelState.AddModelError("", "Nombre de usuario o contraseña invalidos");
                return View("Login", credenciales);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

        #endregion
    }
}
