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
        private readonly IAeronaveService aeronaveService;

        #endregion

        #region Constructor
        public AeronaveController (IAeronaveService aeronaveService)
        {
            this.aeronaveService = aeronaveService;
        }
        #endregion



        //----------------------Aeronave

        #region CREATE
        [HttpPost]
        public IActionResult CrearAeronaves (Aeronave aeronave)
        {
            aeronaveService.CrearAeronaves(aeronave);
            return CreatedAtRoute("CrearAeronaves", new { id = aeronave.Id }, aeronave);
        }
        #endregion

        #region READ
        //pregunta: falta implementacion de interfaces
        [HttpGet(Name = "ListarAeronaves")]
        public IActionResult ListaUsuario()
        {
            var usuarios = IAeronaveService.ListarAeronaves();
            return Ok(usuarios);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "ActualizarAeronaves")]
        public IActionResult ActualizarAeronaves (Aeronave aeronave)
        {
            aeronaveService.ActulizarAeronaves (aeronave);
            return CreatedAtRoute("ActualizarAeronaves", new { id = aeronave.Id }, aeronave);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "EliminarAeronaves")]
        public IActionResult ElimiinarAeronaves (string Codigo)
        {
            aeronaveService.EliminarAeronaves (Codigo);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{id}", Name = "BuscarAeronaves")]
        public IActionResult BuscarAeronaves (string Codigo)
        {
            var aeronave = aeronaveService.BuscarAeronaves(Codigo);

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
