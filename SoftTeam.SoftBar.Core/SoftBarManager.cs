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
            // Create a reader for the XML...
            using (var file = File.OpenRead(_path))
            {
                // ...and read the XML (ignore comments and white spaces)
                var settings = new XmlReaderSettings() { IgnoreComments = true, IgnoreWhitespace = true };
                using (var xmlReader = XmlReader.Create(file, settings))
                {
                    // Attach the schema
                    var doc = new XmlDocument();
                    XmlSchemaSet schemas = new XmlSchemaSet();
                    // In debug mode we want to get the schema from SoftTeam.SoftBar.Core,
                    // otherwise from the current directory
                    if (Debugger.IsAttached)
                        schemas.Add("", @"..\..\..\SoftTeam.SoftBar.Core\bin\Debug\SoftBar.xsd");
                    else
                        schemas.Add("", "SoftBar.xsd");
                    doc.Schemas = schemas;

                    // Now we can load the XML document
                    doc.Load(xmlReader);

                    // Validate the document against the schema
                    doc.Validate((o, e) =>
                    {
                        Debug.WriteLine(e.Message);
                    });

                    // Select all top level menus in the document
                    XmlNode menus = doc.SelectSingleNode("//softbar");

                    // and loop through them
                    foreach (XmlNode menu in menus)
                    {
                        // Create the first level menu and add it
                        SoftBarMenu xmlMenu = new SoftBarMenu(_form, menu.Attributes["name"].Value, GetCurrentWidth());

                        // Check if the menu has an IconPath attribute
                        var iconNode = menu.Attributes["iconPath"];
                        if (iconNode != null)
                            xmlMenu.IconPath = iconNode.Value;

                        // Add the menu to the user menu collection
                        _menus.Add(xmlMenu);

                        // Load the rest of the menu
                        LoadXmlMenu(menu, xmlMenu);
                    }
                }
            }
        }

        private void LoadXmlMenu(XmlNode xmlMenu, SoftBarBaseMenu softMenu)
        {
            // Loop through all menu items in the menu
            foreach (XmlNode menuItem in xmlMenu)
            {
                // First get some standard properties, name...
                var name = menuItem.Attributes["name"].Value;

                // ...beginGroup...
                bool beginGroup = false;
                var beginGroupAttribute = menuItem.Attributes["beginGroup"];
                if (beginGroupAttribute != null)
                    beginGroup = beginGroupAttribute.Value.ToUpper() == "TRUE";

                // ...and IconPath...
                string iconPath = "";
                var iconPathAttribute = menuItem.Attributes["iconPath"];
                if (iconPathAttribute != null)
                    iconPath = iconPathAttribute.Value;

                // Is it a sub menu, header item or a ordinary menu item
                if (menuItem.Name == "menu")
                {
                    // Create the new sub menu
                    SoftBarSubMenu xmlSubMenu = new SoftBarSubMenu(_form, name, false);

                    // Begin group (must be set after the element is added to the manager, so here we are just storing it)
                    xmlSubMenu.BeginGroup = beginGroup;

                    // Store the Icon path
                    xmlSubMenu.IconPath = iconPath;

                    // Add the sub menu to the menu
                    softMenu.MenuItems.Add(xmlSubMenu);

                    // Load all the menu items of the sub menu by calling this function recursively
                    LoadXmlMenu(menuItem, xmlSubMenu);
                }
                else if (menuItem.Name == "headerItem")
                {
                    // Create the new headerItem
                    SoftBarHeaderItem headerItem = new SoftBarHeaderItem(_form, name);

                    // Begin group (must be set after the element is added to the manager)
                    headerItem.BeginGroup = beginGroup;

                    // Store the Icon path
                    headerItem.IconPath = iconPath;

                    // Add the header item to the menu
                    softMenu.MenuItems.Add(headerItem);
                }
                else
                {
                    // Create the new menu item
                    SoftBarMenuItem xmlMenuItem = new SoftBarMenuItem(_form, name);

                    // Get and store the application and document path
                    var applicationNode = menuItem.SelectSingleNode("applicationPath");
                    xmlMenuItem.ApplicationPath = applicationNode == null ? "" : applicationNode.InnerText;
                    var documentNode = menuItem.SelectSingleNode("documentPath");
                    xmlMenuItem.DocumentPath = documentNode == null ? "" : documentNode.InnerText;

                    // Begin group (must be set after the element is added to the manager)
                    xmlMenuItem.BeginGroup = beginGroup;

                    // Store the Icon path
                    xmlMenuItem.IconPath = iconPath;

                    // Add the menu item to the menu
                    softMenu.MenuItems.Add(xmlMenuItem);
                }
            }
        }
        #endregion

        #region CreateMenus
        private void CreateSystemMenu()
        {
            // Create the actual system menu
            _systemMenu = new SoftBarMenu(_form, "SystemMenu", 0, true);
            _systemMenu.Setup();
            _systemMenu.Button.Click += Button_Click;
            _systemMenu.Button.Tag = _systemMenu;
            _systemMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.SystemMenu);

            // Reload the app bar menu item
            SoftBarMenuItem reloadItem = new SoftBarMenuItem(_form, "Reload", true);
            reloadItem.Setup();
            reloadItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Reload);
            reloadItem.Item.ItemClick += Reload_ItemClick;
            _systemMenu.Item.AddItem(reloadItem.Item);

            // Settings for the app bar
            SoftBarMenuItem settingsItem = new SoftBarMenuItem(_form, "Settings", true);
            settingsItem.Setup();
            settingsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Settings);
            settingsItem.Item.ItemClick += SettingsItem_ItemClick;
            _systemMenu.Item.AddItem(settingsItem.Item);

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
            _systemMenu.Item.AddItem(customizeItem.Item);

            // Customize the app bar in notepad
            SoftBarMenuItem openInNotepadItem = new SoftBarMenuItem(_form, "Customize in Notepad (risky!)", true);
            openInNotepadItem.Setup();
            //customizeSubMenuItem.MenuItems.Add(openInNotepadItem);
            //customizeSubMenuItem.SubMenu.AddItem(openInNotepadItem.Item);
            openInNotepadItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Preferences);
            openInNotepadItem.Item.ItemClick += openInNotepadItem_ItemClick; ;
            _systemMenu.Item.AddItem(openInNotepadItem.Item);

            // Exit the app bar
            SoftBarMenuItem exitItem = new SoftBarMenuItem(_form, "Exit", true);
            exitItem.Setup();
            exitItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Exit);
            exitItem.Item.ItemClick += ExitItem_ItemClick;
            _systemMenu.Item.AddItem(exitItem.Item);
            exitItem.Item.Links[0].BeginGroup = true;
        }

        private void CreateDirectoriesMenu()
        {
            // Create the actual directories menu
            _directoriesMenu = new SoftBarMenu(_form, "Directories", _systemMenu.Width, true);
            _directoriesMenu.Setup();
            _directoriesMenu.Button.Click += Button_Click;
            _directoriesMenu.Button.Tag = _directoriesMenu;
            _directoriesMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Directories);

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
                _directoriesMenu.Item.AddItem(driveItem.Item);
                if (beginGroup)
                    driveItem.Item.Links[0].BeginGroup = true;

                driveType = drive.DriveType;
            }

            // Add special directory for the desktop folder
            SoftBarMenuItem desktopItem = new SoftBarMenuItem(_form, "Desktop", true);
            desktopItem.Setup();
            desktopItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Directories);
            desktopItem.Item.ItemClick += DesktopItem_ItemClick; ;
            _directoriesMenu.Item.AddItem(desktopItem.Item);
            desktopItem.Item.Links[0].BeginGroup = true;

            // Add special directory for the documents folder
            SoftBarMenuItem documentsItem = new SoftBarMenuItem(_form, "Documents", true);
            documentsItem.Setup();
            documentsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Document);
            documentsItem.Item.ItemClick += DocumentsItem_ItemClick; ;
            _directoriesMenu.Item.AddItem(documentsItem.Item);

            // Add special directory for the downloads folder
            SoftBarMenuItem downloadsItem = new SoftBarMenuItem(_form, "Downloads", true);
            downloadsItem.Setup();
            downloadsItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Download);
            downloadsItem.Item.ItemClick += DocumentsItem_ItemClick; ;
            _directoriesMenu.Item.AddItem(downloadsItem.Item);

        }

        // Build the user menus
        public void CreateMenus()
        {
            foreach (SoftBarMenu menu in _menus)
            {
                menu.Setup();
                CreateMenu(menu);
            }
        }

        // Build a user menu
        private void CreateMenu(SoftBarBaseMenu menu)
        {
            // For all menu items in the menu
            foreach (SoftBarBaseItem item in menu.MenuItems)
            {
                if (item is SoftBarSubMenu)
                {
                    // We have a sub menu
                    var subMenu = item as SoftBarSubMenu;

                    // Create the sub menu 
                    var barSubMenu = subMenu.Setup();

                    // Add the sub menu
                    if (menu is SoftBarMenu)
                        ((SoftBarMenu)menu).Item.AddItem(barSubMenu);
                    else
                        ((SoftBarSubMenu)menu).Item.AddItem(barSubMenu);

                    // Create a new group if beginGroup is true
                    if (subMenu.BeginGroup) barSubMenu.Links[0].BeginGroup = true;

                    // Call create menu recursivly
                    CreateMenu(subMenu);
                }
                else if (item is SoftBarHeaderItem)
                {
                    // We have a header item
                    var menuItem = item as SoftBarHeaderItem;

                    // Create the header item
                    var barHeaderItem = menuItem.Setup();

                    // Add the header item to the menu
                    if (menu is SoftBarMenu)
                        ((SoftBarMenu)menu).Item.AddItem(barHeaderItem);
                    else
                        ((SoftBarSubMenu)menu).Item.AddItem(barHeaderItem);

                    // Create a new group if beginGroup is true
                    if (menuItem.BeginGroup) barHeaderItem.Links[0].BeginGroup = true;
                }
                else
                {
                    // We have a menu item
                    var menuItem = item as SoftBarMenuItem;

                    // Create the menu item
                    var barStaticItem = menuItem.Setup();

                    // Add the menu item to the menu
                    if (menu is SoftBarMenu)
                        ((SoftBarMenu)menu).Item.AddItem(barStaticItem);
                    else
                        ((SoftBarSubMenu)menu).Item.AddItem(barStaticItem);

                    // Create a new group if beginGroup is true
                    if (menuItem.BeginGroup) barStaticItem.Links[0].BeginGroup = true;
                }
            }
        }
        #endregion

        #region Misc functions
        /// <summary>
        /// Calculate the width of the current menues that have been added
        /// </summary>
        /// <returns>int</returns>
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
            menu.Item.ShowPopup(new Point(menu.Left, 0));
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
