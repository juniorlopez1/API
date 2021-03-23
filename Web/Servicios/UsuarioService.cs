using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IUsuarioService
    {
        Task Crear(UsuarioViewModel usuario);
        Task<List<UsuarioViewModel>> Listar();
        Task Actualizar(UsuarioViewModel usuario);
        Task Eliminar(string codigo);
        Task<UsuarioViewModel> Buscar(string codigo);
        Task<UsuarioViewModel> BuscarPorNombreUsuario(string nombreUsuario);
        Task<UsuarioViewModel> BuscarPorId(string id);
        Task<List<UsuarioViewModel>> BuscarEstadoUsuario (string estado);
        Task<UsuarioViewModel> Autenticar(CredencialesViewModel credenciales);
        
    }

    public class UsuarioService : ServicioBase, IUsuarioService
    //Hereda del servicio base e implementa la interfaz correspondiente

    {
        public UsuarioService(string baseUrl) : base(baseUrl)
        {
            //Constructor con la base URL
        }

        #region CRUD

        public async Task Crear(UsuarioViewModel entidad)
        {
            await PostAsync<UsuarioViewModel>("usuario", entidad).ConfigureAwait(false);
        }

        public async Task<List<UsuarioViewModel>> Listar()
        {
            return await GetAsync<List<UsuarioViewModel>>("usuario").ConfigureAwait(false);
        }
     
        public async Task Actualizar(UsuarioViewModel entidad)
        {
            await PutAsync<UsuarioViewModel>("usuario", entidad).ConfigureAwait(false);
        }
        
        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"usuario/{codigo}").ConfigureAwait(false);
        }
        
        #endregion

        public async Task<UsuarioViewModel> Buscar(string codigo)
        {
            return await GetAsync<UsuarioViewModel>($"usuario/{codigo}").ConfigureAwait(false);
        }

        public async Task<List<UsuarioViewModel>> BuscarEstadoUsuario(string estado)
        {
            return await GetAsync<List<UsuarioViewModel>>($"usuario/estado/{estado}").ConfigureAwait(false);
        }
        public async Task<UsuarioViewModel> Autenticar(CredencialesViewModel credenciales)
        {
            return await PostAsync<CredencialesViewModel, UsuarioViewModel>("usuario/autenticar", credenciales);
        }

        public async Task<UsuarioViewModel> BuscarPorNombreUsuario(string nombreUsuario)
        {
            return await GetAsync<UsuarioViewModel>($"usuario/nombre-usuario/{nombreUsuario}").ConfigureAwait(false);
        }

        public async Task<UsuarioViewModel> BuscarPorId(string id)
        {
            return await GetAsync<UsuarioViewModel>($"usuario/id/{id}").ConfigureAwait(false);
        }
    }
}
