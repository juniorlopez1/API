using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IRegistroService
    {
        //CREATE
        Task Crear(RegistroViewModel registro);

        //READ
        Task<List<RegistroViewModel>> Listar();

        //UPDATE
        Task Actualizar(RegistroViewModel registro);

        //DELETE
        Task Eliminar(string codigo);

        //SEARCH
        Task<RegistroViewModel> Buscar(string codigo);

    }


    public class RegistroService : ServicioBase, IRegistroService
    //Hereda del servicio base e implementa la interfaz correspondiente

    {
        #region Constructor
        public RegistroService(string baseUrl)
    : base(baseUrl)
        {
            //Constructor con la base URL
        }
        #endregion

        #region CRUD

        #region CREATE
        public async Task Crear(RegistroViewModel entidad)
        {
            await PostAsync<RegistroViewModel>("registro", entidad).ConfigureAwait(false);
        }
        #endregion

        #region READ
        public async Task<List<RegistroViewModel>> Listar()
        {
            return await GetAsync<List<RegistroViewModel>>("registro").ConfigureAwait(false);
        }
        #endregion

        #region UPDATE
        public async Task Actualizar(RegistroViewModel entidad)
        {
            await PutAsync<RegistroViewModel>("registro", entidad).ConfigureAwait(false);
        }
        #endregion

        #region DELETE
        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"registro/{codigo}").ConfigureAwait(false);
        }
        #endregion 

        #region SEARCH
        public async Task<RegistroViewModel> Buscar(string codigo)
        {
            return await GetAsync<RegistroViewModel>($"registro/{codigo}").ConfigureAwait(false);
        }
        #endregion

        #endregion
    }
}
