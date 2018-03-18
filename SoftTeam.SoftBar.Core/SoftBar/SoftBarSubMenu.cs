using DevExpress.XtraBars;
using SoftTeam.SoftBar.Core.Extensions;
using SoftTeam.SoftBar.Core.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core.SoftBar
{
    public class SoftBarSubMenu : SoftBarBaseMenu
    {
        #region Fields
        private BarSubItem _subMenu = null;
        #endregion

        #region Constructor
        public SoftBarSubMenu(MainAppBarForm form, string name, bool systemMenu) : base (form,name,systemMenu)
        {
        }
        #endregion

        #region Properties
        public BarSubItem Item { get => _subMenu; set => _subMenu = value; }
        #endregion

        #region Setup
        public BarSubItem Setup(SoftBarBaseMenu parentSubMenu)
        {
            // Store the parent
            ParentBaseMenu = parentSubMenu;

            _subMenu = new BarSubItem(Form.barManagerSoftBar, Name);
            _subMenu.Glyph = Image;
            return _subMenu;
        }

        //public override void AddSubMenu(BarSubItem subMenu)
        //{
        //    ParentSubMenu.AddItem(subMenu);
        //}

        #endregion
    }
}
