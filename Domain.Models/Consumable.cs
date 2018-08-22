using Domain.Models.Enum;
using System;
using System.Linq;

namespace Domain.Models
{
    public class Consumable
    {
        private const Int16 hoursPerDay = 24, errorNumber = -1;

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
                Quantity = Convert.ToInt32(consumableAPISplited[0]);
                var consumable = consumableAPISplited[1].ToLower();

                EPeriod? period = System.Enum.GetValues(typeof(EPeriod)).Cast<EPeriod>()
                        .FirstOrDefault(x => consumable.ToLower().Contains(x.ToString().ToLower()));

                Period = (period != null) ? (EPeriod)period : EPeriod.Unknown;
            }
        }
    }
}