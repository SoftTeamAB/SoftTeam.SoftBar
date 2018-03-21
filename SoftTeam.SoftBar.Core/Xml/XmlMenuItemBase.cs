
namespace SoftTeam.SoftBar.Core.Xml
{
    // Base class for menu items, header items and sub menus
    public class XmlMenuItemBase
    {
        #region Fields
        protected string _name = string.Empty;
        protected bool _beginGroup = false;
        protected string _iconPath = string.Empty;
        #endregion

        #region Constructor
        public XmlMenuItemBase()
        {
        }
        #endregion

        #region Properties
        public string Name { get => _name; set => _name = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }
        public string IconPath { get => _iconPath; set => _iconPath = value; }
        #endregion
    }
}
