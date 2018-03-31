using SoftTeam.SoftBar.Core.Misc;
using System;
using System.IO;

namespace SoftTeam.SoftBar.Core.SoftBar
{
    public class SoftBarFileManager
    {
        private const string EmptyMenuXml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n<softbar>\n</softbar>";
        private string _path = "";

        public SoftBarFileManager(string path)
        {
            _path = path;
            if (!System.IO.Directory.Exists(_path))
                throw new DirectoryNotFoundException("'" + _path + "' does not exist!");

            Directory.CreateDirectory(SoftBarDirectoryBackup);
            Directory.CreateDirectory(SoftBarExceptionLogs);

            if (!File.Exists(MenuPath))
                CreateEmptyMenuXml();
        }

        public string SoftBarDirectory { get => _path; }
        public string SoftBarDirectoryBackup { get => Path.Combine(_path, "Backup"); }
        public string SoftBarExceptionLogs { get => Path.Combine(_path, "Exception log"); }

        public string SettingsPath { get => Path.Combine(_path, "Settings.xml"); }

        public string MenuPath { get => Path.Combine(_path, "menu.xml"); }

        public bool Backup(FileType fileType)
        {
            try
            {
                string backupFileName = "";
                string timeStamp = HelperFunctions.GetTimeStamp();

                switch (fileType)
                {
                    case FileType.Settings:
                        backupFileName = $"Settings_{timeStamp}.xml";
                        File.Copy(SettingsPath, Path.Combine(SoftBarDirectoryBackup, backupFileName));
                        break;
                    case FileType.UserMenus:
                        backupFileName = $"Menu_{timeStamp}.xml";
                        File.Copy(MenuPath, Path.Combine(SoftBarDirectoryBackup, backupFileName));
                        break;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void CreateEmptyMenuXml()
        {
            File.WriteAllText(MenuPath, EmptyMenuXml);
        }
    }
}
