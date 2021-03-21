using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IPerfilService
    {

        #region CRUD

        //CREATE
        Task Crear(PerfilViewModel perfil);

        //READ
        Task<List<PerfilViewModel>> Listar();

        //UPDATE
        Task Actualizar(PerfilViewModel perfil);

        //DELETE
        Task Eliminar(string codigo);

        //SEARCH

        Task<PerfilViewModel> Buscar(string codigo); 
        #endregion

    }

    public class PerfilService : ServicioBase, IPerfilService
        //Hereda del servicio base e implementa la interfaz correspondiente

    {
        #region Constructor
        public PerfilService(string baseUrl)
    : base(baseUrl)
        {
            //Constructor con la base URL
        } 
        #endregion

        #region CRUD

        #region CREATE
        public async Task Crear(PerfilViewModel entidad)
        {
            await PostAsync<PerfilViewModel>("perfil", entidad).ConfigureAwait(false);
        }
        #endregion

        #region READ
        public async Task<List<PerfilViewModel>> Listar()
        {
            return await GetAsync<List<PerfilViewModel>>("perfil").ConfigureAwait(false);
        }
        #endregion

        #region UPDATE
        public async Task Actualizar(PerfilViewModel entidad)
        {
            await PutAsync<PerfilViewModel>("perfil", entidad).ConfigureAwait(false);
        }
        #endregion

        #region DELETE
        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"perfil/{codigo}").ConfigureAwait(false);
        }
        #endregion 

        #region SEARCH
        public async Task<PerfilViewModel> Buscar(string codigo)
        {
            return await GetAsync<PerfilViewModel>($"perfil/{codigo}").ConfigureAwait(false);
        }
        #endregion

        #endregion
    }

}
