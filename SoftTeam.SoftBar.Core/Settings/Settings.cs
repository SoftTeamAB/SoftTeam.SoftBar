using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoftTeam.SoftBar.Core.Settings
{
    public class Settings
    {
        public List<Setting> MySettings = new List<Setting>();

        [XmlElement(ElementName = "MyDirectory")]
        public List<string> MyDirectories = new List<string>();

        public Setting GetSetting(string key)
        {
            foreach (var setting in MySettings)
                if (setting.Key == key)
                    return setting;

            return null;
        }

        public void SetSetting(string key, string value)
        {
            var setting = GetSetting(key);

            if (setting == null)
            {
                setting = new Setting(key, value);
                MySettings.Add(setting);
            }
            else
                setting.Value = value;
        }

        public bool ExistsSetting(string key)
        {
            return GetSetting(key) != null;
        }
    }
}
