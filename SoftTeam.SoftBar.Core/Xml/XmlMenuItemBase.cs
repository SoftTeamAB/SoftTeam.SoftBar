
namespace SoftTeam.SoftBar.Core.Xml
{
    // Base class for menu items, header items and sub menus
    public class XmlMenuItemBase
    {
        protected string _name = string.Empty;

        public XmlMenuItemBase()
        {
        }

        public string Name { get => _name; set => _name = value; }
    }
}
