using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IwebAeronaveService
    {
        //CREATE
        Task Crear(AeronaveViewModel aeronave);

        //READ
        Task<List<AeronaveViewModel>> Listar();

        //UPDATE
        Task Actualizar(AeronaveViewModel aeronave);

        //DELETE
        Task Eliminar(string codigo);

        //SEARCH
        Task<AeronaveViewModel> Buscar(string codigo);

    }

    public class webAeronaveService : webBaseService, IwebAeronaveService
    //Hereda del servicio base e implementa la interfaz correspondiente

    {
        #region Constructor
        public webAeronaveService(string baseUrl)
    : base(baseUrl)
        {
            //Constructor con la base URL
        }
        #endregion

        #region CRUD

        #region CREATE
        public async Task Crear(AeronaveViewModel aeronave)
        {
            await PostAsync<AeronaveViewModel>("aeronave", aeronave).ConfigureAwait(false);
        }
        #endregion

        #region READ
        public async Task<List<AeronaveViewModel>> Listar()
        {
            return await GetAsync<List<AeronaveViewModel>>("aeronave").ConfigureAwait(false);
        }
        #endregion

        #region UPDATE
        public async Task Actualizar(AeronaveViewModel aeronave)
        {
            await PutAsync<AeronaveViewModel>("aeronave", aeronave).ConfigureAwait(false);
        }
        #endregion

        #region DELETE
        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"aeronave/{codigo}").ConfigureAwait(false);
        }
        #endregion 

        #region SEARCH
        public async Task<AeronaveViewModel> Buscar(string codigo)
        {
            return await GetAsync<AeronaveViewModel>($"aeronave/{codigo}").ConfigureAwait(false);
        }
        #endregion

        #endregion
    }
}
