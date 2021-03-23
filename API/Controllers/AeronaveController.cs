using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //Se especifica el APIController para la publicacion de servicios
    [ApiController]

    //Se especifica la ruta Prefix del controller
    [Route("api/aeronave")]

    //ControllerBase porque no devuelve vistas. (No se ocupa para el API)
    public class AeronaveController : ControllerBase
    {
        //Esta region implementa los servicios - interfaz de la capa de logica
        #region Services
        private readonly IAeronaveService servicio;
        #endregion

        //Esta region es el constructor que inicializa el servicio de la capa de logica
        #region Constructor
        public AeronaveController(IAeronaveService servicio)
        {
            this.servicio = servicio;
        }
        #endregion

        //Esta region implementa CRUD y SEARCH adicionales para el filtro de reporteria
        #region CRUD

        [HttpPost(Name = "CreateAeronave")]
        public IActionResult Create(Aeronave entidad)
        {
            //Instancia la entidad
            servicio.Crear(entidad);

            //Regresa la ruta de la entidad creada de acuerdo al key {Id o Codigo}
            return CreatedAtRoute(nameof(Search), new { codigo = entidad.Codigo }, entidad);
        }

        [HttpGet(Name = "ReadAeronave")]
        public IActionResult Read()
        {
            //Crea la vista haciendo instancia del servicio
            var view = servicio.Leer();

            //Regresa el objeto Ok de NET Core con vista parametro
            return Ok(view);
        }

        [HttpPut(Name = "UpdateAeronave")]
        public IActionResult Update(Aeronave entidad)
        {
            //Instancia la entidad
            servicio.Actualizar(entidad);

            //Regresa la ruta de la entidad creada de acuerdo al key {Id o Codigo}
            return CreatedAtRoute(nameof(Search), new { codigo = entidad.Codigo }, entidad);
        }

        [HttpDelete("{codigo}", Name = "DeleteAeronave")] //Borrado logico!
        public IActionResult Delete(string codigo)
        {
            //Variable que implementa "Search" metodo adicional
            var match = servicio.Buscar(codigo);

            //Es un borrado logico, Estado {true, false}
            match.Estado = false;

            //Instancia del servicio de acuerdo al valor de la variable
            servicio.Actualizar(match);

            //No regresa contenido es un borrado logico
            return NoContent();
        }

        #endregion

        [HttpGet("{codigo}", Name = "SearchAeronave")]
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

        [HttpGet("tipo-aeronave/{codigo}", Name = "SearchByTipoAeronave")]
        public IActionResult SearchByTipoAeronave(string codigo)
        {
            //Busca la entidad de acuerdo al key {Id, Codigo}
            var entidad = servicio.BuscarPorTipoAeronave(codigo);

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


        //!
        [HttpGet("observacion/{observacion}", Name = "SearchByObservacion")]
        public IActionResult SearchByObservacion(string Observacion)
        {
            //Busca la entidad de acuerdo al key {Id, Codigo}
            var entidad = servicio.BuscarPorObservacion(Observacion.Equals("activos", StringComparison.CurrentCultureIgnoreCase));

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

        //!
        [HttpGet("descripcion/{desperfecto}", Name = "SearchByDesperfecto")]
        public IActionResult SearchByDescripcion(string Desperfecto)
        {
            //Busca la entidad de acuerdo al key {Id, Codigo}
            var entidad = servicio.BuscarPorDesperfecto(Desperfecto.Equals("activos", StringComparison.CurrentCultureIgnoreCase));

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
    }
}
