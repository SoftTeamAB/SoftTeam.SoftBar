using DevExpress.XtraBars;
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
using System.Xml.Linq;
using System.Xml.Schema;

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

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "SoftBar.xsd");
            doc.Schemas = schemas;
            doc.Load(_path);

            doc.Validate((o, e) => {
                Debug.WriteLine(e.Message);
            });

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

        private void LoadXmlMenu(XmlNode xmlMenu, SoftBarBaseMenu softMenu)
        {
            foreach (XmlNode menuItem in xmlMenu)
            {
                var name = menuItem.Attributes["name"].Value;

                bool beginGroup = false;
                var beginGroupAttribute = menuItem.Attributes["beginGroup"];
                if (beginGroupAttribute != null)
                    beginGroup = beginGroupAttribute.Value.ToUpper() == "TRUE";

                string iconPath = "";
                var iconPathAttribute = menuItem.Attributes["iconPath"];
                if (iconPathAttribute != null)
                    iconPath = iconPathAttribute.Value;

                // Is it a sub menu, header item or a ordinary menu item
                if (menuItem.Name == "menu")
                {
                    //// Create the new sub menu
                    SoftBarSubMenu xmlSubMenu = new SoftBarSubMenu(_form, name, false);

                    // Begin group (must be set after the element is added to the manager)
                    xmlSubMenu.BeginGroup = beginGroup;

                    // Icon path
                    xmlSubMenu.IconPath = iconPath;

                    softMenu.MenuItems.Add(xmlSubMenu);

                    LoadXmlMenu(menuItem, xmlSubMenu);
                }
                if (menuItem.Name == "headerItem")
                {
                    // Create the new headerItem
                    SoftBarHeaderItem headerItem = new SoftBarHeaderItem(_form, name);

                    // Begin group (must be set after the element is added to the manager)
                    headerItem.BeginGroup = beginGroup;

                    // Icon path
                    headerItem.IconPath = iconPath;

                    softMenu.MenuItems.Add(headerItem);
                }
                else
                {
                    SoftBarMenuItem xmlMenuItem = new SoftBarMenuItem(_form, name);

                    // Application and document path
                    var applicationNode = menuItem.SelectSingleNode("applicationPath");
                    xmlMenuItem.ApplicationPath = applicationNode == null ? "" : applicationNode.InnerText;
                    var documentNode = menuItem.SelectSingleNode("documentPath");
                    xmlMenuItem.DocumentPath = documentNode == null ? "" : documentNode.InnerText;

                    // Begin group (must be set after the element is added to the manager)
                    xmlMenuItem.BeginGroup = beginGroup;

                    // Icon path
                    xmlMenuItem.IconPath = iconPath;

                    softMenu.MenuItems.Add(xmlMenuItem);
                }
            }
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
            SoftBarMenuItem reloadItem = new SoftBarMenuItem(_form, "Reload", true);
            reloadItem.Setup();
            reloadItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Reload);
            reloadItem.Item.ItemClick += Reload_ItemClick;
            _systemMenu.PopupMenu.AddItem(reloadItem.Item);

            // Settings for the app bar
            SoftBarMenuItem settingsItem = new SoftBarMenuItem(_form, "Settings", true);
            settingsItem.Setup();
            settingsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Settings);
            settingsItem.Item.ItemClick += SettingsItem_ItemClick;
            _systemMenu.PopupMenu.AddItem(settingsItem.Item);

            //// Customize the app bar menu
            //SoftBarSubMenu customizeSubMenuItem = new SoftBarSubMenu(_form, "Customize");
            //customizeSubMenuItem.Setup(_systemMenu.PopupMenu);
            //customizeSubMenuItem.SubMenu.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Preferences);

            // Customize the app bar
            SoftBarMenuItem customizeItem = new SoftBarMenuItem(_form, "Customize in SoftBar editor", true);
            customizeItem.Setup();
            //customizeSubMenuItem.MenuItems.Add(customizeItem);
            //customizeSubMenuItem.SubMenu.AddItem(customizeItem.Item);
            customizeItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Preferences);
            customizeItem.Item.ItemClick += CustomizeItem_ItemClick;
            _systemMenu.PopupMenu.AddItem(customizeItem.Item);

            // Customize the app bar in notepad
            SoftBarMenuItem openInNotepadItem = new SoftBarMenuItem(_form, "Customize in Notepad (risky!)", true);
            openInNotepadItem.Setup();
            //customizeSubMenuItem.MenuItems.Add(openInNotepadItem);
            //customizeSubMenuItem.SubMenu.AddItem(openInNotepadItem.Item);
            openInNotepadItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Preferences);
            openInNotepadItem.Item.ItemClick += openInNotepadItem_ItemClick; ;
            _systemMenu.PopupMenu.AddItem(openInNotepadItem.Item);

            // Exit the app bar
            SoftBarMenuItem exitItem = new SoftBarMenuItem(_form, "Exit", true);
            exitItem.Setup();
            exitItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Exit);
            exitItem.Item.ItemClick += ExitItem_ItemClick;
            _systemMenu.PopupMenu.AddItem(exitItem.Item);
            exitItem.Item.Links[0].BeginGroup = true;
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
            DriveInfo[] drives = DriveInfo.GetDrives();
            bool beginGroup = false;
            foreach (DriveInfo drive in drives)
            {
                // Create a menu item for the drive
                SoftBarMenuItem driveItem = new SoftBarMenuItem(_form, drive.Name, true);

                beginGroup = (driveType != drive.DriveType);

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
                _directoriesMenu.PopupMenu.AddItem(driveItem.Item);
                if (beginGroup)
                    driveItem.Item.Links[0].BeginGroup = true;

                driveType = drive.DriveType;
            }

            // Add special directories
            SoftBarMenuItem desktopItem = new SoftBarMenuItem(_form, "Desktop", true);
            desktopItem.Setup();
            desktopItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Directories);
            desktopItem.Item.ItemClick += DesktopItem_ItemClick; ;
            _directoriesMenu.PopupMenu.AddItem(desktopItem.Item);
            desktopItem.Item.Links[0].BeginGroup = true;

            SoftBarMenuItem documentsItem = new SoftBarMenuItem(_form, "Documents", true);
            documentsItem.Setup();
            documentsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Document);
            documentsItem.Item.ItemClick += DocumentsItem_ItemClick; ;
            _directoriesMenu.PopupMenu.AddItem(documentsItem.Item);

            SoftBarMenuItem downloadsItem = new SoftBarMenuItem(_form, "Downloads", true);
            downloadsItem.Setup();
            downloadsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Download);
            downloadsItem.Item.ItemClick += DocumentsItem_ItemClick; ;
            _directoriesMenu.PopupMenu.AddItem(downloadsItem.Item);

        }

        public void CreateMenus()
        {
            foreach (SoftBarMenu menu in _menus)
            {
                menu.Setup();
                CreateMenu(menu);
            }
        }
        private void CreateMenu(SoftBarBaseMenu menu)
        {
            foreach (SoftBarBaseItem item in menu.MenuItems)
            {
                if (item is SoftBarSubMenu)
                {
                    // We have a sub menu
                    var subMenu = item as SoftBarSubMenu;
                    // Add the sub menu to the main menu
                    var barSubMenu = subMenu.Setup();
                    subMenu.AddSubMenu(barSubMenu);
                    if (subMenu.BeginGroup) barSubMenu.Links[0].BeginGroup = true;

                    // Call create menu recursivly
                    CreateMenu(subMenu);
                }
                else if (item is SoftBarHeaderItem)
                {
                    var menuItem = item as SoftBarHeaderItem;
                    var barHeaderItem = menuItem.Setup();

                    if (menu.ParentSubMenu == null)
                        menu.ParentMenu.AddItem(barHeaderItem);
                    else
                        menu.ParentSubMenu.AddItem(barHeaderItem);

                    if (menuItem.BeginGroup) barHeaderItem.Links[0].BeginGroup = true;
                }
                else
                {
                    var menuItem = item as SoftBarMenuItem;
                    var barStaticItem = menuItem.Setup();

                    if (menu.ParentSubMenu == null)
                        menu.ParentMenu.AddItem(barStaticItem);
                    else
                        menu.ParentSubMenu.AddItem(barStaticItem);

                    if (menuItem.BeginGroup) barStaticItem.Links[0].BeginGroup = true;
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
