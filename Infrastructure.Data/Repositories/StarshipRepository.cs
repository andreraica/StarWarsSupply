using Domain.Interfaces.Data.Repositories;
using Domain.Models;
using Infrastructure.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

namespace Infrastructure.Data.Repositories
{
    public class StarshipRepository : IStarshipRepository
    {
        List<Starship> starships;

        public StarshipRepository()
        {
            starships = new List<Starship>();
        }

        public IEnumerable<Starship> GetAllStarships()
        {
            var urlSWAPI = ConfigurationManager.AppSettings["UrlSWAPIConfiguration"].ToString();
            StarshipResultSWAPI starshipSWAPI = null;

            do
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(urlSWAPI).Result;
                    var outputDataJson = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        starshipSWAPI = JsonConvert.DeserializeObject<StarshipResultSWAPI>(outputDataJson);
                        MapToDomain(starshipSWAPI.results);
                    }
                }
                urlSWAPI = starshipSWAPI.next;

            } while (starshipSWAPI != null && !string.IsNullOrEmpty(starshipSWAPI.next));

            return starships;
        }

        private void MapToDomain(IEnumerable<StarshipSWAPI> starshipsSWAPI)
        {
            foreach (var starshipSWAPI in starshipsSWAPI)
            {
                int mGLT = 0;
                int.TryParse(starshipSWAPI.MGLT, out mGLT);

                starships.Add(new Starship(
                    starshipSWAPI.Name, mGLT, new Consumable(starshipSWAPI.Consumables))
                    );
            }
        }
    }
}
