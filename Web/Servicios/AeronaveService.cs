using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IAeronaveService
    {
        Task Crear(AeronaveViewModel aeronave);

        Task<List<AeronaveViewModel>> Listar();

        Task Actualizar(AeronaveViewModel aeronave);

        Task Eliminar(string codigo);

        Task<AeronaveViewModel> Buscar(string codigo);

        Task<List<AeronaveViewModel>> BuscarPorTipoAeronave(string codigo);

        Task<List<AeronaveViewModel>> AeronavesConDesperfecto();

        Task<List<AeronaveViewModel>> AeronavesConObservacion();

    }

    public class AeronaveService : ServicioBase, IAeronaveService
    //Hereda del servicio base e implementa la interfaz correspondiente

    {
        public AeronaveService(string baseUrl) : base(baseUrl)
        {
            //Constructor con la base URL
        }


        #region CRUD

        public async Task Crear(AeronaveViewModel aeronave)
        {
            await PostAsync<AeronaveViewModel>("aeronave", aeronave).ConfigureAwait(false);
        }

        public async Task<List<AeronaveViewModel>> Listar()
        {
            return await GetAsync<List<AeronaveViewModel>>("aeronave").ConfigureAwait(false);
        }

        public async Task Actualizar(AeronaveViewModel aeronave)
        {
            await PutAsync<AeronaveViewModel>("aeronave", aeronave).ConfigureAwait(false);
        }

        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"aeronave/{codigo}").ConfigureAwait(false);
        }

        #endregion


        public async Task<AeronaveViewModel> Buscar(string codigo)
        {
            return await GetAsync<AeronaveViewModel>($"aeronave/{codigo}").ConfigureAwait(false);
        }

        public async Task<List<AeronaveViewModel>> BuscarPorTipoAeronave(string codigo)
        {
            return await GetAsync<List<AeronaveViewModel>>($"aeronave/tipo-aeronave/{codigo}").ConfigureAwait(false);
        }

        public async Task<List<AeronaveViewModel>> AeronavesConDesperfecto()
        {
            return await GetAsync<List<AeronaveViewModel>>($"aeronave/desperfecto").ConfigureAwait(false);
        }

        public async Task<List<AeronaveViewModel>> AeronavesConObservacion()
        {
            return await GetAsync<List<AeronaveViewModel>>($"aeronave/observacion-prioritaria").ConfigureAwait(false);
        }
    }
}
