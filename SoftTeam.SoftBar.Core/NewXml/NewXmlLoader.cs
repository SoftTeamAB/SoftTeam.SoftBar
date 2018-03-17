using SoftTeam.SoftBar.Core.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace SoftTeam.SoftBar.Core.NewXml
{
    /// <summary>
    /// This class loads an Xml file containing the entire user area of the SoftBar
    /// </summary>
    public class NewXmlLoader
    {
        private string _path = string.Empty;
        private NewXmlArea _area = null;
        private List<string> _validationErrors = null;

        public List<string> ValidationErrors { get => _validationErrors; set => _validationErrors = value; }

        public NewXmlLoader(string path)
        {
            _path = path;
            _area = new NewXmlArea();
        }

        public NewXmlArea Load()
        {
            // Clear the validation errors
            _validationErrors = new List<string>();

            // Open the file and return a FileStream
            var file = CreateFileStream();
            // Create the settings
            var settings = CreateXmlReaderSettings();
            // Create the Xml reader
            var xmlReader = CreateXmlReader(file, settings);
            // Create the Xml document
            var document = new XmlDocument();
            // Create the Xml schema set
            var schemas = CreateSchemaSet();
            // Attach the schema
            document.Schemas = schemas;

            // Now we can load the XML document
            document.Load(xmlReader);
            // Validate it against the schema
            ValidateXml(document);

            // Check if we have validation errors
            if (_validationErrors.Count() > 0)
            {
                // Errors
                throw new XmlSchemaException("Xml did not validate!");
            }

            // Parse the xml
            var area = ParseXml(document);

            // Return the XmlArea
            return area;
        }

        // Create a FileStream for the Xml path
        private FileStream CreateFileStream()
        {
            return File.OpenRead(_path);
        }

        // Create Cml reader settings that ignores comments and white spaces
        private XmlReaderSettings CreateXmlReaderSettings()
        {
            return new XmlReaderSettings() { IgnoreComments = true, IgnoreWhitespace = true };
        }

        private XmlReader CreateXmlReader(FileStream file, XmlReaderSettings settings)
        {
            return XmlReader.Create(file, settings);
        }

        private XmlSchemaSet CreateSchemaSet()
        {
            var schemas = new XmlSchemaSet();
            schemas.Add("",HelperFunctions.GetXmlSchemaPath());
            return schemas;
        }

        private void ValidateXml(XmlDocument document)
        {
            // Validate the document against the schema
            document.Validate((o, e) =>
            {
                _validationErrors.Add(e.Message);
            });
        }

        private NewXmlArea ParseXml(XmlDocument document)
        {
            var area = new NewXmlArea();

            try
            {
                // Select all top level menus in the document
                XmlNode areaNode = document.SelectSingleNode("//softbar");
                // Parse the SoftBar node
                area.ParseXml(areaNode);
            }
            catch (Exception e)
            {
                _validationErrors.Add(e.Message);
            }

            return area;
        }
        #region Load menu
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
        #endregion

    }
}
