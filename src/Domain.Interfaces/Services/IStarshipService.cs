namespace StarWarsSupply.Domain.Interfaces.Services
{
    using System.Collections.Generic;
    using StarWarsSupply.Domain.Models;

    public interface IStarshipService
    {
        IEnumerable<Starship> GetStarships();
    }
}
