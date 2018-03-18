using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SoftTeam.SoftBar.Core.NewXml
{
    /// <summary>
    /// Class for a user button area (Xml)
    /// </summary>
    public class NewXmlArea
    {
        private List<NewXmlMenu> _menus = null;

        public NewXmlArea()
        {
            _menus = new List<NewXmlMenu>();
        }

        public List<NewXmlMenu> Menus { get => _menus; set => _menus = value; }

        // Parse an area node
        public void ParseXml(XmlNode areaNode)
        {
            // and loop through them
            foreach (XmlNode menuNode in areaNode)
            {
                // Create the new menu
                NewXmlMenu menu = new NewXmlMenu();
                // Parse the xml for this menu
                menu.ParseXml(menuNode);
                // Add the menu to the user menu collection
                _menus.Add(menu);
            }

        }
    }
}
