using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Dados;
using Desafio.Repositorio;
using FluentValidation.AspNetCore;
using Desafio.Filters;
using Desafio.Negocio;

namespace Desafio
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

            services.AddDbContext<ApplicationContext>();

            RegistraDI(services);

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers(op => op.Filters.Add(new ValidationFilter()))
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<Startup>();
                    options.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            services.AddSwaggerDocument(config =>
               config.PostProcess = document =>
               {
                   document.Info.Version = "v1";
                   document.Info.Title = "Desafio API";
               }
            );

        }

        private static void RegistraDI(IServiceCollection services)
        {
            services.AddScoped<IContaRepositorio, ContaRepositorio>();
            services.AddScoped<IContaNegocio, ContaNegocio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
