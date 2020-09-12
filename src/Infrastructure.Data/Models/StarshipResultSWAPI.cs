using System.Collections.Generic;

namespace Infrastructure.Data.Models
{
    public class StarshipResultSWAPI : SWAPI
    {
        public IEnumerable<StarshipSWAPI> Results { get; set; }
    }
}
