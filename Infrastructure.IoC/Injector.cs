using Domain.Interfaces.Data.Helpers;
using Domain.Interfaces.Data.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Infrastructure.Data.Helpers;
using Infrastructure.Data.Repositories;
using SimpleInjector;

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

            container.Verify();

            return container;
        }
        
    }
}
