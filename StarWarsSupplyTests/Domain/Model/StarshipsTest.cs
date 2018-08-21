using Domain.Models;
using Domain.Models.Enum;
using Xunit;

namespace StarWarsSupplyTests.Domain.Model
{
    public class StarshipsTest
    {
        [Theory]
        [InlineData(1000000, 80, 1, EPeriod.Week, 74)]
        [InlineData(1000000, 75, 2, EPeriod.Month, 9)]
        [InlineData(1000000, 20, 6, EPeriod.Month, 11)]
        [InlineData(1000000, 20, 123, EPeriod.Unknown, -1)]
        [InlineData(1000000, 0, 1, EPeriod.Year, -1)]
        public void Must_CalculateNumbersSupply(long distanceMGLT, int starshipMGLT, int consumableQuantity, EPeriod consumablePeriod, long expectedResult)
        {
            var consumable = new Consumable(consumableQuantity, consumablePeriod);
            var starship = new Starship(string.Empty, starshipMGLT, consumable);

            var result = starship.CalculateSupply(distanceMGLT);

            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData(1000000, 80, "1 week", 74)]
        [InlineData(1000000, 75, "2 months", 9)]
        [InlineData(1000000, 20, "6 months", 11)]
        [InlineData(1000000, 321, "unknown", -1)]
        [InlineData(1000000, 123, "", -1)]
        [InlineData(1000000, 231, "xyz", -1)]
        [InlineData(1000000, 0, "1 year", -1)]
        public void Must_CalculateNumbersSupply_CalledByAPI(long distanceMGLT, int starshipMGLT, string consumableAPI, long expectedResult)
        {
            var consumable = new Consumable(consumableAPI);
            var starship = new Starship(string.Empty, starshipMGLT, consumable);

            var result = starship.CalculateSupply(distanceMGLT);

            Assert.Equal(result, expectedResult);
        }
    }
}
