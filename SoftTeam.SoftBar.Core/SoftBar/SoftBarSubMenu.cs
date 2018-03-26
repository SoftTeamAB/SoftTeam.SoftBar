using DevExpress.XtraBars;
using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Xml;

namespace SoftTeam.SoftBar.Core.SoftBar
{
    public class SoftBarSubMenu : SoftBarBaseMenu
    {
        #region Fields
        private BarSubItem _subMenu = null;
        #endregion

        #region Constructor
        public SoftBarSubMenu(MainAppBarForm form, XmlSubMenu subMenu, bool systemMenu = false) : base (form,subMenu.Name,systemMenu)
        {
            IconPath = subMenu.IconPath;
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
