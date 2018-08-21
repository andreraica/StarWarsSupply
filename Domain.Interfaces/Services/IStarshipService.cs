using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IStarshipService
    {
        IEnumerable<Starship> GetStarships();
    }
}
