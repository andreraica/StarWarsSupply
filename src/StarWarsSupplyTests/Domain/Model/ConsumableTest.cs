namespace StarWarsSupplyTests.Domain.Model
{
    using StarWarsSupply.Domain.Models;
    using StarWarsSupply.Domain.Models.Enum;
    using Xunit;

    public class ConsumableTest
    {
        [Fact]
        public void Must_InstantiateCorrectConstructor()
        {
            var consumable = new Consumable(80, EPeriod.Month);
            Assert.Equal(80, consumable.Quantity);
            Assert.Equal(EPeriod.Month, consumable.Period);
        }

        [Theory]
        [InlineData("xyz", -1, EPeriod.Unknown)]
        [InlineData("", -1, EPeriod.Unknown)]
        [InlineData("unknown", -1, EPeriod.Unknown)]
        [InlineData("w xyz", -1, EPeriod.Unknown)]
        [InlineData("w days", -1, EPeriod.Day)]
        [InlineData("5 xyz", 5, EPeriod.Unknown)]
        [InlineData("4 days", 4, EPeriod.Day)]
        [InlineData("1 weeks", 1, EPeriod.Week)]
        [InlineData("3 months", 3, EPeriod.Month)]
        [InlineData("2 years", 2, EPeriod.Year)]
        public void Must_InstantiateCorrectConstructorByAPI(string consumablePeriod, int expectedQuantity, EPeriod expectedPeriod)
        {
            var consumable = new Consumable(consumablePeriod);
            Assert.Equal(expectedQuantity, consumable.Quantity);
            Assert.Equal(expectedPeriod, consumable.Period);
        }
    }
}
