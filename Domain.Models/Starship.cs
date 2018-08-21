using System;

namespace Domain.Models
{
    public class Starship
    {
        public Starship(string name, int mGLT, Consumable consumable)
        {
            Name = name;
            MGLT = mGLT;
            Consumable = consumable;
        }

        public string Name { get; private set; }
        public Int32 MGLT { get; private set; }
        public Consumable Consumable { get; private set; }

        public long CalculateSupply(long distanceMGLT)
        {
            int consumableHours = Consumable.GetHours();

            if (consumableHours * MGLT == 0)
                return -1;

            return consumableHours >= 0 ? Math.Abs(distanceMGLT / (consumableHours * MGLT)) : -1;
        }
    }
}
