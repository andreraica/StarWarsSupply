namespace StarWarsSupply.Domain.Models
{
    using System;

    public class Starship
    {
        private const int errorNumber = -1;

        public Starship(string name, int mGLT, Consumable consumable)
        {
            Name = name;
            MGLT = mGLT;
            Consumable = consumable;
        }

        public string Name { get; private set; }
        public int MGLT { get; private set; }
        public Consumable Consumable { get; private set; }

        public long CalculateSupply(long distanceMGLT)
        {
            int consumableHours = Consumable.GetHours();

            if (consumableHours * MGLT == 0)
                return errorNumber;

            return consumableHours >= 0 ? Math.Abs(distanceMGLT / (consumableHours * MGLT)) : errorNumber;
        }
    }
}
