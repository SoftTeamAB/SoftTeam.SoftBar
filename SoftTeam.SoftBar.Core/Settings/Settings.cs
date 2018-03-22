using System.Collections.Generic;
using System.Xml.Serialization;

namespace SoftTeam.SoftBar.Core.Settings
{
    /// <summary>
    /// Main settings class
    /// </summary>
    public class Settings
    {
        #region Fields
        [XmlElement(ElementName = "MyTools")]
        public List<Tool> MyTools = new List<Tool>();

        [XmlElement(ElementName = "MyDirectory")]
        public List<Directory> MyDirectories = new List<Directory>();

        public List<Setting> MySettings = new List<Setting>();
        #endregion

        #region Get/Set/Exists settings
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

        #region Get/Set/Exists string settings
        public string GetStringSetting(string key, string defaultValue ="")
        {
            foreach (var setting in MySettings)
                if (setting.Key == key)
                    return setting.Value;

            return defaultValue;
        }

        public void SetStringSetting(string key, string value)
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
        #endregion

        #region Get/Set boolean settings
        public bool GetBooleanSetting(string key, bool defaultValue = false)
        {
            foreach (var setting in MySettings)
                if (setting.Key == key)
                    return setting.Value == "true";

            return defaultValue;
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
        public int GetIntegerSetting(string key, int defaultValue = 0)
        {
            foreach (var setting in MySettings)
                if (setting.Key == key)
                    return int.Parse(setting.Value);

            return defaultValue;
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