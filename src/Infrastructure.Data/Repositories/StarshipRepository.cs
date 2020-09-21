namespace StarWarsSupply.Infrastructure.Data.Repositories
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using StarWarsSupply.Domain.Interfaces.Data.Helpers;
    using StarWarsSupply.Domain.Interfaces.Data.Repositories;
    using StarWarsSupply.Domain.Interfaces.IoC;
    using StarWarsSupply.Domain.Models;
    using StarWarsSupply.Infrastructure.Data.Models;

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
                
                if (response.IsSuccessStatusCode)
                {
                    var outputDataJson = response.Content.ReadAsStringAsync().Result;

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
