using Domain.Interfaces.Data.Helpers;
using Domain.Interfaces.Data.Repositories;
using Domain.Interfaces.IoC;
using Domain.Interfaces.Services;
using Domain.Services;
using Infrastructure.Data.Helpers;
using Infrastructure.Data.Repositories;
using Infrastructure.IoC.Setting;
using SimpleInjector;
using System.Configuration;

namespace Infrastructure.IoC
{
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
