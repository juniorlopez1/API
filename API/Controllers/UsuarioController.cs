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
    [Route("api/usuario")]

    //ControllerBase porque no devuelve vistas. (No se ocupa para el API)
    public class UsuarioController : ControllerBase
    {
        //Esta region implementa los servicios - interfaz de la capa de logica
        #region Servicios
        private readonly IUsuarioService servicio;
        #endregion

        //Esta region es el constructor que inicializa el servicio de la capa de logica
        #region Constructor
        public UsuarioController(IUsuarioService servicio)
        {
            this.servicio = servicio;
        }
        #endregion

        //Esta region implementa CRUD y SEARCH adicionales para el filtro de reporteria
        #region CRUD
        // Este controller incluye gestion de contraseñas

        [HttpPost(Name = "CreateUsuario")]
        public IActionResult Create(Usuario entidad)
        {
            //Instancia la entidad
            servicio.Crear(entidad);

            //Regresa la ruta de la entidad creada de acuerdo al key {Id o Codigo}
            return CreatedAtRoute(nameof(Search), new { codigo = entidad.Id }, entidad);
        }

        [HttpGet(Name = "ReadUsuario")]
        public IActionResult Read()
        {
            //Crea la vista haciendo instancia del servicio
            var view = servicio.Leer();

            //Regresa el objeto Ok de NET Core con vista parametro
            return Ok(view);
        }

        [HttpPut(Name = "UpdateUsuario")]
        public IActionResult Update(Usuario entidad)
        {
            //Instancia la entidad
            servicio.Actualizar(entidad);

            //Regresa la ruta de la entidad creada de acuerdo al key {Id o Codigo}
            return CreatedAtRoute(nameof(Search), new { codigo = entidad.Id }, entidad);
        }

        [HttpDelete("{codigo}", Name = "DeleteUsuario")] //Borrado logico!
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

        [HttpGet("{codigo}", Name = "SerchUsuario")]
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

        [HttpGet("nombre-usuario/{nombreUsuario}", Name = "SearchNombreUsuario")]
        public IActionResult SearchNombreUsuario(string nombreUsuario)
        {
            //Busca la entidad de acuerdo al key {Id, Codigo}
            var entidad = servicio.BuscarPorNombreUsuario(nombreUsuario);

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

        [HttpGet("id/{id}", Name = "SearchById")]
        public IActionResult SearchById(string id)
        {
            //Busca la entidad de acuerdo al key {Id, Codigo}
            var entidad = servicio.BuscarPorId(id);

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



        [HttpPost("autenticar", Name = "Autenticar")]
        public IActionResult Autenticar(Credenciales credenciales)
        {
            var usuario = servicio.BuscarPonombreUsuarioContrasena(credenciales.NombreUsuario, credenciales.Contrasena);

            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(usuario);
            }
        }

        #endregion

    }
}
