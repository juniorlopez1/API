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
    [Route("api/perfil")]

    //ControllerBase porque no devuelve vistas. (No se ocupa para el API)
    public class PerfilController : ControllerBase
    {
        //Esta region implementa los servicios - interfaz de la capa de logica
        #region Servicios
        private readonly IPerfilService servicio;
        #endregion

        //Esta region es el constructor que inicializa el servicio de la capa de logica
        #region Constructor
        public PerfilController (IPerfilService servicio)
        {
            this.servicio = servicio;
        }
        #endregion

        //Esta region implementa CRUD y SEARCH adicionales para el filtro de reporteria
        #region CRUD

        [HttpPost(Name = "CreatePerfil")]
        public IActionResult Create(Perfil entidad)
        {
            //Instancia la entidad
            servicio.Crear(entidad);

            //Regresa la ruta de la entidad creada de acuerdo al key {Id o Codigo}
            return CreatedAtRoute("SearchPerfil", new { codigo = entidad.Codigo }, entidad);
        }

        [HttpGet(Name = "ReadPerfil")]
        public IActionResult Read()
        {
            //Crea la vista haciendo instancia del servicio
            var view = servicio.Leer();

            //Regresa el objeto Ok de NET Core con vista parametro
            return Ok(view);
        }

        [HttpPut(Name = "UpdatePerfil")]
        public IActionResult Update(Perfil entidad)
        {
            //Instancia la entidad
            servicio.Actualizar(entidad);

            //Regresa la ruta de la entidad creada de acuerdo al key {Id o Codigo}
            return CreatedAtRoute(nameof(Search), new { codigo = entidad.Codigo }, entidad);
        }

        [HttpDelete("{codigo}", Name = "DeletePerfil")] //Borrado logico!
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

        [HttpGet("{codigo}", Name = "SearchPerfil")]
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

        #endregion
    }
}
