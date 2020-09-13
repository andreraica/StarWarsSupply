namespace StarWarsSupply.Domain.Services
{
    using System.Collections.Generic;
    using StarWarsSupply.Domain.Interfaces.Data.Repositories;
    using StarWarsSupply.Domain.Interfaces.Services;
    using StarWarsSupply.Domain.Models;

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
