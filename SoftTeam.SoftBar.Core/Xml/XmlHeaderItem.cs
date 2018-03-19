using System.Xml;

namespace SoftTeam.SoftBar.Core.Xml
{
    /// <summary>
    /// Class for a header item (Xml)
    /// </summary>
    public class XmlHeaderItem : XmlMenuItemBase
    {
        #region Fields
        private bool _beginGroup = false;
        #endregion

        #region Constructor
        public XmlHeaderItem()
        {
        }
        #endregion

        #region Properties
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }
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
    }
}
