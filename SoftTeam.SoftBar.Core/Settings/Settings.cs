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

        [XmlElement(ElementName = "MyTools")]
        public List<Tool> MyTools = new List<Tool>();

        [XmlElement(ElementName = "MyDirectory")]
        public List<Directory> MyDirectories = new List<Directory>();

        public List<Setting> MySettings = new List<Setting>();

        #region Get/Set/Exists string settings
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
        #endregion

        #region Get/Set boolean settings
        public bool GetBooleanSetting(string key)
        {
            foreach (var setting in MySettings)
                if (setting.Key == key)
                    return setting.Value == "true";

            return false;
        }

        public void SetBooleanSetting(string key, bool value)
        {
            var setting = GetSetting(key);

            if (setting == null)
            {
                setting = new Setting(key, value.ToString().ToLower());
                MySettings.Add(setting);
            }
            else
                setting.Value = value.ToString().ToLower();
        }
        #endregion    }

        #region Get/Set integer settings
        public int GetIntegerSetting(string key)
        {
            foreach (var setting in MySettings)
                if (setting.Key == key)
                    return int.Parse(setting.Value);

            return 0;
        }

        public void SetIntegerSetting(string key, int value)
        {
            var setting = GetSetting(key);

            if (setting == null)
            {
                setting = new Setting(key, value.ToString());
                MySettings.Add(setting);
            }
            else
                setting.Value = value.ToString();
        }
        #endregion    }
    }
}