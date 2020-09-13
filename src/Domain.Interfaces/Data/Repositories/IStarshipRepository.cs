namespace StarWarsSupply.Domain.Interfaces.Data.Repositories
{
    using System.Collections.Generic;
    using StarWarsSupply.Domain.Models;
    
    public interface IStarshipRepository
    {
        IEnumerable<Starship> GetAllStarships();
    }
}
