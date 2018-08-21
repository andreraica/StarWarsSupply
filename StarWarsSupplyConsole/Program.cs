using Domain.Services;
using System;
using System.Configuration;

namespace StarWarsSupplyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("MGLT: ");
            long distanceMGLT = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Processing...");
            Console.WriteLine(" ");

            var starshipService = new StarshipService();
            foreach (var starship in starshipService.GetStarships())
                Console.WriteLine($"{starship.Name}: {starship.CalculateSupply(distanceMGLT)}");

            Console.WriteLine(" ");
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
