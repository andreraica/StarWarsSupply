using Infrastructure.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace StarWarsSupplyTests.Infrastructure.Data.Stub
{
    public class StarshipHttpResponseStub
    {
        public static HttpResponseMessage AllPage1()
        {
            var starshipResultSWAPI = new StarshipResultSWAPI()
            {
                Count = 3,
                Next = "page2",
                Results = new List<StarshipSWAPI>()
                {
                    new StarshipSWAPI()
                    {
                        Name = "Millennium Falcon",
                        Consumables = "2 months",
                        MGLT = "75"
                    },
                    new StarshipSWAPI()
                    {
                        Name = "Y-wing",
                        Consumables = "1 week",
                        MGLT = "80"
                    }
                }
            };

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(
                JsonConvert.SerializeObject(starshipResultSWAPI), System.Text.Encoding.UTF8, "application/json")
            };
        }

        public static HttpResponseMessage AllPage2()
        {
            var starshipResultSWAPI = new StarshipResultSWAPI()
            {
                Count = 1,
                Next = null,
                Results = new List<StarshipSWAPI>()
                {
                    new StarshipSWAPI()
                    {
                        Name = "X-wing",
                        Consumables = "1 week",
                        MGLT = "100"
                    }
                }
            };

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(
                JsonConvert.SerializeObject(starshipResultSWAPI), System.Text.Encoding.UTF8, "application/json")
            };
        }

        public static HttpResponseMessage NotFound()
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
            {
                Content = new StringContent(
                JsonConvert.SerializeObject(""), System.Text.Encoding.UTF8, "application/json")
            };
        }

        public static HttpResponseMessage WrongFormatJson()
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
            {
                Content = new StringContent(
                JsonConvert.SerializeObject("XYZ"), System.Text.Encoding.UTF8, "application/json")
            };
        }
    }
}
