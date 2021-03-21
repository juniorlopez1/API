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
    [Route("api/observacion")]

    //ControllerBase en lugar de Controller porque no se ocupan vistas aca
    //No se necesita interfaz en el API, 
    //Solo es necesario consumir servicios


    public class ObservacionController : ControllerBase
    {
        #region Implementación de Servicios
        private readonly IObservacionService observacionsvc;

        #endregion

        #region Constructor
        public ObservacionController(IObservacionService observacionsvc)
        {
            this.observacionsvc = observacionsvc;
        }

        #endregion

        #region CRUD


        #region CREATE
        [HttpPost(Name = "CreateObservacion")]
        public IActionResult Create(Observacion Observacion)
        {
            observacionsvc.Crear(Observacion);
            return CreatedAtRoute(nameof(Search), new { codigo = Observacion.Codigo }, Observacion);
        }
        #endregion

        #region READ
        [HttpGet(Name = "ReadObservacion")]
        public IActionResult Read()
        {
            var Observaciones = observacionsvc.Leer();
            return Ok(Observaciones);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "UpdateObservacion")]
        public IActionResult Update(Observacion Observacion)
        {
            observacionsvc.Actualizar(Observacion);
            return CreatedAtRoute(nameof(Search), new { codigo = Observacion.Codigo }, Observacion);
        }
        #endregion

        #region DELETE
        [HttpDelete("{codigo}", Name = "DeleteObservacion")]
        public IActionResult Delete(string codigo)
        {
            observacionsvc.Eliminar(codigo);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{codigo}", Name = "SearchObservacion")]
        public IActionResult Search(string codigo)
        {
            var Observacion = observacionsvc.Buscar(codigo);

            if (Observacion == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Observacion);
            }
        }
        #endregion


        #endregion
    }
}