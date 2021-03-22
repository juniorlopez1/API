using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IRegistroService
    {
        Task Crear(RegistroViewModel registro);
        Task<List<RegistroViewModel>> Listar();
        Task Actualizar(RegistroViewModel registro);
        Task Eliminar(string codigo);
        Task<RegistroViewModel> Buscar(string codigo);

    }


    public class RegistroService : ServicioBase, IRegistroService
    //Hereda del servicio base e implementa la interfaz correspondiente

    {
        public RegistroService(string baseUrl) : base(baseUrl)
        {
            //Constructor con la base URL
        }

        #region CRUD

        public async Task Crear(RegistroViewModel entidad)
        {
            await PostAsync<RegistroViewModel>("registro", entidad).ConfigureAwait(false);
        }
 
        public async Task<List<RegistroViewModel>> Listar()
        {
            return await GetAsync<List<RegistroViewModel>>("registro").ConfigureAwait(false);
        }
       
        public async Task Actualizar(RegistroViewModel entidad)
        {
            await PutAsync<RegistroViewModel>("registro", entidad).ConfigureAwait(false);
        }
    
        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"registro/{codigo}").ConfigureAwait(false);
        }

        #endregion

        public async Task<RegistroViewModel> Buscar(string codigo)
        {
            return await GetAsync<RegistroViewModel>($"registro/{codigo}").ConfigureAwait(false);
        }

    }
}
