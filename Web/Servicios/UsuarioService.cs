using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IUsuarioService
    {
        //CREATE
        Task Crear(UsuarioViewModel usuario);

        //READ
        Task<List<UsuarioViewModel>> Listar();

        //UPDATE
        Task Actualizar(UsuarioViewModel usuario);

        //DELETE
        Task Eliminar(string codigo);

        //SEARCH
        Task<UsuarioViewModel> Buscar(string codigo);

    }

    public class UsuarioService : ServicioBase, IUsuarioService
    //Hereda del servicio base e implementa la interfaz correspondiente

    {
        #region Constructor
        public UsuarioService(string baseUrl)
    : base(baseUrl)
        {
            //Constructor con la base URL
        }
        #endregion

        #region CRUD

        #region CREATE
        public async Task Crear(UsuarioViewModel entidad)
        {
            await PostAsync<UsuarioViewModel>("usuario", entidad).ConfigureAwait(false);
        }
        #endregion

        #region READ
        public async Task<List<UsuarioViewModel>> Listar()
        {
            return await GetAsync<List<UsuarioViewModel>>("usuario").ConfigureAwait(false);
        }
        #endregion

        #region UPDATE
        public async Task Actualizar(UsuarioViewModel entidad)
        {
            await PutAsync<UsuarioViewModel>("usuario", entidad).ConfigureAwait(false);
        }
        #endregion

        #region DELETE
        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"usuario/{codigo}").ConfigureAwait(false);
        }
        #endregion 

        #region SEARCH
        public async Task<UsuarioViewModel> Buscar(string codigo)
        {
            return await GetAsync<UsuarioViewModel>($"usuario/{codigo}").ConfigureAwait(false);
        }
        #endregion

        #endregion
    }
}
