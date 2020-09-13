namespace StarWarsSupply.Domain.Interfaces.IoC
{
    public interface ISettings
    {
        string GetAppSetting(string key);
    }
}
