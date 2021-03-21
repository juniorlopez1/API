using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IObservacionService
    {
        //CREATE
        Task Crear(ObservacionViewModel observacion);

        //READ
        Task<List<ObservacionViewModel>> Listar();

        //UPDATE
        Task Actualizar(ObservacionViewModel observacion);

        //DELETE
        Task Eliminar(string codigo);

        //SEARCH
        Task<ObservacionViewModel> Buscar(string codigo);

    }

    public class ObservacionService : ServicioBase, IObservacionService
    //Hereda del servicio base e implementa la interfaz correspondiente

    {
        #region Constructor
        public ObservacionService(string baseUrl)
    : base(baseUrl)
        {
            //Constructor con la base URL
        }
        #endregion

        #region CRUD

        #region CREATE
        public async Task Crear(ObservacionViewModel entidad)
        {
            await PostAsync<ObservacionViewModel>("observacion", entidad).ConfigureAwait(false);
        }
        #endregion

        #region READ
        public async Task<List<ObservacionViewModel>> Listar()
        {
            return await GetAsync<List<ObservacionViewModel>>("observacion").ConfigureAwait(false);
        }
        #endregion

        #region UPDATE
        public async Task Actualizar(ObservacionViewModel entidad)
        {
            await PutAsync<ObservacionViewModel>("observacion", entidad).ConfigureAwait(false);
        }
        #endregion

        #region DELETE
        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"observacion/{codigo}").ConfigureAwait(false);
        }
        #endregion 

        #region SEARCH
        public async Task<ObservacionViewModel> Buscar(string codigo)
        {
            return await GetAsync<ObservacionViewModel>($"observacion/{codigo}").ConfigureAwait(false);
        }
        #endregion

        #endregion
    }
}
