using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using StarWarsSupplyWebAPI.ViewModel;
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

        [HttpGet("{distanceMGLT}")]
        public List<StarShipResupply> Get(long distanceMGLT)
        {
            var starShipsResupply = new List<StarShipResupply>();

            foreach (var starship in _starshipService.GetStarships())
                starShipsResupply.Add(new StarShipResupply(starship.Name, starship.CalculateSupply(distanceMGLT)));

            return starShipsResupply;
        }
    }
}
