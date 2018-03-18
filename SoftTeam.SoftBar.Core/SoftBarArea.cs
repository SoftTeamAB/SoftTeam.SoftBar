using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Xml;
using SoftTeam.SoftBar.Core.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core
{
    /// <summary>
    /// A SoftBar area, can be System, User or Info.
    /// - Each area can containt multiple buttons and menus
    /// </summary>
    public class SoftBarArea
    {
        private AreaType _type = AreaType.System;
        private List<SoftBarMenu> _menus = null;
        private int _left = 0;
        private MainAppBarForm _form = null;
        private SettingsManager _manager = null;
        private string _path = "";

        public List<SoftBarMenu> Menus { get => _menus; set => _menus = value; }
        public MainAppBarForm Form { get => _form; set => _form = value; }
        public int Width { get => _left + _menus.Sum(m => m.Width + Constants.SEPARATOR_WIDTH); }
        public int Left { get => _left; set => _left = value; }
        public AreaType Type { get => _type; set => _type = value; }

        public SoftBarArea(MainAppBarForm form, AreaType type, string path, int left=0)
        {
            _form = form;
            _type = type;
            _path = path;
            _left = left;
            _menus = new List<SoftBarMenu>();
            _manager = new SettingsManager(HelperFunctions.GetSettingsPath());

            Reload();
        }

        #region Build user menus
        public void BuildUserMenus(XmlArea area)
        {
            foreach (var menu in area.Menus)
            {
                // Create the menu item
                SoftBarMenu barMenu = new SoftBarMenu(_form, menu);

                // Position the menu
                barMenu.Left = Width;
                barMenu.Width = menu.Name.Length * 10;

                // Set up the menu
                barMenu.Setup();

                // Add the menu to the menus collection
                _menus.Add(barMenu);
            }
        }
        #endregion

        #region Build system menus
        public void BuildSystemMenus()
        {
            BuildSystemMenu();
            BuildDirectoriesMenu();
            BuildToolsMenu();
        }

        private void BuildSystemMenu()
        {
            // Create the actual system menu
            var systemMenu = new SoftBarMenu(_form, "SystemMenu", 0, true);
            _menus.Add(systemMenu);
            systemMenu.Setup();
            systemMenu.Button.Click += Button_Click;
            systemMenu.Button.Tag = systemMenu;
            systemMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.SystemMenu);

            // Reload the app bar menu item
            SoftBarMenuItem reloadItem = new SoftBarMenuItem(_form, "Reload", true);
            reloadItem.Setup();
            reloadItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Reload);
            reloadItem.Item.ItemClick += Reload_ItemClick;
            systemMenu.Item.AddItem(reloadItem.Item);

            // Settings for the app bar
            SoftBarMenuItem settingsItem = new SoftBarMenuItem(_form, "Settings", true);
            settingsItem.Setup();
            settingsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Settings);
            settingsItem.Item.ItemClick += SettingsItem_ItemClick;
            systemMenu.Item.AddItem(settingsItem.Item);

            //// Customize the app bar menu
            //SoftBarSubMenu customizeSubMenuItem = new SoftBarSubMenu(_form, "Customize");
            //customizeSubMenuItem.Setup(_systemMenu.PopupMenu);
            //customizeSubMenuItem.SubMenu.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Preferences);

            // Exit the app bar
            SoftBarMenuItem exitItem = new SoftBarMenuItem(_form, "Exit", true);
            exitItem.Setup();
            exitItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Exit);
            exitItem.Item.ItemClick += ExitItem_ItemClick;
            systemMenu.Item.AddItem(exitItem.Item);
            exitItem.Item.Links[0].BeginGroup = true;
        }

        private void BuildDirectoriesMenu()
        {
            // Create the actual directories menu
            var directoriesMenu = new SoftBarMenu(_form, "Directories", Width, true);
            _menus.Add(directoriesMenu);
            directoriesMenu.Setup();
            directoriesMenu.Button.Click += Button_Click;
            directoriesMenu.Button.Tag = directoriesMenu;
            directoriesMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Directories);

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
                driveItem.Item.ItemClick += DriveItem_ItemClick;
                directoriesMenu.Item.AddItem(driveItem.Item);
                if (beginGroup)
                    driveItem.Item.Links[0].BeginGroup = true;

                driveType = drive.DriveType;
            }

            // Add special directory for the desktop folder
            SoftBarMenuItem desktopItem = new SoftBarMenuItem(_form, "Desktop", true);
            desktopItem.Setup();
            desktopItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Directories);
            desktopItem.Item.ItemClick += DesktopItem_ItemClick; ;
            directoriesMenu.Item.AddItem(desktopItem.Item);
            desktopItem.Item.Links[0].BeginGroup = true;

            // Add special directory for the documents folder
            SoftBarMenuItem documentsItem = new SoftBarMenuItem(_form, "Documents", true);
            documentsItem.Setup();
            documentsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Document);
            documentsItem.Item.ItemClick += DocumentsItem_ItemClick; ;
            directoriesMenu.Item.AddItem(documentsItem.Item);

            // Add special directory for the downloads folder
            SoftBarMenuItem downloadsItem = new SoftBarMenuItem(_form, "Downloads", true);
            downloadsItem.Setup();
            downloadsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Download);
            downloadsItem.Item.ItemClick += DocumentsItem_ItemClick; ;
            directoriesMenu.Item.AddItem(downloadsItem.Item);

        }

        private void BuildToolsMenu()
        {
            // Create the actual system menu
            var toolsMenu = new SoftBarMenu(_form, "ToolsMenu", Width, true);
            _menus.Add(toolsMenu);
            toolsMenu.Setup();
            toolsMenu.Button.Click += Button_Click;
            toolsMenu.Button.Tag = toolsMenu;
            toolsMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.ToolsMenu);

            // Add all tools
            foreach (var tool in _manager.Settings.MyTools)
            {
                // Create a menu item for the tool
                SoftBarMenuItem toolItem = new SoftBarMenuItem(_form, tool, true);

                // Begin a new group every time the type changes
                //beginGroup = (driveType != drive.DriveType);

                // Set the image depending of the drive type
                toolItem.Setup();
                toolItem.Item.ImageOptions.Image = HelperFunctions.ExtractIcon(tool);
                toolItem.Item.Tag = tool;
                toolItem.Item.ItemClick += toolItem_ItemClick;
                toolsMenu.Item.AddItem(toolItem.Item);
                //if (beginGroup)
                //    driveItem.Item.Links[0].BeginGroup = true;
            }
        }
        #endregion

        #region Misc functions

        private void Reload(bool hardReload = false)
        {
            if (hardReload)
            {
                AppBarFunctions.SetAppBar(_form, AppBarEdge.None);
                Application.DoEvents();
                AppBarFunctions.SetAppBar(_form, AppBarEdge.Top);
            }

            // Load settings
            _manager = new SettingsManager(HelperFunctions.GetSettingsPath());


            switch (_type)
            {
                case AreaType.System:
                    BuildSystemMenus();
                    break;
                case AreaType.User:
                    // Create xml loader and load xml
                    XmlLoader loader = new XmlLoader(_path);
                    XmlArea area = loader.Load();

                    BuildUserMenus(area);
                    break;
            }
        }
        #endregion

        #region Events
        private void Reload_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reload(true);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var menu = (SoftBarMenu)((SimpleButton)sender).Tag;
            menu.Item.ShowPopup(new Point(menu.Left, 0));
        }

        private void ExitItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _form.Close();
        }

        private void SettingsItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (SettingsForm form = new SettingsForm())
            {
                _menus[Constants.SYSTEM_MENU].Item.HidePopup();
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel)
                    return;

                Reload();
            }
        }

        private void DesktopItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandLineHelper.ExecuteCommandLine(@"Explorer.exe %USERPROFILE%\Desktop");
        }

        private void DocumentsItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandLineHelper.ExecuteCommandLine(@"Explorer.exe %USERPROFILE%\Documents");
        }

        private void DriveItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var drive = ((DriveInfo)e.Item.Tag);
            Process.Start(drive.Name);
        }

        private void toolItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var path = ((string)e.Item.Tag);
            Process.Start(path);
        }

        #endregion

    }
}
