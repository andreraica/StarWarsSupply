namespace StarWarsSupply.Infrastructure.Data.Helpers
{
    using System.Net.Http;
    using StarWarsSupply.Domain.Interfaces.Data.Helpers;
    
    public class HttpHelper : IHttpClient
    {
        public HttpResponseMessage Get(string url)
        {
            using (var client = new HttpClient())
            {
                return client.GetAsync(url).Result;
            }
        }
    }
}
