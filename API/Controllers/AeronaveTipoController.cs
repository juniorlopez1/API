using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AeronaveTipoController : ControllerBase
    {
        #region Implementación de Servicios
        private readonly IAeronaveTipoService aeronavetiposvc;

        #endregion

        #region Constructor
        public AeronaveTipoController(IAeronaveTipoService aeronavetiposvc)
        {
            this.aeronavetiposvc = aeronavetiposvc;
        }

        #endregion

        #region CRUD


        #region CREATE
        [HttpPost(Name = "CreateAeronaveTipo")]
        public IActionResult Create(AeronaveTipo AeronaveTipo)
        {
            aeronavetiposvc.Crear(AeronaveTipo);
            return CreatedAtRoute(nameof(Search), new { codigo = AeronaveTipo.Id }, AeronaveTipo);
        }
        #endregion

        #region READ
        [HttpGet(Name = "ReadAeronaveTipo")]
        public IActionResult Read()
        {
            var AeronaveTipoes = aeronavetiposvc.Leer();
            return Ok(AeronaveTipoes);
        }
        #endregion

        #region UPDATE
        [HttpPut(Name = "UpdateAeronaveTipo")]
        public IActionResult Update(AeronaveTipo AeronaveTipo)
        {
            aeronavetiposvc.Actualizar(AeronaveTipo);
            return CreatedAtRoute(nameof(Search), new { codigo = AeronaveTipo.Id }, AeronaveTipo);
        }
        #endregion

        #region DELETE
        [HttpDelete("{codigo}", Name = "DeleteAeronaveTipo")]
        public IActionResult Delete(string codigo)
        {
            aeronavetiposvc.Eliminar(codigo);
            return NoContent();
        }
        #endregion

        #region SEARCH
        [HttpGet("{codigo}", Name = "SearchAeronaveTipo")]
        public IActionResult Search(string codigo)
        {
            var AeronaveTipo = aeronavetiposvc.Buscar(codigo);

            if (AeronaveTipo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(AeronaveTipo);
            }
        }
        #endregion


        #endregion
    }
}
