using DevExpress.XtraBars;
using SoftTeam.SoftBar.Core.Forms;

namespace SoftTeam.SoftBar.Core.SoftBar
{
    public class SoftBarStaticItem : SoftBarBaseItem
    {
        #region Fields
        private int _width;
        private int _left;
        private BarStaticItem _item = null;
        #endregion

        #region Constructor
        // Used for system items
        public SoftBarStaticItem(MainAppBarForm form, string name, bool systemMenu = true) : base(form, name, systemMenu)
        {
        }
        #endregion

        #region Properties
        public int Width { get => _width; set => _width = value; }
        public int Left { get => _left; set => _left = value; }

        public BarStaticItem Item { get => _item; set => _item = value; }
        #endregion

        #region Setup
        public BarStaticItem Setup()
        {
            // Create the BarStaticIem
            Item = new BarStaticItem();
            Item.Manager = Form.barManagerSoftBar;
            Item.Caption = Name;

            return Item;
        }
        #endregion
    }
}
