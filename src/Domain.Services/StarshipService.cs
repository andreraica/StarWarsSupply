namespace StarWarsSupply.Domain.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
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

        public async Task<IEnumerable<Starship>> GetStarshipsAsync()
        {
            return await _starshipRepository.GetAllStarshipsAsync();
        }
    }
}
