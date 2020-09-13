namespace StarWarsSupply.Infrastructure.IoC.Setting
{
    using System.Collections.Specialized;
    using StarWarsSupply.Domain.Interfaces.IoC;
    
    public class Settings : ISettings
    {
        public NameValueCollection AppSettings { get; set; }

        public string GetAppSetting(string key)
        {
            return AppSettings[key];
        }
    }
}
