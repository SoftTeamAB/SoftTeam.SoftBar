using System.Xml;

namespace SoftTeam.SoftBar.Core.Xml
{
    /// <summary>
    /// Class for a header item (Xml)
    /// </summary>
    public class XmlHeaderItem : XmlMenuItemBase
    {
        #region Constructor
        public XmlHeaderItem()
        {
        }
        #endregion

        #region ParseXml
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
        #endregion

        #region Overrides
        public override int CountItems()
        {
            return 1;
        }

        public override bool ContainsItem(XmlMenuItemBase item)
        {
            return item.Equals(this);
        }
        #endregion
    }
}
