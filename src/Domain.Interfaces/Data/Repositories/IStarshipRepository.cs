namespace StarWarsSupply.Domain.Interfaces.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using StarWarsSupply.Domain.Models;
    
    public interface IStarshipRepository
    {
        Task<IEnumerable<Starship>> GetAllStarshipsAsync();
    }
}
