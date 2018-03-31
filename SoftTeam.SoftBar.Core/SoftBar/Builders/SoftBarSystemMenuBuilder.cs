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
            var width = _settingsManager.Settings.GetIntegerSetting(Constants.General_SystemMenuWidth, 100);
            var name = _settingsManager.Settings.GetStringSetting(Constants.General_SystemMenuName, "SoftBar");

            var systemMenu = new SoftBarMenu(_form, name, 0, width, true);
            systemMenu.Width = width;
            _softBarArea.Menus.Add(systemMenu);
            systemMenu.Setup();
            systemMenu.Button.Click += _softBarArea.Button_Click;
            systemMenu.Button.Tag = systemMenu;
            systemMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.SystemMenu);

            // Reload the app bar menu item
            //SoftBarMenuItem reloadItem = new SoftBarMenuItem(_form, "Reload", true);
            //reloadItem.Setup();
            //reloadItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Reload);
            //reloadItem.Item.ItemClick += _softBarArea.Reload_ItemClick;
            //systemMenu.Item.AddItem(reloadItem.Item);

            // Settings for the app bar
            SoftBarMenuItem settingsItem = new SoftBarMenuItem(_form, "Settings", true);
            settingsItem.Setup();
            settingsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.settings);
            settingsItem.Item.ItemClick += _softBarArea.SettingsItem_ItemClick;
            systemMenu.Item.AddItem(settingsItem.Item);

            // Settings for the app bar
            SoftBarMenuItem customizeItem = new SoftBarMenuItem(_form, "Customize", true);
            customizeItem.Setup();
            customizeItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.preferences);
            customizeItem.Item.ItemClick += _softBarArea.CustomizeItem_ItemClick;
            systemMenu.Item.AddItem(customizeItem.Item);

            // About the app bar
            SoftBarMenuItem aboutItem = new SoftBarMenuItem(_form, "About", true);
            aboutItem.Setup();
            aboutItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.information);
            aboutItem.Item.ItemClick += _softBarArea.aboutItem_ItemClick;
            systemMenu.Item.AddItem(aboutItem.Item);
            aboutItem.Item.Links[0].BeginGroup = true;

            // Exit the app bar
            SoftBarMenuItem exitItem = new SoftBarMenuItem(_form, "Exit", true);
            exitItem.Setup();
            exitItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.exit);
            exitItem.Item.ItemClick += _softBarArea.ExitItem_ItemClick;
            systemMenu.Item.AddItem(exitItem.Item);
            exitItem.Item.Links[0].BeginGroup = true;
        }

        private void BuildDirectoriesMenu()
        {
            // Create the actual directories menu
            var width = _settingsManager.Settings.GetIntegerSetting(Constants.General_DirectoriesMenuWidth, 100);
            var name = _settingsManager.Settings.GetStringSetting(Constants.General_DirectoriesMenuName, "Directories");

            var directoriesMenu = new SoftBarMenu(_form, name, _softBarArea.Width, width, true);
            _softBarArea.Menus.Add(directoriesMenu);
            directoriesMenu.Setup();
            directoriesMenu.Button.Click += _softBarArea.Button_Click;
            directoriesMenu.Button.Tag = directoriesMenu;
            directoriesMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.folder_medium);

            // My directories
            SoftBarSubMenu myDirectoriesSubMenu=null;
            if (_settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMyFolders))
            {
                myDirectoriesSubMenu = new SoftBarSubMenu(_form, "My folders", new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.folder));
                myDirectoriesSubMenu.Setup(directoriesMenu);
                directoriesMenu.Item.AddItem(myDirectoriesSubMenu.Item);
            }

            foreach (var directory in _settingsManager.Settings.MyDirectories)
            {
                SoftBarMenuItem myDirectoryItem = new SoftBarMenuItem(_form, directory.Name, true);
                myDirectoryItem.Setup();
                myDirectoryItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.folder);
                myDirectoryItem.Item.Tag = directory;
                myDirectoryItem.Item.ItemClick += _softBarArea.MyDirectory_ItemClick;
                if (_settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMyFolders))
                    myDirectoriesSubMenu.Item.AddItem(myDirectoryItem.Item);
                else
                    directoriesMenu.Item.AddItem(myDirectoryItem.Item);
                if (directory.BeginGroup)
                    myDirectoryItem.Item.Links[0].BeginGroup = true;
            }

            // My drives
            SoftBarSubMenu myDrivesSubMenu = null;
            if (_settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMyDrives))
            {
                myDrivesSubMenu = new SoftBarSubMenu(_form, "My drives", new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.folder));
                myDrivesSubMenu.Setup(directoriesMenu);
                directoriesMenu.Item.AddItem(myDrivesSubMenu.Item);
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

                if (_settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMyDrives))
                    myDrivesSubMenu.Item.AddItem(driveItem.Item);
                else
                    directoriesMenu.Item.AddItem(driveItem.Item);

                if (beginGroup)
                    driveItem.Item.Links[0].BeginGroup = true;

                driveType = drive.DriveType;
            }

            // My special folders
            SoftBarSubMenu mySpecialFoldersSubMenu = null;
            if (_settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMySpecialFolders))
            {
                mySpecialFoldersSubMenu = new SoftBarSubMenu(_form, "My special folders", new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.folder));
                mySpecialFoldersSubMenu.Setup(directoriesMenu);
                directoriesMenu.Item.AddItem(mySpecialFoldersSubMenu.Item);
            }

            // Add special directory for the desktop folder
            if (_settingsManager.Settings.GetSetting(Constants.SpecialFolder_Desktop).Value == "true")
            {
                SoftBarMenuItem desktopItem = new SoftBarMenuItem(_form, "Desktop", true);
                desktopItem.Setup();
                desktopItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.folder);
                desktopItem.Item.ItemClick += _softBarArea.DesktopItem_ItemClick; ;
                if (_settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMySpecialFolders))
                    mySpecialFoldersSubMenu.Item.AddItem(desktopItem.Item);
                else
                    directoriesMenu.Item.AddItem(desktopItem.Item);
                desktopItem.Item.Links[0].BeginGroup = true;
            }

            // Add special directory for the documents folder
            if (_settingsManager.Settings.GetSetting(Constants.SpecialFolder_Documents).Value == "true")
            {
                SoftBarMenuItem documentsItem = new SoftBarMenuItem(_form, "Documents", true);
                documentsItem.Setup();
                documentsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.document);
                documentsItem.Item.ItemClick += _softBarArea.DocumentsItem_ItemClick; ;
                if (_settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMySpecialFolders))
                    mySpecialFoldersSubMenu.Item.AddItem(documentsItem.Item);
                else
                    directoriesMenu.Item.AddItem(documentsItem.Item);
            }

            // Add special directory for the downloads folder
            if (_settingsManager.Settings.GetSetting(Constants.SpecialFolder_Downloads).Value == "true")
            {
                SoftBarMenuItem downloadsItem = new SoftBarMenuItem(_form, "Downloads", true);
                downloadsItem.Setup();
                downloadsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.download);
                downloadsItem.Item.ItemClick += _softBarArea.DownloadsItem_ItemClick; ;
                if (_settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMySpecialFolders))
                    mySpecialFoldersSubMenu.Item.AddItem(downloadsItem.Item);
                else
                    directoriesMenu.Item.AddItem(downloadsItem.Item);
            }

            // Add special directory for the pictures folder
            if (_settingsManager.Settings.GetSetting(Constants.SpecialFolder_Pictures).Value == "true")
            {
                SoftBarMenuItem picturesItem = new SoftBarMenuItem(_form, "Pictures", true);
                picturesItem.Setup();
                picturesItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.folder);
                picturesItem.Item.ItemClick += _softBarArea.PicturesItem_ItemClick; ;
                if (_settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMySpecialFolders))
                    mySpecialFoldersSubMenu.Item.AddItem(picturesItem.Item);
                else
                    directoriesMenu.Item.AddItem(picturesItem.Item);                
            }

            // Add special directory for the videos folder
            if (_settingsManager.Settings.GetSetting(Constants.SpecialFolder_Videos).Value == "true")
            {
                SoftBarMenuItem videosItem = new SoftBarMenuItem(_form, "Videos", true);
                videosItem.Setup();
                videosItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.movies);
                videosItem.Item.ItemClick += _softBarArea.VideosItem_ItemClick; ;
                if (_settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMySpecialFolders))
                    mySpecialFoldersSubMenu.Item.AddItem(videosItem.Item);
                else
                    directoriesMenu.Item.AddItem(videosItem.Item);
            }

            // Add special directory for the music folder
            if (_settingsManager.Settings.GetSetting(Constants.SpecialFolder_Music).Value == "true")
            {
                SoftBarMenuItem musicItem = new SoftBarMenuItem(_form, "Music", true);
                musicItem.Setup();
                musicItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.music);
                musicItem.Item.ItemClick += _softBarArea.MusicItem_ItemClick; ;
                if (_settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMySpecialFolders))
                    mySpecialFoldersSubMenu.Item.AddItem(musicItem.Item);
                else
                    directoriesMenu.Item.AddItem(musicItem.Item);
            }
        }

        private void BuildToolsMenu()
        {
            // Create the actual system menu
            var width = _settingsManager.Settings.GetIntegerSetting(Constants.General_ToolsMenuWidth, 100);
            var name = _settingsManager.Settings.GetStringSetting(Constants.General_ToolsMenuName, "Tools");

            var toolsMenu = new SoftBarMenu(_form, name, _softBarArea.Width, width, true);
            _softBarArea.Menus.Add(toolsMenu);
            toolsMenu.Setup();
            toolsMenu.Button.Click += _softBarArea.Button_Click;
            toolsMenu.Button.Tag = toolsMenu;
            toolsMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.tools);

            // Add all tools
            foreach (var tool in _settingsManager.Settings.MyTools)
            {
                // Create a menu item for the tool
                SoftBarMenuItem toolItem = new SoftBarMenuItem(_form, tool, true);

                // Begin a new group every time the type changes
                //beginGroup = (driveType != drive.DriveType);

                // Set the image depending of the drive type
                toolItem.Setup();
                toolItem.Item.ImageOptions.Image = HelperFunctions.GetFileImage(tool.IconPath);
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
