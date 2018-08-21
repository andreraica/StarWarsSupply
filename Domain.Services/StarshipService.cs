using System.Collections.Generic;
using Domain.Interfaces.Services;
using Domain.Models;
using Infrastructure.Data.Repositories;

namespace Domain.Services
{
    public class StarshipService : IStarshipService
    {
        public IEnumerable<Starship> GetStarships()
        {
            var starshipRepository = new StarshipRepository();
            return starshipRepository.GetAllStarships();
        }
    }
}
