using Domain.Interfaces.Services;
using Infrastructure.IoC;
using System;

namespace StarWarsSupplyConsole
{
    class Program
    {
        private static IStarshipService _starshipService;

        static void Main(string[] args)
        {
            Configure();

            Console.Write("MGLT: ");
            long distanceMGLT = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Processing...\n");

            foreach (var starship in _starshipService.GetStarships())
                Console.WriteLine($"{starship.Name}: {starship.CalculateSupply(distanceMGLT)}");

            Console.WriteLine("\nPress enter to close...");
            Console.ReadLine();
        }

        private static void Configure()
        {
            var containerInjection = Injector.Start();
            _starshipService = containerInjection.GetInstance<IStarshipService>();
        }
    }
}
