using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SoftTeam.SoftBar.Core.NewXml
{
    public class NewXmlMenu
    {
        private string _name = string.Empty;
        private string _iconPath = string.Empty;
        private bool _beginGroup = false;
        private List<NewXmlMenuItemBase> _menuItems = null;

        public NewXmlMenu()
        {
            _menuItems = new List<NewXmlMenuItemBase>();
        }

        public string Name { get => _name; set => _name = value; }
        public string IconPath { get => _iconPath; set => _iconPath = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }
        public List<NewXmlMenuItemBase> MenuItems { get => _menuItems; set => _menuItems = value; }

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
                        NewXmlSubMenu subMenu = new NewXmlSubMenu();
                        subMenu.ParseXml(subMenuNode);
                        _menuItems.Add(subMenu);
                        break;
                    case "headeritem":
                        NewXmlHeaderItem headerItem = new NewXmlHeaderItem();
                        headerItem.ParseXml(subMenuNode);
                        _menuItems.Add(headerItem);
                        break;
                    case "menuitem":
                        NewXmlMenuItem menuItem = new NewXmlMenuItem();
                        menuItem.ParseXml(subMenuNode);
                        _menuItems.Add(menuItem);
                        break;
                }
            }
        }
    }
}
