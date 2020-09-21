using StarWarsSupply.Infrastructure.IoC;
using StarWarsSupply.Domain.Interfaces.Services;
using StarWarsSupply.Domain.Services;

namespace StarWarsSupply.Presentation.StarWarsSupply.WebAPI
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen();

            RegisterInjector(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarWars Supply Calculator API V1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterInjector(IServiceCollection services)
        {
            services = Injector.Start(services);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}