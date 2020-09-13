namespace StarWarsSupply.Domain.Models
{
    using System.Linq;
    using StarWarsSupply.Domain.Models.Enum;
    
    public class Consumable
    {
        private const short hoursPerDay = 24, errorNumber = -1;

        public Consumable(string consumableAPI)
        {
            ConsumableBuilder(consumableAPI);
        }

        public Consumable(int quantity, EPeriod period)
        {
            Quantity = quantity;
            Period = period;
        }

        public int Quantity { get; private set; }
        public EPeriod Period { get; private set; }

        public int GetHours()
        {
            return (Period != EPeriod.Unknown) ? (Quantity * hoursPerDay * (int)Period) : errorNumber;
        }

        private void ConsumableBuilder(string consumableAPI)
        {
            Period = EPeriod.Unknown;
            Quantity = errorNumber;

            var consumableAPISplited = consumableAPI.Split(" ");

            if (consumableAPISplited.Length == 2)
            {
                if (int.TryParse(consumableAPISplited[0], out int quantity))
                    Quantity = quantity;

                var consumable = consumableAPISplited[1].ToLower();

                var periodSearch = System.Enum.GetValues(typeof(EPeriod)).Cast<EPeriod>().ToList()
                    .Where(x => consumable.ToLower().Contains(x.ToString().ToLower()));

                Period = (periodSearch.Count() > 0) ? periodSearch.First() : EPeriod.Unknown;
            }
        }
    }
}