using SoftTeam.SoftBar.Core.Misc;
using System.IO;
using System.Xml.Serialization;

namespace SoftTeam.SoftBar.Core.Settings
{
    /// <summary>
    /// Class that handles load and save of settings
    /// </summary>
    public class SettingsManager
    {
        #region Fields
        private Settings _settings = null;
        private string _path = "";
        #endregion

        #region Constructor
        public SettingsManager(string path)
        {
            _path = path;
            _settings = new Settings();

            if (!System.IO.File.Exists(_path))
                CreateDefaultSettings();
            else
                Load();
        }
        #endregion

        #region Properties
        public Settings Settings { get => _settings; internal set => _settings = value; }        
        public string Path { get => _path; set => _path = value; }
        #endregion

        #region Load/Save/Default settings
        public void Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            TextReader reader = new StreamReader(_path);
            _settings = (Settings)serializer.Deserialize(reader);
            reader.Close();
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            TextWriter writer = new StreamWriter(_path);
            serializer.Serialize(writer, _settings);
            writer.Close();
        }
        private void CreateDefaultSettings()
        {
            _settings.SetBooleanSetting(Constants.General_DirectoriesMenuVisible, true);
            _settings.SetBooleanSetting(Constants.General_ToolsMenuVisible, true);

            _settings.SetSetting(Constants.General_SystemMenuName, "SoftBar");
            _settings.SetSetting(Constants.General_DirectoriesMenuName, "Directories");
            _settings.SetSetting(Constants.General_ToolsMenuName, "Tools");

            _settings.SetIntegerSetting(Constants.General_SystemMenuWidth, 100);
            _settings.SetIntegerSetting(Constants.General_DirectoriesMenuWidth, 100);
            _settings.SetIntegerSetting(Constants.General_ToolsMenuWidth, 100);

            _settings.SetBooleanSetting(Constants.DriveType_FixedDrive, true);
            _settings.SetBooleanSetting(Constants.DriveType_RemovableDrive, true);
            _settings.SetBooleanSetting(Constants.DriveType_CDRomDrive, true);
            _settings.SetBooleanSetting(Constants.DriveType_NetworkDrive, true);

            _settings.SetBooleanSetting(Constants.SpecialFolder_Desktop, true);
            _settings.SetBooleanSetting(Constants.SpecialFolder_Documents, true);
            _settings.SetBooleanSetting(Constants.SpecialFolder_Downloads, true);
            _settings.SetBooleanSetting(Constants.SpecialFolder_Pictures, false);
            _settings.SetBooleanSetting(Constants.SpecialFolder_Videos, false);
            _settings.SetBooleanSetting(Constants.SpecialFolder_Music, false);

            Save();
        }
        #endregion
    }
}
