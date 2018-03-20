
namespace SoftTeam.SoftBar.Core.Xml
{
    // Base class for menu items, header items and sub menus
    public class XmlMenuItemBase
    {
        #region Fields
        protected string _name = string.Empty;
        protected bool _beginGroup = false;
        #endregion

        #region Constructor
        public XmlMenuItemBase()
        {
        }
        #endregion

        #region Properties
        public string Name { get => _name; set => _name = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }
        #endregion
    }
}
