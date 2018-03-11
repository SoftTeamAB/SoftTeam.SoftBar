using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core
{
    public abstract class SoftBarBaseMenu : SoftBarBaseItem
    {
        private readonly List<SoftBarBaseItem> _menuItems = new List<SoftBarBaseItem>();
        private PopupMenu _parentMenu;
        private BarSubItem _parentSubMenu;

        public SoftBarBaseMenu(MainAppBarForm form, string name, bool systemMenu = false) : base(form, name, systemMenu)
        {
        }

        public List<SoftBarBaseItem> MenuItems => _menuItems;

        public PopupMenu ParentMenu { get => _parentMenu; set => _parentMenu = value; }
        public BarSubItem ParentSubMenu { get => _parentSubMenu; set => _parentSubMenu = value; }

        public abstract void AddSubMenu(BarSubItem subMenu);
    }
}
