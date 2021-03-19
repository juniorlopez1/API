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
    [Route("api/perfil")]

    //ControllerBase en lugar de Controller porque no se ocupan vistas aca
    //No se necesita interfaz en el API, 
    //Solo es necesario consumir servicios


    public class PerfilController : ControllerBase
    {
        #region Implementación de Servicios
        private readonly IPerfilService perfilsvc;

        #endregion

        #region Constructor
        public PerfilController (IPerfilService perfilService)
        {
            this.perfilsvc = perfilService;
        }
        #endregion


        #region CREATE
        [HttpPost(Name = "CreatePerfil")]
        public IActionResult Create (Pista perfil)
        {
            perfilsvc.CrearPerfiles(perfil);
            return CreatedAtRoute(nameof(Search), new { codigo = perfil.Codigo }, perfil);
        }
        #endregion

        #region READ
        [HttpGet(Name = "ReadPerfil")]
        public IActionResult Read ()
        {
            var perfiles = perfilsvc.LeerPerfiles();
            return Ok(perfiles);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "UpdatePerfil")]
        public IActionResult Update (Pista perfil)
        {
            perfilsvc.ActualizarPerfiles(perfil);
            return CreatedAtRoute(nameof(Search), new { codigo = perfil.Codigo }, perfil);
        }
        #endregion

        #region DELETE
        [HttpDelete("{codigo}", Name = "DeletePerfil")]
        public IActionResult Delete (string codigo)
        {
            perfilsvc.EliminarPerfiles(codigo);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{codigo}", Name = "SearchPerfil")]
        public IActionResult Search (string codigo)
        {
            var perfil = perfilsvc.BuscarPerfiles(codigo);

            if (perfil == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(perfil);
            }
        }
        #endregion


    }
}
