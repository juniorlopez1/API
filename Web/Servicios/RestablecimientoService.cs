using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public interface IRestablecimientoService
    {
        Task Crear(RestablecimientoViewModel restablecimiento);
        Task<RestablecimientoViewModel> Buscar(string codigo);
        Task Eliminar(string codigo);

        Task EnviarRestablecimiento(string direccion, string codigo);
    }

    public class RestablecimientoService : ServicioBase, IRestablecimientoService
    {
        private IEmailService emailService;

        public RestablecimientoService(string baseUrl, IEmailService emailService) 
            : base(baseUrl)
        {
            //Constructor con la base URL
            this.emailService = emailService;
        }


    public async Task<RestablecimientoViewModel> Buscar(string codigo)
        {
            return await GetAsync<RestablecimientoViewModel>($"restablecimiento/{codigo}").ConfigureAwait(false);
        }

        public async Task Crear(RestablecimientoViewModel restablecimiento)
        {
            await PostAsync("restablecimiento", restablecimiento).ConfigureAwait(false);
        }

        public async Task Eliminar(string codigo)
        {
            await DeleteAsync($"restablecimiento/{codigo}").ConfigureAwait(false);
        }

        public async Task EnviarRestablecimiento(string direccion, string codigo)
        {
            var url = $"https://localhost:44368/restablecimiento/Restablecer/{codigo}";
            string mensaje = $"<a href=\"{url}\">Haga clic para restablecer su contrasena</a>";
            await Task.Factory.StartNew(() => emailService.Enviar(direccion, "Restablecer contrasena", true, mensaje));
        }
    }
}
