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
        private readonly IUsuarioService servicio;

        public UsuarioController(IUsuarioService servicio)
        {
            this.servicio = servicio;
        }


        #region CRUD

        [HttpGet]
        public async Task<IActionResult> Editar(string codigo)
        {
            var view = await servicio.Buscar(codigo);
            return View(view);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var view = await servicio.Listar();
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


        #region Gestion de contrasena
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


    }
}
