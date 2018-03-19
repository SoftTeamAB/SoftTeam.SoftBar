using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core.Xml
{
    /// <summary>
    /// Base class for all sub menus and menus
    /// </summary>
    public class XmlMenuBase : XmlMenuItemBase
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
    }
}
