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
        [HttpPost]
        public IActionResult CrearAeronaves (Aeronave aeronave)
        {
            aeronavesvc.CrearAeronaves(aeronave);
            return CreatedAtRoute(nameof(CrearAeronaves), new { id = aeronave.Id }, aeronave);
        }
        #endregion

        #region READ
        [HttpGet(Name = "LeerAeronaves")]
        public IActionResult LeerAeronaves ()
        {
            var usuarios = aeronavesvc.LeerAeronaves();
            return Ok(usuarios);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "ActualizarAeronaves")]
        public IActionResult ActualizarAeronaves (Aeronave aeronave)
        {
            aeronavesvc.ActualizarAeronaves (aeronave);
            return CreatedAtRoute(nameof(ActualizarAeronaves), new { id = aeronave.Id }, aeronave);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "EliminarAeronaves")]
        public IActionResult EliminarAeronaves (string id)
        {
            aeronavesvc.EliminarAeronaves (id);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{id}", Name = "BuscarAeronaves")]
        public IActionResult BuscarAeronaves (string Codigo)
        {
            var aeronave = aeronavesvc.BuscarAeronaves(Codigo);

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
