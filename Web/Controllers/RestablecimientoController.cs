using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Servicios;

namespace Web.Controllers
{
    public class RestablecimientoController : Controller
    {
        private readonly IRestablecimientoService servicio;
        private readonly IUsuarioService usuarioServicio;

        public RestablecimientoController(IRestablecimientoService servicio, IUsuarioService usuarioServicio)
        {
            this.servicio = servicio;
            this.usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        public IActionResult Crear() 
        {
            ViewBag.Correo = string.Empty;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Enviar(string correo)
        {
            var usuario = await usuarioServicio.BuscarPorNombreUsuario(correo);
            ViewBag.Correo = correo;

            if (usuario == null)
            {
                ModelState.AddModelError("", "La direccion de correo no es no existe en el sistema");
                return View("Restablecer");
            }
            else
            {
                var codigo = Guid.NewGuid().ToString();
                await servicio.Crear(new RestablecimientoViewModel()
                {
                    Codigo = codigo,
                    IdUsuario = usuario.Id
                });

                await servicio.EnviarRestablecimiento(correo, codigo);


                return View("Confirmacion");
            }
        }

        [HttpGet]
        public IActionResult Confirmacion()
        {
            return View();
        }

        [HttpGet("restablecimiento/restablecer/{codigo}", Name = "RestablecerContrasena")]
        public async Task<IActionResult> Restablecer(string codigo)
        {
            CambioContrasenaViewModel cambioContrasena = null;
            var restablecimiento = await servicio.Buscar(codigo);

            if (restablecimiento == null)
            {
                cambioContrasena = new CambioContrasenaViewModel()
                {
                    IdRestablecimiento = string.Empty,
                    ConfirmacionContrasena = string.Empty,
                    NuevaContrasena = string.Empty,
                };
            }
            else
            {
                cambioContrasena = new CambioContrasenaViewModel()
                {
                    IdRestablecimiento = codigo,
                    ConfirmacionContrasena = string.Empty,
                    NuevaContrasena = string.Empty,
                };
            }

            return View(cambioContrasena);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(CambioContrasenaViewModel cambio)
        {
            if (!ModelState.IsValid) 
            {
                return View("Restablecer",cambio);
            }

            var restablecimiento = await servicio.Buscar(cambio.IdRestablecimiento);

            if (restablecimiento == null)
            {
                ModelState.AddModelError("", "Ocurrio un problema al restablecer la contrasena");
                return View("Restablecer", cambio);
            }
            else
            {
                if (string.IsNullOrEmpty(cambio.NuevaContrasena.Trim()) || string.IsNullOrEmpty(cambio.ConfirmacionContrasena.Trim()))
                {
                    ModelState.AddModelError("", "La contrasena es requerida");
                    return View("Restablecer", cambio);
                }

                if (!cambio.NuevaContrasena.Trim().Equals(cambio.ConfirmacionContrasena.Trim()))
                {
                    ModelState.AddModelError("", "Las contrasenas no coinciden");
                    return View("Restablecer", cambio);
                }

                var usuario = await usuarioServicio.BuscarPorId(restablecimiento.IdUsuario);
                usuario.Contrasena = cambio.NuevaContrasena;
                await usuarioServicio.Actualizar(usuario);

                if (usuario == null)
                {
                    ModelState.AddModelError("", "Ocurrio un problema al restablecer la contrasena");
                    return View("Restablecer", cambio);
                }

                await servicio.Eliminar(cambio.IdRestablecimiento);

                return RedirectToAction("Login","Usuario");
            }
        }
    }
}
