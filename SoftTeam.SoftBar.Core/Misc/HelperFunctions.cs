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
                    return Color.FromArgb(102,153,114);
                case MenuItemType.SubMenu:
                    return Color.FromArgb(178, 229, 190);
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
    }
}
