using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IAeronaveTipoService
    {
        //CREATE
        Task Crear(AeronaveTipoViewModel aeronave);

        //READ
        Task<List<AeronaveTipoViewModel>> Listar();

        //UPDATE
        Task Actualizar(AeronaveTipoViewModel aeronave);

        //DELETE
        Task Eliminar(string codigo);

        //SEARCH
        Task<AeronaveTipoViewModel> Buscar(string codigo);

    }

    public class AeronaveTipoService : ServicioBase, IAeronaveTipoService
    //Hereda del servicio base e implementa la interfaz correspondiente

    {
        #region Constructor
        public AeronaveTipoService(string baseUrl)
    : base(baseUrl)
        {
            //Constructor con la base URL
        }
        #endregion

        #region CRUD

        #region CREATE
        public async Task Crear(AeronaveTipoViewModel entidad)
        {
            await PostAsync<AeronaveTipoViewModel>("aeronavetipo", entidad).ConfigureAwait(false);
        }
        #endregion

        #region READ
        public async Task<List<AeronaveTipoViewModel>> Listar()
        {
            return await GetAsync<List<AeronaveTipoViewModel>>("aeronavetipo").ConfigureAwait(false);
        }
        #endregion

        #region UPDATE
        public async Task Actualizar(AeronaveTipoViewModel entidad)
        {
            await PutAsync<AeronaveTipoViewModel>("aeronavetipo", entidad).ConfigureAwait(false);
        }
        #endregion

        #region DELETE
        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"aeronavetipo/{codigo}").ConfigureAwait(false);
        }
        #endregion 

        #region SEARCH
        public async Task<AeronaveTipoViewModel> Buscar(string codigo)
        {
            return await GetAsync<AeronaveTipoViewModel>($"aeronavetipo/{codigo}").ConfigureAwait(false);
        }
        #endregion

        #endregion
    }
}
