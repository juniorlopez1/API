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
    [Route("api/estadovuelo")]

    //ControllerBase porque no devuelve vistas. (No se ocupa para el API)
    public class EstadoVueloController : ControllerBase
    {
        //Esta region implementa los servicios - interfaz de la capa de logica
        #region Services
        private readonly IEstadoVueloService servicio;
        #endregion

        //Esta region es el constructor que inicializa el servicio de la capa de logica
        #region Constructor
        public EstadoVueloController(IEstadoVueloService servicio)
        {
            this.servicio = servicio;
        }
        #endregion

        //Esta region implementa CRUD y SEARCH adicionales para el filtro de reporteria
        #region CRUD

        [HttpPost(Name = "CreateEstadoVuelo")]
        public IActionResult Create(EstadoVuelo entidad)
        {
            //Instancia la entidad
            servicio.Crear(entidad);

            //Regresa la ruta de la entidad creada de acuerdo al key {Id o Codigo}
            return CreatedAtRoute("SearchEstadoVuelo", new { codigo = entidad.Codigo }, entidad);
        }

        [HttpGet(Name = "ReadEstadoVuelo")]
        public IActionResult Read()
        {
            //Crea la vista haciendo instancia del servicio
            var view = servicio.Leer();

            //Regresa el objeto Ok de NET Core con vista parametro
            return Ok(view);
        }

        [HttpPut(Name = "UpdateEstadoVuelo")]
        public IActionResult Update(EstadoVuelo entidad)
        {
            //Instancia la entidad
            servicio.Actualizar(entidad);

            //Regresa la ruta de la entidad creada de acuerdo al key {Id o Codigo}
            return CreatedAtRoute("SearchEstadoVuelo", new { codigo = entidad.Codigo }, entidad);
        }

        [HttpDelete("{codigo}", Name = "DeleteEstadoVuelo")] //Borrado fisico!
        public IActionResult Delete(string codigo)
        {
            //Se elimina del todo el documento de mongodb
            servicio.Eliminar(codigo);

            //No regresa contenido
            return NoContent();
        }

        #endregion


        [HttpGet("{codigo}", Name = "SearchEstadoVuelo")]
        public IActionResult SearchById(string Codigo)
        {
            //Busca la entidad de acuerdo al key {Id, Codigo}
            var entidad = servicio.Buscar(Codigo);

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

        [HttpGet("estado-vuelo/{codigo}", Name = "SearchByEstadoVuelo")]
        public IActionResult SearchByTipoAeronave(string codigo)
        {
            //Busca la entidad de acuerdo al key {Id, Codigo}
            var entidad = servicio.BuscarPorEstadoVuelo(codigo);

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
