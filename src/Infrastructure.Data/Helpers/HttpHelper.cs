using Domain.Interfaces.Data.Helpers;
using System.Net.Http;

namespace Infrastructure.Data.Helpers
{
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
