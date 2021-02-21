namespace StarWarsSupply.Domain.Interfaces.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using StarWarsSupply.Domain.Models;

    public interface IStarshipService
    {
        Task<IEnumerable<Starship>> GetStarshipsAsync();
    }
}
