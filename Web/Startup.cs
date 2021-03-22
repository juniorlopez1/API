using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Servicios;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var baseurl = @"https://localhost:5001/api";
            services.AddControllersWithViews();
            services.AddScoped<IAeronaveService>((x) => new AeronaveService(baseurl));
            services.AddScoped<IAeronaveTipoService>((x) => new AeronaveTipoService(baseurl));
            services.AddScoped<IEstadoVueloService>((x) => new EstadoVueloService(baseurl));
            services.AddScoped<IObservacionService>((x) => new ObservacionService(baseurl));
            services.AddScoped<IPerfilService>((x) => new PerfilService(baseurl));
            services.AddScoped<IRegistroService>((x) => new RegistroService(baseurl));
            services.AddScoped <IUsuarioService>((x) => new UsuarioService(baseurl));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Usuario}/{action=Login}/{id?}");
            });
        }
    }
}
