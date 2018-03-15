using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoftTeam.SoftBar.Core.Settings
{
    public class SettingsManager
    {
        private Settings _settings = null;
        private string _path = "";

        public SettingsManager(string path)
        {
            _path = path;
            _settings = new Settings();

            if (!System.IO.File.Exists(_path))
                CreateDefaultSettings();
            else
                Load();
        }

        public Settings Settings { get => _settings; internal set => _settings = value; }
        public string Path { get => _path; set => _path = value; }

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
            _settings.SetSetting("General.DirectoriesMenuVisible", "true");

            _settings.SetSetting("DriveType.FixedDrive", "true");
            _settings.SetSetting("DriveType.RemovableDrive", "true");
            _settings.SetSetting("DriveType.CDRomDrive", "true");
            _settings.SetSetting("DriveType.NetworkDrive", "true");

            _settings.SetSetting("SpecialFolder.Desktop", "true");
            _settings.SetSetting("SpecialFolder.Documents", "true");
            _settings.SetSetting("SpecialFolder.Download", "true");
            _settings.SetSetting("SpecialFolder.Pictures", "false");
            _settings.SetSetting("SpecialFolder.Videos", "false");
            _settings.SetSetting("SpecialFolder.Music", "false");

            Save();
        }
    }
}
