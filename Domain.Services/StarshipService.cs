using Domain.Interfaces.Data.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System.Collections.Generic;

namespace Domain.Services
{
    public class StarshipService : IStarshipService
    {
        private readonly IStarshipRepository _starshipRepository;

        public StarshipService(IStarshipRepository starshipRepository)
        {
            _starshipRepository = starshipRepository;
        }

        public IEnumerable<Starship> GetStarships()
        {
            return _starshipRepository.GetAllStarships();
        }
    }
}
