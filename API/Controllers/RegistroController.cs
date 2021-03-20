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
    [Route("api/registro")]

    //ControllerBase en lugar de Controller porque no se ocupan vistas aca
    //No se necesita interfaz en el API, 
    //Solo es necesario consumir servicios


    public class RegistroController : ControllerBase
    {
        #region Implementación de Servicios
        private readonly IRegistroService registrosvc;

        #endregion

        #region Constructor
        public RegistroController(IRegistroService registrosvc)
        {
            this.registrosvc = registrosvc;
        }

        #endregion

        #region CRUD


        #region CREATE
        [HttpPost(Name = "CreateRegistro")]
        public IActionResult Create(Registro Registro)
        {
            registrosvc.Crear(Registro);
            return CreatedAtRoute(nameof(Search), new { codigo = Registro.Id }, Registro);
        }
        #endregion

        #region READ
        [HttpGet(Name = "ReadRegistro")]
        public IActionResult Read()
        {
            var Registroes = registrosvc.Leer();
            return Ok(Registroes);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "UpdateRegistro")]
        public IActionResult Update(Registro Registro)
        {
            registrosvc.Actualizar(Registro);
            return CreatedAtRoute(nameof(Search), new { codigo = Registro.Id }, Registro);
        }
        #endregion

        #region DELETE
        [HttpDelete("{codigo}", Name = "DeleteRegistro")]
        public IActionResult Delete(string codigo)
        {
            registrosvc.Eliminar(codigo);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{codigo}", Name = "SearchRegistro")]
        public IActionResult Search(string codigo)
        {
            var Registro = registrosvc.Buscar(codigo);

            if (Registro == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Registro);
            }
        }
        #endregion


        #endregion
    }
}
