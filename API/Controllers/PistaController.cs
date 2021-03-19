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
    [Route("api/pista")]

    //ControllerBase en lugar de Controller porque no se ocupan vistas aca
    //No se necesita interfaz en el API, 
    //Solo es necesario consumir servicios



    public class PistaController : ControllerBase
    {
        #region Implementación de Servicios
        private readonly IPistaService pistasvc;

        #endregion

        #region Constructor
        public PistaController(IPistaService pistaService)
        {
            this.pistasvc = pistaService;
        }
        #endregion



        #region CREATE
        [HttpPost(Name = "CreatePista")]
        public IActionResult Create(Pista pista)
        {
            pistasvc.CrearPistas(pista);
            return CreatedAtRoute(nameof(Search), new { codigo = pista.Codigo }, pista);
        }
        #endregion

        #region READ
        [HttpGet(Name = "ReadPista")]
        public IActionResult Read()
        {
            var pista = pistasvc.LeerPistas();
            return Ok(pista);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "UpdatePista")]
        public IActionResult Update(Pista pista)
        {
            pistasvc.ActualizarPistas(pista);
            return CreatedAtRoute(nameof(Search), new { codigo = pista.Codigo }, pista);
        }
        #endregion

        #region DELETE
        [HttpDelete("{codigo}", Name = "DeletePista")]
        public IActionResult Delete(string codigo)
        {
            pistasvc.EliminarPistas(codigo);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{codigo}", Name = "SearchPista")]
        public IActionResult Search(string codigo)
        {
            var pista = pistasvc.BuscarPistas(codigo);

            if (pista == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(pista);
            }
        }
        #endregion

    }
}
