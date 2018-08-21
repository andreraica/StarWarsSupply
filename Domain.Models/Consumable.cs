using Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain.Models
{
    public class Consumable
    {
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
            return (Period != EPeriod.Unknown) ? (Quantity * 24 * (int)Period) : -1;
        }

        private void ConsumableBuilder(string consumableAPI)
        {
            var consumable = EPeriod.Unknown.ToString();
            var consumableSplited = consumableAPI.Split(" ");

            if (consumableSplited.Length == 2)
            {
                Quantity = Convert.ToInt32(consumableSplited[0]);
                consumable = consumableSplited[1].ToLower();
            }

            if (consumable.Contains("hour"))
                Period = EPeriod.Hour;
            else if (consumable.Contains("day"))
                Period = EPeriod.Day;
            else if (consumable.Contains("week"))
                Period = EPeriod.Week;
            else if (consumable.Contains("month"))
                Period = EPeriod.Month;
            else if (consumable.Contains("year"))
                Period = EPeriod.Year;
            else
            {
                Period = EPeriod.Unknown;
                Quantity = -1;
            }
        }
    }
}
