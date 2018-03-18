using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Core.SoftBar
{
    public class SoftBarManager
    {

        #region Fields
        private SoftBarArea _systemArea = null;
        private SoftBarArea _userArea = null;
        private MainAppBarForm _form = null;
        private string _path = "";

        public MainAppBarForm Form { get => _form; set => _form = value; }
        public SoftBarArea UserArea { get => _userArea; set => _userArea = value; }
        public SoftBarArea SystemArea { get => _systemArea; set => _systemArea = value; }
        #endregion

        #region Constructor
        public SoftBarManager(MainAppBarForm form, string path)
        {
            _form = form;
            _path = path;

            _systemArea = new SoftBarArea(form, AreaType.System, path);
            _userArea = new SoftBarArea(form, AreaType.User, path, _systemArea.Width);
        }
        #endregion

        //#region Load menu
        //public void LoadXml()
        //{
        //    // Create a reader for the XML...
        //    using (var file = File.OpenRead(_path))
        //    {
        //        // ...and read the XML (ignore comments and white spaces)
        //        var settings = new XmlReaderSettings() { IgnoreComments = true, IgnoreWhitespace = true };
        //        using (var xmlReader = XmlReader.Create(file, settings))
        //        {
        //            // Attach the schema
        //            var doc = new XmlDocument();
        //            XmlSchemaSet schemas = new XmlSchemaSet();
        //            // In debug mode we want to get the schema from SoftTeam.SoftBar.Core,
        //            // otherwise from the current directory
        //            if (Debugger.IsAttached)
        //            {
        //                var xsdPath = HelperFunctions.AssemblyDirectory;
        //                xsdPath = Path.GetFullPath(Path.Combine(xsdPath, @"..\..\..\"));
        //                xsdPath = Path.GetFullPath(Path.Combine(xsdPath, @"SoftTeam.SoftBar.Core\bin\Debug\SoftBar.xsd")); 
        //                schemas.Add("", xsdPath);
        //            }
        //            else
        //                schemas.Add("", "SoftBar.xsd");
        //            doc.Schemas = schemas;

        //            // Now we can load the XML document
        //            doc.Load(xmlReader);

        //            // Validate the document against the schema
        //            doc.Validate((o, e) =>
        //            {
        //                Debug.WriteLine(e.Message);
        //            });

        //            // Select all top level menus in the document
        //            XmlNode xmlMenus = doc.SelectSingleNode("//softbar");

        //            // and loop through them
        //            foreach (XmlNode xmlMenu in xmlMenus)
        //            {
        //                // Create the first level menu and add it
        //                SoftBarMenu softBarMenu = new SoftBarMenu(_form, xmlMenu.Attributes["name"].Value, GetCurrentWidth());

        //                // Check if the menu has an IconPath attribute
        //                var iconPathAttribute = xmlMenu.Attributes["iconPath"];
        //                if (iconPathAttribute != null)
        //                    softBarMenu.IconPath = iconPathAttribute.Value;

        //                // Add the menu to the user menu collection
        //                _userMenus.Add(softBarMenu);

        //                // Load the rest of the menu
        //                LoadXmlMenu(xmlMenu, softBarMenu);
        //            }
        //        }
        //    }
        //}

        //private void LoadXmlMenu(XmlNode xmlMenu, SoftBarBaseMenu softBarBaseMenu)
        //{
        //    // Loop through all menu items in the menu
        //    foreach (XmlNode xmlMenuItem in xmlMenu)
        //    {
        //        // First get some standard properties, name...
        //        var name = xmlMenuItem.Attributes["name"].Value;

        //        // ...beginGroup...
        //        bool beginGroup = false;
        //        var beginGroupAttribute = xmlMenuItem.Attributes["beginGroup"];
        //        if (beginGroupAttribute != null)
        //            beginGroup = beginGroupAttribute.Value.ToUpper() == "TRUE";

        //        // ...and IconPath...
        //        string iconPath = "";
        //        var iconPathAttribute = xmlMenuItem.Attributes["iconPath"];
        //        if (iconPathAttribute != null)
        //            iconPath = iconPathAttribute.Value;

        //        // Is it a sub menu, header item or a ordinary menu item
        //        if (xmlMenuItem.Name == "menu")
        //        {
        //            // Create the new sub menu
        //            SoftBarSubMenu softBarSubMenu = new SoftBarSubMenu(_form, name, false);

        //            // Begin group (must be set after the element is added to the manager, so here we are just storing it)
        //            softBarSubMenu.BeginGroup = beginGroup;

        //            // Store the Icon path
        //            softBarSubMenu.IconPath = iconPath;

        //            // Add the sub menu to the menu
        //            softBarBaseMenu.MenuItems.Add(softBarSubMenu);

        //            // Load all the menu items of the sub menu by calling this function recursively
        //            LoadXmlMenu(xmlMenuItem, softBarSubMenu);
        //        }
        //        else if (xmlMenuItem.Name == "headerItem")
        //        {
        //            // Create the new headerItem
        //            SoftBarHeaderItem softBarHeaderItem = new SoftBarHeaderItem(_form, name);

        //            // Begin group (must be set after the element is added to the manager)
        //            softBarHeaderItem.BeginGroup = beginGroup;

        //            // Store the Icon path
        //            softBarHeaderItem.IconPath = iconPath;

        //            // Add the header item to the menu
        //            softBarBaseMenu.MenuItems.Add(softBarHeaderItem);
        //        }
        //        else
        //        {
        //            // Create the new menu item
        //            SoftBarMenuItem softBarMenuItem = new SoftBarMenuItem(_form, name);

        //            // Get and store the application and document path
        //            var applicationNodeElement = xmlMenuItem.SelectSingleNode("applicationPath");
        //            softBarMenuItem.ApplicationPath = applicationNodeElement == null ? "" : applicationNodeElement.InnerText;
        //            var documentNodeElement = xmlMenuItem.SelectSingleNode("documentPath");
        //            softBarMenuItem.DocumentPath = documentNodeElement == null ? "" : documentNodeElement.InnerText;

        //            // Begin group (must be set after the element is added to the manager)
        //            softBarMenuItem.BeginGroup = beginGroup;

        //            // Store the Icon path
        //            if (!string.IsNullOrEmpty(iconPath))
        //                softBarMenuItem.IconPath = iconPath;

        //            // Add the menu item to the menu
        //            softBarBaseMenu.MenuItems.Add(softBarMenuItem);
        //        }
        //    }
        //}
        //#endregion

        //#region Create user menus
        //// Build the user menus
        //public void CreateMenus()
        //{
        //    foreach (SoftBarMenu softBarMenu in _userMenus)
        //    {
        //        softBarMenu.Setup();
        //        CreateMenu(softBarMenu);
        //    }
        //}

        //// Build a user menu
        //private void CreateMenu(SoftBarBaseMenu softBarBaseMenu)
        //{
        //    // For all menu items in the menu
        //    foreach (SoftBarBaseItem softBarBaseItem in softBarBaseMenu.MenuItems)
        //    {
        //        if (softBarBaseItem is SoftBarSubMenu)
        //        {
        //            // We have a sub menu
        //            var softBarSubMenu = softBarBaseItem as SoftBarSubMenu;

        //            // Create the sub menu 
        //            var barSubItem = softBarSubMenu.Setup(softBarBaseMenu);

        //            // Add the sub menu
        //            if (softBarBaseMenu is SoftBarMenu)
        //                ((SoftBarMenu)softBarBaseMenu).Item.AddItem(barSubItem);
        //            else
        //                ((SoftBarSubMenu)softBarBaseMenu).Item.AddItem(barSubItem);

        //            // Create a new group if beginGroup is true
        //            if (softBarSubMenu.BeginGroup) barSubItem.Links[0].BeginGroup = true;

        //            // Call create menu recursivly
        //            CreateMenu(softBarSubMenu);
        //        }
        //        else if (softBarBaseItem is SoftBarHeaderItem)
        //        {
        //            // We have a header item
        //            var softBarHeaderItem = softBarBaseItem as SoftBarHeaderItem;

        //            // Create the header item
        //            var barHeaderItem = softBarHeaderItem.Setup();

        //            // Add the header item to the menu
        //            if (softBarBaseMenu is SoftBarMenu)
        //                ((SoftBarMenu)softBarBaseMenu).Item.AddItem(barHeaderItem);
        //            else
        //                ((SoftBarSubMenu)softBarBaseMenu).Item.AddItem(barHeaderItem);

        //            // Create a new group if beginGroup is true
        //            if (softBarHeaderItem.BeginGroup) barHeaderItem.Links[0].BeginGroup = true;
        //        }
        //        else
        //        {
        //            // We have a menu item
        //            var softBarMenuItem = softBarBaseItem as SoftBarMenuItem;

        //            // Create the menu item
        //            var barStaticItem = softBarMenuItem.Setup();

        //            // Add the menu item to the menu
        //            if (softBarBaseMenu is SoftBarMenu)
        //                ((SoftBarMenu)softBarBaseMenu).Item.AddItem(barStaticItem);
        //            else
        //                ((SoftBarSubMenu)softBarBaseMenu).Item.AddItem(barStaticItem);

        //            // Create a new group if beginGroup is true
        //            if (softBarMenuItem.BeginGroup) barStaticItem.Links[0].BeginGroup = true;
        //        }
        //    }
        //}
        //#endregion
    }
}
