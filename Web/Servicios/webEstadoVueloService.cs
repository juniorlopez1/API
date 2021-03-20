using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IwebEstadoVueloService
    {
        //CREATE
        Task Crear(EstadoVueloViewModel estadoVuelo);

        //READ
        Task<List<EstadoVueloViewModel>> Listar();

        //UPDATE
        Task Actualizar(EstadoVueloViewModel estadoVuelo);

        //DELETE
        Task Eliminar(string codigo);

        //SEARCH
        Task<EstadoVueloViewModel> Buscar(string codigo);

    }

    public class webEstadoVueloService : webBaseService, IwebEstadoVueloService
    //Hereda del servicio base e implementa la interfaz correspondiente

    {
        #region Constructor
        public webEstadoVueloService(string baseUrl)
    : base(baseUrl)
        {
            //Constructor con la base URL
        }
        #endregion

        #region CRUD

        #region CREATE
        public async Task Crear(EstadoVueloViewModel entidad)
        {
            await PostAsync<EstadoVueloViewModel>("estadovuelo", entidad).ConfigureAwait(false);
        }
        #endregion

        #region READ
        public async Task<List<EstadoVueloViewModel>> Listar()
        {
            return await GetAsync<List<EstadoVueloViewModel>>("estadovuelo").ConfigureAwait(false);
        }
        #endregion

        #region UPDATE
        public async Task Actualizar(EstadoVueloViewModel entidad)
        {
            await PutAsync<EstadoVueloViewModel>("estadovuelo", entidad).ConfigureAwait(false);
        }
        #endregion

        #region DELETE
        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"estadovuelo/{codigo}").ConfigureAwait(false);
        }
        #endregion 

        #region SEARCH
        public async Task<EstadoVueloViewModel> Buscar(string codigo)
        {
            return await GetAsync<EstadoVueloViewModel>($"estadovuelo/{codigo}").ConfigureAwait(false);
        }
        #endregion

        #endregion
    }
}
