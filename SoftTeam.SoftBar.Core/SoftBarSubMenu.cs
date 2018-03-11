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
    public class SoftBarSubMenu : SoftBarBaseMenu
    {
        #region Fields
        private string _iconPath = "";
        private BarSubItem _subMenu = null;
        #endregion

        #region Constructor
        public SoftBarSubMenu(MainAppBarForm form, string name, bool systemMenu) : base (form,name,systemMenu)
        {
        }
        #endregion

        #region Properties
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
        public BarSubItem Setup()
        {
            _subMenu = new BarSubItem(Form.barManagerSoftBar, Name);

            ParentMenu = null;
            ParentSubMenu = _subMenu;

            return _subMenu;
        }

        public override void AddSubMenu(BarSubItem subMenu)
        {
            SubMenu.AddItem(subMenu);
        }

        #endregion
    }
}
