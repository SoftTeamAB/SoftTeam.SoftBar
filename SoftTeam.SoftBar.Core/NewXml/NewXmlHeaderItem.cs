using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SoftTeam.SoftBar.Core.NewXml
{
    /// <summary>
    /// Class for a header item (Xml)
    /// </summary>
    public class NewXmlHeaderItem : NewXmlMenuItemBase
    {
        private bool _beginGroup = false;

        public NewXmlHeaderItem()
        {
        }

        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }

        // Parse a sub menu node
        public void ParseXml(XmlNode headerItemNode)
        {
            // Get the name of the menu
            _name = headerItemNode.Attributes["name"].Value;

            // Check if the menu has an beginGroup attribute
            var beginGroupAttribute = headerItemNode.Attributes["beginGroup"];
            if (beginGroupAttribute != null)
                _beginGroup = beginGroupAttribute.Value.ToLower() == "true";
        }
    }
}
