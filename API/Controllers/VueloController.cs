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
    [Route("api/vuelo")]

    //ControllerBase en lugar de Controller porque no se ocupan vistas aca
    //No se necesita interfaz en el API, 
    //Solo es necesario consumir servicios

    public class VueloController : ControllerBase
    {
        #region Implementación de Servicios
        private readonly IVueloService vuelosvc;

        #endregion

        #region Constructor
        public VueloController(IVueloService vueloservice)
        {
            this.vuelosvc = vueloservice;
        }
        #endregion



        #region CREATE
        [HttpPost(Name = "CreateVuelo")]
        public IActionResult Create(Vuelo vuelo)
        {
            vuelosvc.CrearVuelos(vuelo);
            return CreatedAtRoute(nameof(Search), new { codigo = vuelo.Codigo }, vuelo);
        }
        #endregion

        #region READ
        [HttpGet(Name = "ReadVuelo")]
        public IActionResult Read()
        {
            var vuelos = vuelosvc.LeerVuelos();
            return Ok(vuelos);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "UpdateVuelo")]
        public IActionResult Update(Vuelo vuelo)
        {
            vuelosvc.ActualizarVuelos(vuelo);
            return CreatedAtRoute(nameof(Search), new { codigo = vuelo.Codigo }, vuelo);
        }
        #endregion

        #region DELETE
        [HttpDelete("{codigo}", Name = "DeleteVuelo")]
        public IActionResult Delete(string codigo)
        {
            vuelosvc.EliminarVuelos(codigo);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{codigo}", Name = "SearchVuelo")]
        public IActionResult Search(string codigo)
        {
            var vuelo = vuelosvc.BuscarVuelos(codigo);

            if (vuelo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vuelo);
            }
        }
        #endregion


    }
}
