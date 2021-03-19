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
        public IActionResult Create (Aeronave aeronave)
        {
            aeronavesvc.CrearAeronaves(aeronave);
            return CreatedAtRoute(nameof(Create), new { codigo = aeronave.Codigo }, aeronave);
        }
        #endregion

        #region READ
        [HttpGet(Name = "LeerAeronaves")]
        public IActionResult Read ()
        {
            var usuarios = aeronavesvc.LeerAeronaves();
            return Ok(usuarios);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "ActualizarAeronaves")]
        public IActionResult Update (Aeronave aeronave)
        {
            aeronavesvc.ActualizarAeronaves (aeronave);
            return CreatedAtRoute(nameof(Update), new { Codigo = aeronave.Codigo }, aeronave);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "EliminarAeronaves")]
        public IActionResult Delete (string Codigo)
        {
            aeronavesvc.EliminarAeronaves (Codigo);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{Codigo}", Name = "BuscarAeronaves")]
        public IActionResult search (string Codigo)
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
