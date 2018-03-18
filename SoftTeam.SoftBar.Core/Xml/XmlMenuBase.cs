using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core.Xml
{
    public class XmlMenuBase : XmlMenuItemBase
    {
        protected List<XmlMenuItemBase> _menuItems = null;

        public XmlMenuBase()
        {
            _menuItems = new List<XmlMenuItemBase>();
        }

        public List<XmlMenuItemBase> MenuItems { get => _menuItems; set => _menuItems = value; }
    }
}
