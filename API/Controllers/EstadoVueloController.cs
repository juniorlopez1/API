using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{ //Poner el prefix necesario para el API route
    [ApiController]
    [Route("api/estadovuelo")]

    //ControllerBase en lugar de Controller porque no se ocupan vistas aca
    //No se necesita interfaz en el API, 
    //Solo es necesario consumir servicios


    public class EstadoVueloController : ControllerBase
    {
        #region Implementación de Servicios
        private readonly IEstadoVueloService estadovuelosvc;

        #endregion

        #region Constructor
        public EstadoVueloController(IEstadoVueloService estadovuelosvc)
        {
            this.estadovuelosvc = estadovuelosvc;
        }

        #endregion

        #region CRUD


        #region CREATE
        [HttpPost(Name = "CreateEstadoVuelo")]
        public IActionResult Create(EstadoVuelo EstadoVuelo)
        {
            estadovuelosvc.Crear(EstadoVuelo);
            return CreatedAtRoute(nameof(Search), new { codigo = EstadoVuelo.Id }, EstadoVuelo);
        }
        #endregion

        #region READ
        [HttpGet(Name = "ReadEstadoVuelo")]
        public IActionResult Read()
        {
            var EstadoVueloes = estadovuelosvc.Leer();
            return Ok(EstadoVueloes);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "UpdateEstadoVuelo")]
        public IActionResult Update(EstadoVuelo EstadoVuelo)
        {
            estadovuelosvc.Actualizar(EstadoVuelo);
            return CreatedAtRoute(nameof(Search), new { codigo = EstadoVuelo.Id }, EstadoVuelo);
        }
        #endregion

        #region DELETE
        [HttpDelete("{codigo}", Name = "DeleteEstadoVuelo")]
        public IActionResult Delete(string codigo)
        {
            estadovuelosvc.Eliminar(codigo);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{codigo}", Name = "SearchEstadoVuelo")]
        public IActionResult Search(string codigo)
        {
            var EstadoVuelo = estadovuelosvc.Buscar(codigo);

            if (EstadoVuelo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(EstadoVuelo);
            }
        }
        #endregion


        #endregion
    }
}
