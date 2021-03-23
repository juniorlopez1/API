using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IEstadoVueloService
    {
        Task Crear(EstadoVueloViewModel estadoVuelo);

        Task<List<EstadoVueloViewModel>> Listar();

        Task Actualizar(EstadoVueloViewModel estadoVuelo);

        Task Eliminar(string codigo);

        Task<EstadoVueloViewModel> Buscar(string codigo);

    }

    public class EstadoVueloService : ServicioBase, IEstadoVueloService
    //Hereda del servicio base e implementa la interfaz correspondiente

    {
        public EstadoVueloService(string baseUrl) : base(baseUrl)
        {
            //Constructor con la base URL
        }

        #region CRUD

        public async Task Crear(EstadoVueloViewModel entidad)
        {
            await PostAsync<EstadoVueloViewModel>("estadovuelo", entidad).ConfigureAwait(false);
        }

        public async Task<List<EstadoVueloViewModel>> Listar()
        {
            return await GetAsync<List<EstadoVueloViewModel>>("estadovuelo").ConfigureAwait(false);
        }

        public async Task Actualizar(EstadoVueloViewModel entidad)
        {
            await PutAsync<EstadoVueloViewModel>("estadovuelo", entidad).ConfigureAwait(false);
        }

        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"estadovuelo/{codigo}").ConfigureAwait(false);
        }

        #endregion


        public async Task<EstadoVueloViewModel> Buscar(string codigo)
        {
            return await GetAsync<EstadoVueloViewModel>($"estadovuelo/{codigo}").ConfigureAwait(false);
        }

        public async Task<EstadoVueloViewModel> BuscarEstadoVuelo (string descripcion)
        {
            return await GetAsync<EstadoVueloViewModel>($"estadovuelo/{descripcion}").ConfigureAwait(false);
        }

    }
}
