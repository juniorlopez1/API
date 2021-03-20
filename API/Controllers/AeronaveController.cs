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

    //ControllerBase en lugar de Controller porque no se ocupan vistas aca
    //No se necesita interfaz en el API, 
    //Solo es necesario consumir servicios


    public class AeronaveController : ControllerBase
    {
        #region Implementación de Servicios
        private readonly IapiAeronaveService aeronavesvc;

        #endregion

        #region Constructor
        public AeronaveController (IapiAeronaveService aeronaveService)
        {
            this.aeronavesvc = aeronaveService;
        }
        #endregion

        #region CRUD

        #region CREATE
        [HttpPost(Name = "CreateAeronave")]
        public IActionResult Create(Aeronave aeronave)
        {
            aeronavesvc.Crear(aeronave);
            return CreatedAtRoute(nameof(Search), new { codigo = aeronave.Codigo }, aeronave);
        }
        #endregion

        #region READ
        [HttpGet(Name = "ReadAeronave")]
        public IActionResult Read()
        {
            var aeronave = aeronavesvc.Leer();
            return Ok(aeronave);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "UpdateAeronave")]
        public IActionResult Update(Aeronave aeronave)
        {
            aeronavesvc.Actualizar(aeronave);
            return CreatedAtRoute(nameof(Search), new { codigo = aeronave.Codigo }, aeronave);
        }
        #endregion

        #region DELETE
        [HttpDelete("{codigo}", Name = "DeleteAeronave")]
        public IActionResult Delete(string codigo)
        {
            aeronavesvc.Eliminar(codigo);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{codigo}", Name = "SearchAeronave")]
        public IActionResult Search(string codigo)
        {
            var aeronave = aeronavesvc.Buscar(codigo);

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


        #endregion
    }
}
