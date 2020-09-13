namespace StarWarsSupply.Domain.Interfaces.Data.Helpers
{
    using System.Net.Http;

    public interface IHttpClient
    {
        HttpResponseMessage Get(string url);
    }
}
