using System.Net.Http;

namespace Domain.Interfaces.Data.Helpers
{
    public interface IHttpClient
    {
        HttpResponseMessage Get(string url);
    }
}
