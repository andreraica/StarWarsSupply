namespace StarWarsSupply.Presentation.StarWarsSupplyConsole
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using StarWarsSupply.Domain.Interfaces.Services;
    using StarWarsSupply.Infrastructure.IoC;

    class Program
    {
        private static IStarshipService _starshipService;
        private static ServiceProvider _serviceProvider;

        static void Main()
        {
            Configure();

            Console.WriteLine("************ ");
            Console.WriteLine("This simple application calculates how many resupply stops are required to cover a given distance in mega lights (MGLT) for each avaiable StarShip ");
            Console.WriteLine("************ ");
            Console.Write("Input the distance in MGLT: ");

            if (long.TryParse(Console.ReadLine(), out long distanceMGLT))
            {
                Console.WriteLine("Processing...\n");

                foreach (var starship in _starshipService.GetStarships())
                    Console.WriteLine($"{starship.Name}: {starship.CalculateSupply(distanceMGLT)}");

                Console.WriteLine("\nDone.\nPress enter to close...");
            }
            else
                Console.WriteLine("\nInconsistent input MGLT...");

            Console.ReadLine();
        }

        private static void Configure()
        {
            var services = Injector.StartConsole(new ServiceCollection());

            _serviceProvider = services.BuildServiceProvider(true);
            _starshipService = _serviceProvider.GetService<IStarshipService>();
        }
    }
}
