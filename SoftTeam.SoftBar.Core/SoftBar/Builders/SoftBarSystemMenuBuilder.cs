using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Settings;
using System.Drawing;
using System.IO;

namespace SoftTeam.SoftBar.Core.SoftBar.Builders
{
    /// <summary>
    /// Class that builds the system menus
    /// </summary>
    public class SoftBarSystemMenuBuilder
    {
        #region Fields
        private MainAppBarForm _form = null;
        private SoftBarArea _softBarArea = null;
        private SettingsManager _settingsManager = null;
        #endregion

        #region Constructor
        public SoftBarSystemMenuBuilder(SoftBarManager manager)
        {
            _form = manager.Form;
            _softBarArea = manager.SystemArea;
            _settingsManager = manager.SettingsManager;
        }
        #endregion

        #region Build
        public void Build()
        {
            BuildSystemMenu();

            if (_settingsManager.Settings.GetBooleanSetting(Constants.General_DirectoriesMenuVisible))
                BuildDirectoriesMenu();
            if (_settingsManager.Settings.GetBooleanSetting(Constants.General_ToolsMenuVisible))
                BuildToolsMenu();
        }

        private void BuildSystemMenu()
        {
            // Create the actual system menu
            var systemMenu = new SoftBarMenu(_form, "SystemMenu", 0, true);
            _softBarArea.Menus.Add(systemMenu);
            systemMenu.Setup();
            systemMenu.Button.Click += _softBarArea.Button_Click;
            systemMenu.Button.Tag = systemMenu;
            systemMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.SystemMenu);

            // Reload the app bar menu item
            SoftBarMenuItem reloadItem = new SoftBarMenuItem(_form, "Reload", true);
            reloadItem.Setup();
            reloadItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Reload);
            reloadItem.Item.ItemClick += _softBarArea.Reload_ItemClick;
            systemMenu.Item.AddItem(reloadItem.Item);

            // Settings for the app bar
            SoftBarMenuItem settingsItem = new SoftBarMenuItem(_form, "Settings", true);
            settingsItem.Setup();
            settingsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Settings);
            settingsItem.Item.ItemClick += _softBarArea.SettingsItem_ItemClick;
            systemMenu.Item.AddItem(settingsItem.Item);

            // Settings for the app bar
            SoftBarMenuItem customizeItem = new SoftBarMenuItem(_form, "Customize", true);
            customizeItem.Setup();
            customizeItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Preferences);
            customizeItem.Item.ItemClick += _softBarArea.CustomizeItem_ItemClick;
            systemMenu.Item.AddItem(customizeItem.Item);

            // Exit the app bar
            SoftBarMenuItem exitItem = new SoftBarMenuItem(_form, "Exit", true);
            exitItem.Setup();
            exitItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Exit);
            exitItem.Item.ItemClick += _softBarArea.ExitItem_ItemClick;
            systemMenu.Item.AddItem(exitItem.Item);
            exitItem.Item.Links[0].BeginGroup = true;
        }

        private void BuildDirectoriesMenu()
        {
            // Create the actual directories menu
            var directoriesMenu = new SoftBarMenu(_form, "Directories", _softBarArea.Width, true);
            _softBarArea.Menus.Add(directoriesMenu);
            directoriesMenu.Setup();
            directoriesMenu.Button.Click += _softBarArea.Button_Click;
            directoriesMenu.Button.Tag = directoriesMenu;
            directoriesMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Directories);

            // My directories
            foreach (var directory in _settingsManager.Settings.MyDirectories)
            {
                SoftBarMenuItem myDirectoryItem = new SoftBarMenuItem(_form, directory.Name, true);
                myDirectoryItem.Setup();
                myDirectoryItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Directories);
                myDirectoryItem.Item.Tag = directory;
                myDirectoryItem.Item.ItemClick += _softBarArea.MyDirectory_ItemClick;
                directoriesMenu.Item.AddItem(myDirectoryItem.Item);
                if (directory.BeginGroup)
                    myDirectoryItem.Item.Links[0].BeginGroup = true;
            }

            // Add all drives
            DriveType? driveType = null;
            DriveInfo[] drives = DriveInfo.GetDrives();
            bool beginGroup = false;
            foreach (DriveInfo drive in drives)
            {
                // Create a menu item for the drive
                SoftBarMenuItem driveItem = new SoftBarMenuItem(_form, drive.Name, true);

                // Begin a new group every time the type changes
                beginGroup = (driveType != drive.DriveType);

                // Set the image depending of the drive type
                driveItem.Setup();
                switch (drive.DriveType)
                {
                    case DriveType.Removable:
                        driveItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.floppy_drive);
                        break;
                    case DriveType.Fixed:
                        driveItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.hard_drive);
                        break;
                    case DriveType.Network:
                        driveItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.hard_drive_network);
                        break;
                    case DriveType.CDRom:
                        driveItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.cd);
                        break;
                }
                //driveItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Exit);
                driveItem.Item.Tag = drive;
                driveItem.Item.ItemClick += _softBarArea.DriveItem_ItemClick;
                directoriesMenu.Item.AddItem(driveItem.Item);
                if (beginGroup)
                    driveItem.Item.Links[0].BeginGroup = true;

                driveType = drive.DriveType;
            }

            // Add special directory for the desktop folder
            if (_settingsManager.Settings.GetSetting(Constants.SpecialFolder_Desktop).Value == "true")
            {
                SoftBarMenuItem desktopItem = new SoftBarMenuItem(_form, "Desktop", true);
                desktopItem.Setup();
                desktopItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Directories);
                desktopItem.Item.ItemClick += _softBarArea.DesktopItem_ItemClick; ;
                directoriesMenu.Item.AddItem(desktopItem.Item);
                desktopItem.Item.Links[0].BeginGroup = true;
            }

            // Add special directory for the documents folder
            if (_settingsManager.Settings.GetSetting(Constants.SpecialFolder_Documents).Value == "true")
            {
                SoftBarMenuItem documentsItem = new SoftBarMenuItem(_form, "Documents", true);
                documentsItem.Setup();
                documentsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Document);
                documentsItem.Item.ItemClick += _softBarArea.DocumentsItem_ItemClick; ;
                directoriesMenu.Item.AddItem(documentsItem.Item);
            }

            // Add special directory for the downloads folder
            if (_settingsManager.Settings.GetSetting(Constants.SpecialFolder_Downloads).Value == "true")
            {
                SoftBarMenuItem downloadsItem = new SoftBarMenuItem(_form, "Downloads", true);
                downloadsItem.Setup();
                downloadsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Download);
                downloadsItem.Item.ItemClick += _softBarArea.DownloadsItem_ItemClick; ;
                directoriesMenu.Item.AddItem(downloadsItem.Item);
            }

            // Add special directory for the pictures folder
            if (_settingsManager.Settings.GetSetting(Constants.SpecialFolder_Pictures).Value == "true")
            {
                SoftBarMenuItem downloadsItem = new SoftBarMenuItem(_form, "Pictures", true);
                downloadsItem.Setup();
                downloadsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Directories);
                downloadsItem.Item.ItemClick += _softBarArea.PicturesItem_ItemClick; ;
                directoriesMenu.Item.AddItem(downloadsItem.Item);
            }

            // Add special directory for the videos folder
            if (_settingsManager.Settings.GetSetting(Constants.SpecialFolder_Videos).Value == "true")
            {
                SoftBarMenuItem downloadsItem = new SoftBarMenuItem(_form, "Videos", true);
                downloadsItem.Setup();
                downloadsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Movies);
                downloadsItem.Item.ItemClick += _softBarArea.VideosItem_ItemClick; ;
                directoriesMenu.Item.AddItem(downloadsItem.Item);
            }

            // Add special directory for the music folder
            if (_settingsManager.Settings.GetSetting(Constants.SpecialFolder_Music).Value == "true")
            {
                SoftBarMenuItem downloadsItem = new SoftBarMenuItem(_form, "Music", true);
                downloadsItem.Setup();
                downloadsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Music);
                downloadsItem.Item.ItemClick += _softBarArea.MusicItem_ItemClick; ;
                directoriesMenu.Item.AddItem(downloadsItem.Item);
            }
        }

        private void BuildToolsMenu()
        {
            // Create the actual system menu
            var toolsMenu = new SoftBarMenu(_form, "ToolsMenu", _softBarArea.Width, true);
            _softBarArea.Menus.Add(toolsMenu);
            toolsMenu.Setup();
            toolsMenu.Button.Click += _softBarArea.Button_Click;
            toolsMenu.Button.Tag = toolsMenu;
            toolsMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.ToolsMenu);

            // Add all tools
            foreach (var tool in _settingsManager.Settings.MyTools)
            {
                // Create a menu item for the tool
                SoftBarMenuItem toolItem = new SoftBarMenuItem(_form, tool, true);

                // Begin a new group every time the type changes
                //beginGroup = (driveType != drive.DriveType);

                // Set the image depending of the drive type
                toolItem.Setup();
                toolItem.Item.ImageOptions.Image = HelperFunctions.ExtractIcon(tool.IconPath);
                toolItem.Item.Tag = tool;
                toolItem.Item.ItemClick += _softBarArea.toolItem_ItemClick;
                toolsMenu.Item.AddItem(toolItem.Item);
                //if (beginGroup)
                //    driveItem.Item.Links[0].BeginGroup = true;
            }
        }
        #endregion
    }
}
