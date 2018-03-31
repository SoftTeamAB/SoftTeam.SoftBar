using System.Collections.Generic;

namespace SoftTeam.SoftBar.Core.Xml
{
    /// <summary>
    /// Base class for all sub menus and menus
    /// </summary>
    public abstract class XmlMenuBase : XmlMenuItemBase
    {
        #region Fields
        protected List<XmlMenuItemBase> _menuItems = null;
        #endregion

        #region Constructor
        public XmlMenuBase()
        {
            _menuItems = new List<XmlMenuItemBase>();
        }
        #endregion

        #region Properties
        public List<XmlMenuItemBase> MenuItems { get => _menuItems; set => _menuItems = value; }
        #endregion

        public XmlMenuBase GetParent(XmlMenuItemBase childItem)
        {
            if (childItem == null)
                return null;

            foreach (var item in _menuItems)
            {
                if (item == childItem)
                    return this;

                if (item is XmlSubMenu)
                {
                    var subMenu = item as XmlSubMenu;
                    var parent = subMenu.GetParent(childItem);
                    if (parent != null) return (XmlMenuBase)parent;
                }
            }

            return null;
        }
    }
}
