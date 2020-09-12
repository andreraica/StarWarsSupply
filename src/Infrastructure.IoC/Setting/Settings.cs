using Domain.Interfaces.IoC;
using System.Collections.Specialized;

namespace Infrastructure.IoC.Setting
{
    public class Settings : ISettings
    {
        public NameValueCollection AppSettings { get; set; }

        public string GetAppSetting(string key)
        {
            return AppSettings[key];
        }
    }
}
