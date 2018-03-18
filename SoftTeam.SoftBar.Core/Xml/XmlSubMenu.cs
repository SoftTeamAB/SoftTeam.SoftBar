using System.Collections.Generic;
using System.Xml;

namespace SoftTeam.SoftBar.Core.Xml
{
    // Class for a sub menu (Xml)
    public class XmlSubMenu : XmlMenuBase
    {
        private string _iconPath = string.Empty;
        private bool _beginGroup = false;

        public XmlSubMenu()
        {
        }

        public string IconPath { get => _iconPath; set => _iconPath = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }

        // Parse a sub menu node
        public void ParseXml(XmlNode parentMenuNode)
        {
            // Get the name of the menu
            _name = parentMenuNode.Attributes["name"].Value;

            // Check if the menu has an iconPath attribute
            var iconPathAttribute = parentMenuNode.Attributes["iconPath"];
            if (iconPathAttribute != null)
                _iconPath = iconPathAttribute.Value;

            // Check if the menu has an beginGroup attribute
            var beginGroupAttribute = parentMenuNode.Attributes["beginGroup"];
            if (beginGroupAttribute != null)
                _beginGroup = beginGroupAttribute.Value.ToLower() == "true";

            // Loop through the sub menus, header items and menu items
            foreach (XmlNode subMenuNode in parentMenuNode)
            {
                switch (subMenuNode.Name.ToLower())
                {
                    case "menu":
                        XmlSubMenu subMenu = new XmlSubMenu();
                        subMenu.ParseXml(subMenuNode);
                        _menuItems.Add(subMenu);
                        break;
                    case "headeritem":
                        XmlHeaderItem headerItem = new XmlHeaderItem();
                        headerItem.ParseXml(subMenuNode);
                        _menuItems.Add(headerItem);
                        break;
                    case "menuitem":
                        XmlMenuItem menuItem = new XmlMenuItem();
                        menuItem.ParseXml(subMenuNode);
                        _menuItems.Add(menuItem);
                        break;
                }
            }
        }
    }
}
