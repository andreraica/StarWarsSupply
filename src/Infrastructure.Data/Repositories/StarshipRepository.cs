namespace StarWarsSupply.Infrastructure.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Polly;
    using Polly.Retry;
    using StarWarsSupply.Domain.Interfaces.Data.Helpers;
    using StarWarsSupply.Domain.Interfaces.Data.Repositories;
    using StarWarsSupply.Domain.Interfaces.IoC;
    using StarWarsSupply.Domain.Models;
    using StarWarsSupply.Infrastructure.Data.Models;

    public class StarshipRepository : IStarshipRepository
    {
        private const int MaxRetries = 3;
        private readonly AsyncRetryPolicy _retryPolicy;

        private readonly IHttpClient _httpClient;
        private readonly ISettings _settings;
        private List<Starship> _starships;
        

        public StarshipRepository(IHttpClient httpClient, ISettings settings)
        {
            _httpClient = httpClient;
            _settings = settings;
            _starships = new List<Starship>();
            _retryPolicy = Policy.Handle<Exception>().RetryAsync(MaxRetries);
        }

        public async Task<IEnumerable<Starship>> GetAllStarshipsAsync()
        {
            StarshipResultSWAPI starshipSWAPI = null;

            var urlSWAPI = _settings.GetAppSetting("UrlSWAPIConfiguration");

            do
            {
               await _retryPolicy.ExecuteAsync(async () =>
                {
                    var response = _httpClient.Get(urlSWAPI);

                    if (response.IsSuccessStatusCode)
                    {
                        var outputDataJson = response.Content.ReadAsStringAsync().Result;

                        starshipSWAPI = JsonConvert.DeserializeObject<StarshipResultSWAPI>(outputDataJson);
                        MapToDomain(starshipSWAPI.Results);
                        urlSWAPI = starshipSWAPI.Next;
                    }
                });

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
