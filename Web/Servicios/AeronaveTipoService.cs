using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IAeronaveTipoService
    {
        Task Crear(AeronaveTipoViewModel aeronave);

        Task<List<AeronaveTipoViewModel>> Listar();

        Task Actualizar(AeronaveTipoViewModel aeronave);

        Task Eliminar(string codigo);

        Task<AeronaveTipoViewModel> Buscar(string codigo);

    }

    public class AeronaveTipoService : ServicioBase, IAeronaveTipoService
    //Hereda del servicio base e implementa la interfaz correspondiente

    {
        public AeronaveTipoService(string baseUrl) : base(baseUrl)
        {
            //Constructor con la base URL
        }


        #region CRUD

        public async Task Crear(AeronaveTipoViewModel entidad)
        {
            await PostAsync<AeronaveTipoViewModel>("aeronavetipo", entidad).ConfigureAwait(false);
        }

        public async Task<List<AeronaveTipoViewModel>> Listar()
        {
            return await GetAsync<List<AeronaveTipoViewModel>>("aeronavetipo").ConfigureAwait(false);
        }

        public async Task Actualizar(AeronaveTipoViewModel entidad)
        {
            await PutAsync<AeronaveTipoViewModel>("aeronavetipo", entidad).ConfigureAwait(false);
        }
  
        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"aeronavetipo/{codigo}").ConfigureAwait(false);
        }

        #endregion



        public async Task<AeronaveTipoViewModel> Buscar(string codigo)
        {
            return await GetAsync<AeronaveTipoViewModel>($"aeronavetipo/{codigo}").ConfigureAwait(false);
        }


        
    }
}
