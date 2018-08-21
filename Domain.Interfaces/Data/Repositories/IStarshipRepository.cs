using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces.Data.Repositories
{
    public interface IStarshipRepository
    {
        IEnumerable<Starship> GetAllStarships();
    }
}
