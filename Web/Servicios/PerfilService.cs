using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IPerfilService
    {
        Task Crear(PerfilViewModel perfil);
        Task<List<PerfilViewModel>> Listar();
        Task Actualizar(PerfilViewModel perfil);
        Task Eliminar(string codigo);
        Task<PerfilViewModel> Buscar(string codigo); 

    }

    public class PerfilService : ServicioBase, IPerfilService
        //Hereda del servicio base e implementa la interfaz correspondiente

    {
        public PerfilService(string baseUrl) : base(baseUrl)
        {
            //Constructor con la base URL
        } 

        #region CRUD

        public async Task Crear(PerfilViewModel entidad)
        {
            await PostAsync<PerfilViewModel>("perfil", entidad).ConfigureAwait(false);
        }
        
        public async Task<List<PerfilViewModel>> Listar()
        {
            return await GetAsync<List<PerfilViewModel>>("perfil").ConfigureAwait(false);
        }
      
        public async Task Actualizar(PerfilViewModel entidad)
        {
            await PutAsync<PerfilViewModel>("perfil", entidad).ConfigureAwait(false);
        }
   
        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"perfil/{codigo}").ConfigureAwait(false);
        }

        #endregion

        public async Task<PerfilViewModel> Buscar(string codigo)
        {
            return await GetAsync<PerfilViewModel>($"perfil/{codigo}").ConfigureAwait(false);
        }
        
    }

}
