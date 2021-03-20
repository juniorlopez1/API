using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //Poner el prefix necesario para el API route
    [ApiController]
    [Route("api/usuario")]

    //ControllerBase en lugar de Controller porque no se ocupan vistas aca
    //No se necesita interfaz en el API, 
    //Solo es necesario consumir servicios



    public class UsuarioController : ControllerBase
    {
        #region Implementación de Servicios
        private readonly IUsuarioService usuariosvc;

        #endregion

        #region Constructor
        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuariosvc = usuarioService;
        }
        #endregion

        #region CRUD

        #region CREATE
        [HttpPost(Name = "CreateUsuario")]
        public IActionResult Create(Usuario usuario)
        {
            usuariosvc.Crear(usuario);
            return CreatedAtRoute(nameof(Search), new { codigo = usuario.Id }, usuario);
        }
        #endregion

        #region READ
        [HttpGet(Name = "ReadUsuario")]
        public IActionResult Read()
        {
            var usuario = usuariosvc.Leer();
            return Ok(usuario);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "UpdateUsuario")]
        public IActionResult Update(Usuario usuario)
        {
            usuariosvc.Actualizar(usuario);
            return CreatedAtRoute(nameof(Search), new { codigo = usuario.Id }, usuario);
        }
        #endregion

        #region DELETE
        [HttpDelete("{codigo}", Name = "DeleteUsuario")]
        public IActionResult Delete(string codigo)
        {
            usuariosvc.Eliminar (codigo);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{codigo}", Name = "SerchUsuario")]
        public IActionResult Search(string codigo)
        {
            var usuario = usuariosvc.Buscar(codigo);

            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(usuario);
            }
        }
        #endregion

        #endregion

    }
}
