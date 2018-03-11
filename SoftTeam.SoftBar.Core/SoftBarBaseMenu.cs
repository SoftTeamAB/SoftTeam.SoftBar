using System.Collections.Generic;

using DevExpress.XtraBars;
using SoftTeam.SoftBar.Core.Forms;

namespace SoftTeam.SoftBar.Core
{
    public abstract class SoftBarBaseMenu : SoftBarBaseItem
    {
        #region Fields
        private readonly List<SoftBarBaseItem> _menuItems = new List<SoftBarBaseItem>();
        private PopupMenu _parentMenu;
        private BarSubItem _parentSubMenu;
        #endregion

        #region Constructors
        public SoftBarBaseMenu(MainAppBarForm form, string name, bool systemMenu = false) : base(form, name, systemMenu)
        {
        }
        #endregion

        #region Properties
        public List<SoftBarBaseItem> MenuItems => _menuItems;

        public PopupMenu ParentMenu { get => _parentMenu; set => _parentMenu = value; }
        public BarSubItem ParentSubMenu { get => _parentSubMenu; set => _parentSubMenu = value; }

        public abstract void AddSubMenu(BarSubItem subMenu);
        #endregion
    }
}
