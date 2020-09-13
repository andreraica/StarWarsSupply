namespace StarWarsSupplyTests.Infrastructure.Data.Repositories
{
    using System.Linq;
    using Moq;
    using Xunit;
    using StarWarsSupply.Domain.Interfaces.Data.Helpers;
    using StarWarsSupply.Domain.Interfaces.IoC;
    using StarWarsSupply.Infrastructure.Data.Repositories;
    using StarWarsSupplyTests.Infrastructure.Data.Stub;

    public class StarshipRepositoryTest
    {
        Mock<ISettings> settingsMock = new Mock<ISettings>();
        Mock<IHttpClient> httpClientMock = new Mock<IHttpClient>();

        public StarshipRepositoryTest()
        {
            settingsMock.Setup(s => s.GetAppSetting("UrlSWAPIConfiguration")).Returns(string.Empty);
        }

        [Fact]
        public void Must_Get_3_Starships()
        {
            httpClientMock.Setup(h => h.Get(string.Empty)).Returns(StarshipHttpResponseStub.AllPage1());
            httpClientMock.Setup(h => h.Get("page2")).Returns(StarshipHttpResponseStub.AllPage2());

            var starshipRepository = new StarshipRepository(httpClientMock.Object, settingsMock.Object);
            var starships = starshipRepository.GetAllStarships();

            Assert.Equal(3, starships.Count());
        }

        [Fact]
        public void Not_Must_Get_Starship_HttpError()
        {
            httpClientMock.Setup(h => h.Get(string.Empty)).Returns(StarshipHttpResponseStub.NotFound());

            var starshipRepository = new StarshipRepository(httpClientMock.Object, settingsMock.Object);
            var starships = starshipRepository.GetAllStarships();

            Assert.Empty(starships);
        }
    }
}
