using Acceso;
using Datos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {

        #region Net Core
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        } 

        public IConfiguration Configuration { get; }
        #endregion


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //CORS para que un dominio distinto se pueda accesar
            services.AddCors(options =>
            {
                options.AddPolicy(name: "DefaultCorsPolicy",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                             .AllowAnyMethod()
                                             .AllowAnyHeader();
                                  });
            });


            #region string conexion mongodb
            //Obtiene configuracion de db y connection string
            var conexionString = Configuration.GetSection("DatabaseSettings").GetSection("ConnectionString").Value;

            //Obtiene configuracion y nombre de la db
            var nombreBD = Configuration.GetSection("DatabaseSettings").GetSection("DatabaseName").Value; 
            #endregion

            //NET Core agrega por defecto los controllers
            services.AddControllers();

            #region region para agregar servicios
            //Se agrega la interfaz y servicio respectivo
            services.AddScoped<IAeronaveService, AeronaveService>();
            services.AddScoped<IAeronaveTipoService, AeronaveTipoService>();
            services.AddScoped<IEstadoVueloService, EstadoVueloService>();
            services.AddScoped<IObservacionService, ObservacionService>();
            services.AddScoped<IPerfilService, PerfilService>();
            services.AddScoped<IRegistroService, RegistroService > ();
            services.AddScoped<IUsuarioService, UsuarioService>();

            //Se enlaza con la capa de acceso a datos y base de datos
            services.AddScoped((factory) => new DatosAeronave(conexionString, nombreBD));
            services.AddScoped((factory) => new DatosAeronaveTipo(conexionString, nombreBD));
            services.AddScoped((factory) => new DatosEstadoVuelo(conexionString, nombreBD));
            services.AddScoped((factory) => new DatosObservacion(conexionString, nombreBD));
            services.AddScoped((factory) => new DatosPerfil(conexionString, nombreBD));
            services.AddScoped((factory) => new DatosRegistro(conexionString, nombreBD));
            services.AddScoped((factory) => new DatosUsuario(conexionString, nombreBD));

            #endregion
        }

        #region Net Core
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //CORS para que un dominio distinto se pueda accesar
            app.UseCors("DefaultCorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        } 
        #endregion
    }
}
