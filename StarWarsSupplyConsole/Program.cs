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

            long distanceMGLT = 0;
            if (Int64.TryParse(Console.ReadLine(), out distanceMGLT))
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
            var containerInjection = Injector.Start();
            _starshipService = containerInjection.GetInstance<IStarshipService>();
        }
    }
}
