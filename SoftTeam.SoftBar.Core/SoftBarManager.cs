﻿using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SoftTeam.SoftBar.Core
{
    public class SoftBarManager
    {
        #region Constants
        private const int SEPARATOR_WIDTH = 0;
        #endregion

        #region Fields
        private SoftBarMenu _systemMenu = null;
        private SoftBarMenu _directoriesMenu = null;
        private List<SoftBarMenu> _menus = new List<SoftBarMenu>();

        private MainAppBarForm _form = null;
        private string _path = "";

        public List<SoftBarMenu> Menus { get => _menus; set => _menus = value; }
        #endregion

        #region Constructor
        public SoftBarManager(MainAppBarForm form, string path)
        {
            _form = form;
            _path = path;

            // Create a system menu
            CreateSystemMenu();
            // Create the directories menu
            CreateDirectoriesMenu();
            // Load user menus from XML
            LoadXml();
            // Create user menues
            CreateMenus();
        }
        #endregion

        #region Load menu
        public void LoadXml()
        {
            // Create a new xml document and load the document
            XmlDocument doc = new XmlDocument();
            doc.Load(_path);

            // Select all menus in the document
            XmlNode menus = doc.SelectSingleNode("//menus");

            foreach (XmlNode menu in menus)
            {
                // Create the first level menu and add it
                SoftBarMenu xmlMenu = new SoftBarMenu(_form, menu.Attributes["name"].Value, GetCurrentWidth());
                var iconNode = menu.Attributes["iconPath"];
                if (iconNode != null)
                    xmlMenu.IconPath = iconNode.Value;
                _menus.Add(xmlMenu);

                // Load the rest of the menu
                LoadXmlMenu(menu, xmlMenu);
            }
        }

        private void LoadXmlMenu(XmlNode menu, SoftBarMenu xmlMenu)
        {            
            foreach (XmlNode menuItem in menu)
            {
                var name = menuItem.Attributes["name"].Value;

                // Is it a sub menu, header item or a ordinary menu item
                if (menuItem.Name == "menu")
                {
                    throw new NotImplementedException();
                    //// Create the new sub menu
                    //SoftBarMenuItem xmlSubMenu = new SoftBarMenuItem(_form, SoftBarMenuItem.MenuItemType.SubLevelMenu, name, true);
                    //xmlMenu.MenuItems.Add(xmlSubMenu);

                    //LoadXmlSubMenu(menuItem, xmlSubMenu);
                }
                if (menuItem.Name == "headerItem")
                {
                    // Create the new headerItem
                    SoftBarHeaderItem headerItem = new SoftBarHeaderItem(_form, name);
                    xmlMenu.MenuItems.Add(headerItem);
                }
                else
                {
                    SoftBarMenuItem xmlMenuItem = new SoftBarMenuItem(_form, name);

                    // Application and document path
                    var applicationNode = menuItem.SelectSingleNode("applicationPath");
                    xmlMenuItem.ApplicationPath = applicationNode == null ? "" : applicationNode.InnerText;
                    var documentNode = menuItem.SelectSingleNode("documentPath");
                    xmlMenuItem.DocumentPath = documentNode == null ? "" : documentNode.InnerText;
                    
                    // Begin group
                    var group = false;
                    if (menuItem.SelectSingleNode("beginGroup") != null)
                        group = menuItem.SelectSingleNode("beginGroup").InnerText.ToUpper() == "TRUE";
                    xmlMenuItem.BeginGroup = group;

                    // Icon
                    var iconNode = menuItem.SelectSingleNode("iconPath");
                    if (iconNode != null)
                        xmlMenuItem.IconPath = iconNode.InnerText;

                    xmlMenu.MenuItems.Add(xmlMenuItem);
                }
            }
        }

        private void LoadXmlSubMenu(XmlNode menu, SoftBarMenuItem xmlMenu)
        {
            //foreach (XmlNode menuItem in menu)
            //{
            //    var name = menuItem.Attributes["name"].Value;

            //    if (menuItem.Name == "menu")
            //    {
            //        // Create the new sub menu
            //        SoftBarMenuItem xmlSubMenu = new SoftBarMenuItem(_form, SoftBarMenuItem.MenuItemType.SubLevelMenu, name, true);
            //        xmlMenu.Menus.Add(xmlSubMenu);

            //        LoadXmlSubMenu(menuItem, xmlSubMenu);
            //    }
            //    else
            //    {
            //        SoftBarMenuItem xmlMenuItem = new SoftBarMenuItem(_form, SoftBarMenuItem.MenuItemType.MenuItem, name);

            //        xmlMenuItem.ApplicationPath = menuItem.SelectSingleNode("applicationPath").InnerText;
            //        xmlMenuItem.BeginGroup = menuItem.SelectSingleNode("beginGroup").InnerText.ToUpper() == "TRUE";
            //        var iconNode = menuItem.SelectSingleNode("icon");
            //        if (iconNode != null)
            //            xmlMenuItem.IconPath = iconNode.InnerText;

            //        xmlMenu.Menus.Add(xmlMenuItem);
            //    }
            //}
        }
        #endregion

        #region CreateMenus
        private void CreateSystemMenu()
        {
            _systemMenu = new SoftBarMenu(_form, "SystemMenu", 0, true);
            _systemMenu.Setup();
            _systemMenu.Button.Click += Button_Click;
            _systemMenu.Button.Tag = _systemMenu;
            _systemMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.SystemMenu);

            // Reload the app bar
            SoftBarMenuItem reloadItem = new SoftBarMenuItem(_form, "Reload", false, true);
            reloadItem.Setup(_systemMenu.PopupMenu);
            reloadItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Reload);
            reloadItem.Item.ItemClick += Reload_ItemClick;

            // Settings for the app bar
            SoftBarMenuItem settingsItem = new SoftBarMenuItem(_form, "Settings", false, true);
            settingsItem.Setup(_systemMenu.PopupMenu);
            settingsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Settings);
            settingsItem.Item.ItemClick += SettingsItem_ItemClick;

            //// Customize the app bar menu
            //SoftBarSubMenu customizeSubMenuItem = new SoftBarSubMenu(_form, "Customize");
            //customizeSubMenuItem.Setup(_systemMenu.PopupMenu);
            //customizeSubMenuItem.SubMenu.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Preferences);

            // Customize the app bar
            SoftBarMenuItem customizeItem = new SoftBarMenuItem(_form, "Customize in SoftBar editor",false,true);
            customizeItem.Setup(_systemMenu.PopupMenu);
            //customizeSubMenuItem.MenuItems.Add(customizeItem);
            //customizeSubMenuItem.SubMenu.AddItem(customizeItem.Item);
            customizeItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Preferences);
            customizeItem.Item.ItemClick += CustomizeItem_ItemClick;

            // Customize the app bar in notepad
            SoftBarMenuItem openInNotepadItem = new SoftBarMenuItem(_form, "Customize in Notepad (risky!)", false,true);
            openInNotepadItem.Setup(_systemMenu.PopupMenu);
            //customizeSubMenuItem.MenuItems.Add(openInNotepadItem);
            //customizeSubMenuItem.SubMenu.AddItem(openInNotepadItem.Item);
            openInNotepadItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Preferences);
            openInNotepadItem.Item.ItemClick += openInNotepadItem_ItemClick; ;

            // Exit the app bar
            SoftBarMenuItem exitItem = new SoftBarMenuItem(_form, "Exit", true, true);
            exitItem.Setup(_systemMenu.PopupMenu);
            exitItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Exit);
            exitItem.BeginGroup = true;
            exitItem.Item.ItemClick += ExitItem_ItemClick;
        }

        private void CreateDirectoriesMenu()
        {
            _directoriesMenu = new SoftBarMenu(_form, "Directories", _systemMenu.Width, true);
            _directoriesMenu.Setup();
            _directoriesMenu.Button.Click += Button_Click;
            _directoriesMenu.Button.Tag = _directoriesMenu;
            _directoriesMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Directories);

            // Add drives
            DriveType? driveType = null;
            DriveInfo[] drives=DriveInfo.GetDrives();
            foreach (DriveInfo  drive in drives)
            {
                // Create a menu item for the drive
                SoftBarMenuItem driveItem = new SoftBarMenuItem(_form,  drive.Name, false, true);

                if (driveType!=drive.DriveType)
                    driveItem.BeginGroup = true;

                driveItem.Setup(_directoriesMenu.PopupMenu);
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

                driveType = drive.DriveType;
            }

            // Add special directories
            SoftBarMenuItem desktopItem = new SoftBarMenuItem(_form, "Desktop", true, true);
            desktopItem.Setup(_directoriesMenu.PopupMenu);
            desktopItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Directories);
            desktopItem.Item.ItemClick += DesktopItem_ItemClick; ;

            SoftBarMenuItem documentsItem = new SoftBarMenuItem(_form, "Documents", false, true);
            documentsItem.Setup(_directoriesMenu.PopupMenu);
            documentsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Document);
            documentsItem.Item.ItemClick += DocumentsItem_ItemClick; ;

            SoftBarMenuItem downloadsItem = new SoftBarMenuItem(_form, "Downloads", false,true);
            downloadsItem.Setup(_directoriesMenu.PopupMenu);
            downloadsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Download);
            downloadsItem.Item.ItemClick += DocumentsItem_ItemClick; ;

        }

        public void CreateMenus()
        {
            foreach (SoftBarMenu menu in _menus)
            {
                menu.Setup();
                CreateMenu(menu);
            }
        }
        private void CreateMenu(SoftBarMenu menu)
        {
            foreach (SoftBarBaseItem item in menu.MenuItems)
            {
                if (item is SoftBarSubMenu)
                {
                    //CreateSubMenu(menu, item);
                }
                else if (item is SoftBarHeaderItem)
                {
                    var menuItem = item as SoftBarHeaderItem;
                    menuItem.Setup(menu.PopupMenu);
                }
                else if (item is SoftBarSubMenu)
                {
                    var menuItem = item as SoftBarSubMenu;
                    menuItem.Setup(menu.PopupMenu);
                }
                else
                {
                    var menuItem = item as SoftBarMenuItem;
                    menuItem.Setup(menu.PopupMenu);
                }
            }
        }
        #endregion

        #region Misc functions
        private int GetCurrentWidth()
        {
            int width = _systemMenu.Width + SEPARATOR_WIDTH + _directoriesMenu.Width + SEPARATOR_WIDTH;

            foreach (var menu in _menus)
                width += menu.Width + SEPARATOR_WIDTH;

            return width;
        }
        #endregion

        #region Events
        private void Reload_ItemClick(object sender, ItemClickEventArgs e)
        {
            AppBarFunctions.SetAppBar(_form, AppBarEdge.None);
            AppBarFunctions.SetAppBar(_form, AppBarEdge.Top);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var menu = (SoftBarMenu)((SimpleButton)sender).Tag;
            menu.PopupMenu.ShowPopup(new Point(menu.Left, 0));
        }

        private void CustomizeItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (CustomizationForm form = new CustomizationForm(this, _path))
            {
                form.ShowDialog();
            }
        }

        private void ExitItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _form.Close();
        }

        private void SettingsItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (SettingsForm form = new SettingsForm())
            {
                form.ShowDialog();
            }
        }

        private void DesktopItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandLine.ExecuteCommandLine(@"Explorer.exe %USERPROFILE%\Desktop");
        }

        private void DocumentsItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandLine.ExecuteCommandLine(@"Explorer.exe %USERPROFILE%\Documents");
        }

        private void DriveItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var drive = ((DriveInfo)e.Item.Tag);
            Process.Start(drive.Name);
        }

        private void openInNotepadItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var path = Core.Properties.Settings.Default.SoftBarXmlPath;
            CommandLine.ExecuteCommandLine(path);
        }

        #endregion
    }
}
