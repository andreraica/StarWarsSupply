using StarWarsSupply.Domain.Interfaces.Services;
using StarWarsSupply.Presentation.StarWarsSupply.WebAPI.ViewModel;

namespace StarWarsSupply.Presentation.StarWarsSupply.WebAPI.Conrollers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

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

            foreach (var starship in _starshipService.GetStarshipsAsync().Result)
                starShipsResupply.Add(new StarShipResupply(starship.Name, starship.CalculateSupply(distanceMGLT)));

            return starShipsResupply;
        }
    }
}
