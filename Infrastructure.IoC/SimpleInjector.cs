using Domain.Interfaces.Data.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
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

            container.Verify();

            return container;
        }
        
    }
}
