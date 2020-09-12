using Domain.Interfaces.Data.Helpers;
using Domain.Interfaces.Data.Repositories;
using Domain.Interfaces.IoC;
using Domain.Models;
using Infrastructure.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class StarshipRepository : IStarshipRepository
    {
        private readonly IHttpClient _httpClient;
        private readonly ISettings _settings;
        private List<Starship> _starships;

        public StarshipRepository(IHttpClient httpClient, ISettings settings)
        {
            _httpClient = httpClient;
            _settings = settings;
            _starships = new List<Starship>();
        }

        public IEnumerable<Starship> GetAllStarships()
        {
            StarshipResultSWAPI starshipSWAPI = null;

            var urlSWAPI = _settings.GetAppSetting("UrlSWAPIConfiguration");

            do
            {
                var response = _httpClient.Get(urlSWAPI);
                var outputDataJson = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    starshipSWAPI = JsonConvert.DeserializeObject<StarshipResultSWAPI>(outputDataJson);
                    MapToDomain(starshipSWAPI.Results);
                    urlSWAPI = starshipSWAPI.Next;
                }

            } while (starshipSWAPI != null && !string.IsNullOrEmpty(starshipSWAPI.Next));

            return _starships;
        }

        private void MapToDomain(IEnumerable<StarshipSWAPI> starshipsSWAPI)
        {
            foreach (var starshipSWAPI in starshipsSWAPI)
            {
                int.TryParse(starshipSWAPI.MGLT, out int mGLT);

                _starships.Add(new Starship(
                    starshipSWAPI.Name, mGLT, new Consumable(starshipSWAPI.Consumables))
                    );
            }
        }
    }
}
