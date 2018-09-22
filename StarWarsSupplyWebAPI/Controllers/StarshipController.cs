using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StarWarsSupplyWebAPI.Conrollers
{
    [Route("api/[controller]")]
    public class StarshipController : Controller
    {
        private readonly IStarshipService _starshipService;

        public StarshipController(IStarshipService starshipService)
        {
            _starshipService = starshipService;
        }

        [HttpGet]
        public IEnumerable<Starship> Get()
        {
            return _starshipService.GetStarships();
        }
    }
}
