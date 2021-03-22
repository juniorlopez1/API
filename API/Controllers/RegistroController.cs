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
    [Route("api/registro")]

    //ControllerBase porque no devuelve vistas. (No se ocupa para el API)
    public class RegistroController : ControllerBase
    {
        //Esta region implementa los servicios - interfaz de la capa de logica
        #region Servicios
        private readonly IRegistroService servicio;
        #endregion

        //Esta region es el constructor que inicializa el servicio de la capa de logica
        #region Constructor
        public RegistroController(IRegistroService registrosvc)
        {
            this.servicio = registrosvc;
        }
        #endregion

        //Esta region implementa CRUD y SEARCH adicionales para el filtro de reporteria
        #region CRUD
        //Nota:
        //Pregunta :
        //Se puede borrar o comentar el controller delete
        //No tiene delete de ningun tipo. El registro no deberia de tener borrado fisico o logico
        //Pregunta :
        // SEARCH es necesario en este controller?

        [HttpPost(Name = "CreateRegistro")]
        public IActionResult Create(Registro entidad)
        {
            //Instancia la entidad
            servicio.Crear(entidad);

            //Regresa la ruta de la entidad creada de acuerdo al key {Id o Codigo}
            return CreatedAtRoute(nameof(Search), new { codigo = entidad.Id }, entidad);
        }

        [HttpGet(Name = "ReadRegistro")]
        public IActionResult Read()
        {
            //Crea la vista haciendo instancia del servicio
            var view = servicio.Leer();

            //Regresa el objeto Ok de NET Core con vista parametro
            return Ok(view);
        }

        [HttpPut(Name = "UpdateRegistro")]
        public IActionResult Update(Registro entidad)
        {
            //Instancia la entidad
            servicio.Actualizar(entidad);

            //Regresa la ruta de la entidad creada de acuerdo al key {Id o Codigo}
            return CreatedAtRoute(nameof(Search), new { codigo = entidad.Id }, entidad);
        }

        [HttpGet("{codigo}", Name = "SearchRegistro")]
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

        #region DELETE
        [HttpDelete("{codigo}", Name = "DeleteRegistro")]
        public IActionResult Delete(string codigo)
        {
            servicio.Eliminar(codigo);
            return NoContent();
        }
        #endregion

        #endregion
    }
}
