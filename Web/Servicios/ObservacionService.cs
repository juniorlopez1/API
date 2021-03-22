using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IObservacionService
    {
        Task Crear(ObservacionViewModel observacion);
        Task<List<ObservacionViewModel>> Listar();
        Task Actualizar(ObservacionViewModel observacion);
        Task Eliminar(string codigo);
        Task<ObservacionViewModel> Buscar(string codigo);
    }

    public class ObservacionService : ServicioBase, IObservacionService
    //Hereda del servicio base e implementa la interfaz correspondiente

    {
        public ObservacionService(string baseUrl)   : base(baseUrl)
        {
            //Constructor con la base URL
        }

        #region CRUD

        public async Task Crear(ObservacionViewModel entidad)
        {
            await PostAsync<ObservacionViewModel>("observacion", entidad).ConfigureAwait(false);
        }

        public async Task<List<ObservacionViewModel>> Listar()
        {
            return await GetAsync<List<ObservacionViewModel>>("observacion").ConfigureAwait(false);
        }

        public async Task Actualizar(ObservacionViewModel entidad)
        {
            await PutAsync<ObservacionViewModel>("observacion", entidad).ConfigureAwait(false);
        }

        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"observacion/{codigo}").ConfigureAwait(false);
        }

        #endregion

        public async Task<ObservacionViewModel> Buscar(string codigo)
        {
            return await GetAsync<ObservacionViewModel>($"observacion/{codigo}").ConfigureAwait(false);
        }

    }
}
