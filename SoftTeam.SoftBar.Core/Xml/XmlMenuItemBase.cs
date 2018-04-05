
using System;

namespace SoftTeam.SoftBar.Core.Xml
{
    // Base class for menu items, header items and sub menus
    public abstract class XmlMenuItemBase
    {
        #region Fields
        protected string _name = string.Empty;
        protected bool _beginGroup = false;
        protected string _iconPath = string.Empty;
        protected int _iconNumber = 0;
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
        public int IconNumber { get => _iconNumber; set => _iconNumber = value; }
        #endregion

        public int Depth(XmlMenuItemBase root, int depth)
        {
            int result = depth + 1;

            if (root is XmlMenu || root is XmlSubMenu)
                foreach (var node in ((XmlMenuBase)root).MenuItems)
                    result = Math.Max(result, Depth(node, depth + 1));

            return result;
        }

        #region Abstract functions
        public abstract int CountItems();
        public abstract bool ContainsItem(XmlMenuItemBase item);
        #endregion
    }
}
