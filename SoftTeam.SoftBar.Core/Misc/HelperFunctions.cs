using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace SoftTeam.SoftBar.Core.Misc
{
    public class HelperFunctions
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static string GetTypeName(MenuItemType type)
        {
            switch(type)
            {
                case MenuItemType.Menu:
                    return "Menu";
                case MenuItemType.SubMenu:
                    return "Sub menu";
                case MenuItemType.HeaderItem:
                    return "Header";
                case MenuItemType.MenuItem:
                    return "Menu item";
                case MenuItemType.None:
                    return "Error : None is not a valid type!";
                default:
                    return "Error : Invalid type!";
            }
        }
        public static Color GetTypeColor(object type)
        {
            switch (type)
            {
                case MenuItemType.Menu:
                    return Color.FromArgb(80,80,80);
                case MenuItemType.SubMenu:
                    return Color.FromArgb(80,80,80);
                case MenuItemType.HeaderItem:
                    return Color.Gray;
                case MenuItemType.MenuItem:
                    return Color.LightGray;
                case MenuItemType.None:
                    return Color.Red;
                default:
                    return Color.Red;
            }
        }

        public static string GetSettingsPath()
        {
            var path = Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            path = System.IO.Path.Combine(path, "SoftTeam AB");
            path = System.IO.Path.Combine(path, "SoftBar");
            System.IO.Directory.CreateDirectory(path);
            path = System.IO.Path.Combine(path, "settings.xml");

            return path;
        }

        public static Image ExtractIcon(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;
            else
            {
                // Extract the icon...
                Image iconImage = Icon.ExtractAssociatedIcon(path).ToBitmap();
                // and return an 16x16 image
                return iconImage.ResizeImage(16, 16);
            }
        }

        public static string GetXmlSchemaPath(bool debug = false)
        {
            if (debug)
            {
                var xsdPath = HelperFunctions.AssemblyDirectory;
                xsdPath = Path.GetFullPath(Path.Combine(xsdPath, @"..\..\..\"));
                xsdPath = Path.GetFullPath(Path.Combine(xsdPath, @"SoftTeam.SoftBar.Core\bin\Debug\Xml\SoftBar.xsd"));
                return xsdPath;
            }
            else
                return @"Xml\SoftBar.xsd";

        }
    }
}
