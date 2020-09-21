namespace StarWarsSupply.Infrastructure.IoC
{
    using System.Configuration;

    using Microsoft.Extensions.DependencyInjection;

    using StarWarsSupply.Domain.Interfaces.Data.Helpers;
    using StarWarsSupply.Domain.Interfaces.Data.Repositories;
    using StarWarsSupply.Domain.Interfaces.IoC;
    using StarWarsSupply.Domain.Interfaces.Services;
    using StarWarsSupply.Domain.Services;
    using StarWarsSupply.Infrastructure.Data.Helpers;
    using StarWarsSupply.Infrastructure.Data.Repositories;
    using StarWarsSupply.Infrastructure.IoC.Setting;

    public static class Injector
    {
        public static IServiceCollection Start(IServiceCollection services)
        {
            services.AddScoped<IStarshipService, StarshipService>();
            services.AddScoped<IStarshipRepository, StarshipRepository>();
            services.AddScoped<IHttpClient, HttpHelper>();

            services.AddSingleton<ISettings>(new Settings()
            {
                AppSettings = ConfigurationManager.AppSettings
            });

            return services;
        }

        public static IServiceCollection StartConsole(IServiceCollection services)
        {
            services.AddSingleton<IStarshipService, StarshipService>();
            services.AddSingleton<IStarshipRepository, StarshipRepository>();
            services.AddSingleton<IHttpClient, HttpHelper>();

            services.AddSingleton<ISettings>(new Settings()
            {
                AppSettings = ConfigurationManager.AppSettings
            });

            return services;
        }
    }
}
