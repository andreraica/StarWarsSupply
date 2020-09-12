using Domain.Interfaces.Services;
using Infrastructure.IoC;
using System;

namespace StarWarsSupplyConsole
{
    class Program
    {
        private static IStarshipService _starshipService;

        static void Main()
        {
            Configure();

            Console.WriteLine("************ ");
            Console.WriteLine("Simple application that calculate how many stops for resupply are required to cover a given distance in mega lights (MGLT) for each avaiable StarShip ");
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
            var containerInjection = Injector.Start();
            _starshipService = containerInjection.GetInstance<IStarshipService>();
        }
    }
}
