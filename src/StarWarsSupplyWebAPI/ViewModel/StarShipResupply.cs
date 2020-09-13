namespace StarWarsSupply.Presentation.StarWarsSupply.WebAPI.ViewModel
{
    public class StarShipResupply
    {
        public StarShipResupply(string name, long stopsCount)
        {
            Name = name;
            StopsCount = stopsCount;
        }

        public string Name { get; private set; }
        public long StopsCount { get; private set; }
    }
}
