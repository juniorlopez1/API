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
    [Route("api/aeronave")]

    //ControllerBase en lugar de Controller
    //No se necesita interfaz en el API, 
    //Solo es necesario consumir servicios


    public class AeronaveController : ControllerBase
    {
        #region Implementación de Servicios
        private readonly IAeronaveService aeronavesvc;

        #endregion

        #region Constructor
        public AeronaveController (IAeronaveService aeronaveService)
        {
            this.aeronavesvc = aeronaveService;
        }
        #endregion


        #region CREATE
        [HttpPost(Name = "Create")]
        public IActionResult Create (Aeronave aeronave)
        {
            aeronavesvc.CrearAeronaves(aeronave);
            return CreatedAtRoute(nameof(Search), new { codigo = aeronave.Codigo }, aeronave);
        }
        #endregion

        #region READ
        [HttpGet(Name = "Read")]
        public IActionResult Read ()
        {
            var usuarios = aeronavesvc.LeerAeronaves();
            return Ok(usuarios);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "Update")]
        public IActionResult Update (Aeronave aeronave)
        {
            aeronavesvc.ActualizarAeronaves (aeronave);
            return CreatedAtRoute(nameof(Search), new { codigo = aeronave.Codigo }, aeronave);
        }
        #endregion

        #region DELETE
        [HttpDelete("{codigo}", Name = "Delete")]
        public IActionResult Delete (string codigo)
        {
            aeronavesvc.EliminarAeronaves (codigo);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{codigo}", Name = "Search")]
        public IActionResult Search (string codigo)
        {
            var aeronave = aeronavesvc.BuscarAeronaves(codigo);

            if (aeronave == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(aeronave);
            }
        }
        #endregion


    }
}
