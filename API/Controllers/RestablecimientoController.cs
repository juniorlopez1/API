using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]

    //Se especifica la ruta Prefix del controller
    [Route("api/restablecimiento")]
    public class RestablecimientoController : ControllerBase
    {
        private readonly IRestablecimientoService servicio;

        public RestablecimientoController(IRestablecimientoService servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost(Name = "CreateRestablecimiento")]
        public IActionResult Create(Restablecimiento entidad)
        {
            //Instancia la entidad
            servicio.Crear(entidad);

            //Regresa la ruta de la entidad creada de acuerdo al key {Id o Codigo}
            return CreatedAtRoute(nameof(Search), new { codigo = entidad.Codigo }, entidad);
        }

        [HttpGet("{codigo}", Name = "SearchRestablecimiento")]
        public IActionResult Search(string codigo)
        {
            //Busca la entidad de acuerdo al key {Id, Codigo}
            var entidad = servicio.Buscar(codigo);

            //Si es nula "not found", Si no es nula regresa entidad
            if (entidad == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(entidad);
            }
        }

        [HttpDelete("{codigo}", Name = "EliminarRestablecimiento")]
        public IActionResult Eiminar(string codigo)
        {
            //Variable que implementa "Search" metodo adicional
            servicio.Eliminar(codigo);
          //No regresa contenido es un borrado logico
            return NoContent();
        }
    }
}
