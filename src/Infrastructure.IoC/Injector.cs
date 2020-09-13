namespace StarWarsSupply.Infrastructure.IoC
{
    using System.Configuration;
    using SimpleInjector;
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
        public static Container Start()
        {
            var container = new Container();

            container.Register<IStarshipService, StarshipService>();
            container.Register<IStarshipRepository, StarshipRepository>();
            container.Register<IHttpClient, HttpHelper>();

            container.Register<ISettings, Settings>();

            container.RegisterInitializer<Settings>(settings =>
            {
                settings.AppSettings = ConfigurationManager.AppSettings;
            });

            container.Verify();

            return container;
        }
        
    }
}
