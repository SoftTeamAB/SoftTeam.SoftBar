using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using SoftTeam.SoftBar.Core.Forms;

namespace SoftTeam.SoftBar.Core.SoftBar
{
    public abstract class SoftBarBaseMenu : SoftBarBaseItem
    {
        #region Fields
        private readonly List<SoftBarBaseItem> _menuItems = new List<SoftBarBaseItem>();
        private PopupMenu _parentMenu;
        private BarSubItem _parentSubMenu;
        private SoftBarBaseMenu _parentBaseMenu;
        private List<Control> _childCustomizationItems = null;

        #endregion

        #region Constructors
        public SoftBarBaseMenu(MainAppBarForm form, string name, bool systemMenu = false) : base(form, name, systemMenu)
        {
            _childCustomizationItems = new List<Control>();
        }
        #endregion

        #region Properties
        public List<SoftBarBaseItem> MenuItems => _menuItems;

        public PopupMenu ParentPopupMenu { get => _parentMenu; set => _parentMenu = value; }
        public BarSubItem ParentSubMenu { get => _parentSubMenu; set => _parentSubMenu = value; }
        public List<Control> ChildCustomizationItems { get => _childCustomizationItems; set => _childCustomizationItems = value; }
        public SoftBarBaseMenu ParentBaseMenu { get => _parentBaseMenu; set => _parentBaseMenu = value; }

        //public abstract void AddSubMenu(BarSubItem subMenu);
        #endregion
    }
}
