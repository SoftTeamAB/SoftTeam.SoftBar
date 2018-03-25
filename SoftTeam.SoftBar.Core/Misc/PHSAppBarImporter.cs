using SoftTeam.SoftBar.Core.Xml;
using System;
using System.IO;
using System.Text;

namespace SoftTeam.SoftBar.Core.Misc
{
    /// <summary>
    /// Class for importing from the old PHS AppBar
    /// </summary>
    public class PHSAppBarImporter : IDisposable
    {
        #region Fields
        private StringReader _reader;
        private XmlArea _area = new XmlArea();
        private string nextLine = "";
        #endregion

        #region Constructor
        public PHSAppBarImporter(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);

            _reader = new StringReader(File.ReadAllText(path, Encoding.UTF7));
        }
        #endregion

        #region Import
        public XmlArea Import()
        {
            ReadVersionItem();

            while (ReadMenu())
            {

            }

            return _area;
        }

        private bool ReadMenu()
        {
            if (!nextLine.StartsWith("[MENU]"))
            {
                nextLine = GetNextLine();
                if (nextLine == null)
                    return false;

                if (!nextLine.StartsWith("[MENU]"))
                    return false;
            }

            var name = nextLine.Substring(6);

            XmlMenu menu = new XmlMenu();
            menu.Name = name;
            menu.Width = 100;

            while (!string.IsNullOrEmpty(nextLine))
            {
                var beginGroup = false;
                if (nextLine.StartsWith("[LINE]"))
                {
                    beginGroup = true;
                    nextLine = GetNextLine();
                    if (nextLine == null)
                        return false;
                }

                if (nextLine.StartsWith("[TEXT]"))
                {                    
                    var headerText = nextLine.Substring(6);
                    XmlHeaderItem headerItem = new XmlHeaderItem();
                    headerItem.Name = headerText;
                    headerItem.BeginGroup = beginGroup;
                    menu.MenuItems.Add(headerItem);
                }

                if (nextLine.StartsWith("[DESC]"))
                {
                    var menuItemText = nextLine.Substring(6);
                    XmlMenuItem menuItem = new XmlMenuItem();
                    menuItem.Name = menuItemText;
                    menuItem.BeginGroup = beginGroup;

                    nextLine = GetNextLine();
                    var itemText = nextLine.Substring(6);
                    menuItem.ApplicationPath = itemText;

                    nextLine = GetNextLine();
                    var iconText = nextLine.Substring(6);
                    menuItem.IconPath = iconText;

                    nextLine = GetNextLine();
                    var numberText = nextLine.Substring(6);
                    menuItem.IconNumber = int.Parse(numberText);

                    menu.MenuItems.Add(menuItem);
                }

                nextLine = GetNextLine();
                if (nextLine == null)
                {
                    // This menu is done, and we've reached the end of the file
                    _area.Menus.Add(menu);
                    return false;
                }
                else if (nextLine.StartsWith("[MENU]"))
                {
                    // This menu is done, let's read another one
                    _area.Menus.Add(menu);
                    return true;
                }
            }

            return true;
        }

        private void ReadVersionItem()
        {
            nextLine = GetNextLine();

            if (!nextLine.StartsWith("[VERS]"))
                throw new FormatException();
        }

        private string GetNextLine()
        {
            string s = _reader.ReadLine();
            if (s == null) return null;

            while (s == "")
            {
                s = _reader.ReadLine();
                if (s == null) return null;
            }

            return s;
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            _reader.Close();
            _reader.Dispose();
            _reader = null;

            _area = null;
        }
        #endregion
    }
}
