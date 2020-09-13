namespace StarWarsSupply.Infrastructure.Data.Models
{
    using System.Collections.Generic;

    public class StarshipResultSWAPI : SWAPI
    {
        public IEnumerable<StarshipSWAPI> Results { get; set; }
    }
}
