using DevExpress.XtraBars;
using SoftTeam.SoftBar.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core
{
    public class SoftBarSubMenu : SoftBarBaseItem
    {
        #region Fields
        private readonly List<SoftBarMenuItem> _menuItems = new List<SoftBarMenuItem>();

        private string _iconPath = "";
        private BarSubItem _subMenu = null;
        private PopupMenu _popupMenu = null;
        #endregion

        #region Constructor
        public SoftBarSubMenu(MainAppBarForm form, string name, bool beginGroup, bool systemMenu) : base (form,name,beginGroup,systemMenu)
        {
        }
        #endregion

        #region Properties
        public List<SoftBarMenuItem> MenuItems => _menuItems;
        public string IconPath { get => _iconPath; set { _iconPath = value; UpdateImage(); } }

        public BarSubItem SubMenu { get => _subMenu; set => _subMenu = value; }

        #endregion

        private void UpdateImage()
        {
            if (!string.IsNullOrEmpty(IconPath))
            {
                Image image = Icon.ExtractAssociatedIcon(IconPath).ToBitmap();
                Image = Image.ResizeImage(16, 16);
            }
            else
                Image = null;
        }
        #region CreateMenu
        public void Setup(PopupMenu popupMenu)
        {
            _popupMenu = popupMenu;

            _subMenu = new BarSubItem(Form.barManagerSoftBar, Name);

            _popupMenu.AddItem(_subMenu);
        }
        #endregion
    }
}
