using DevExpress.XtraBars;

using SoftTeam.SoftBar.Core.Forms;

namespace SoftTeam.SoftBar.Core
{
    public class SoftBarHeaderItem : SoftBarBaseItem
    {
        #region Fields
        private BarHeaderItem _item = null;
        #endregion

        #region Constructor
        public SoftBarHeaderItem(MainAppBarForm form, string name, bool systemMenu = false) : base(form,name,systemMenu)
        {
        }
        #endregion

        #region Properties
        public BarHeaderItem Item { get => _item; set => _item = value; }
        #endregion
        
        #region Setup
        public BarHeaderItem Setup()
        {
            // Create the new BarHeaderItem
            Item = new BarHeaderItem();
            // Set the caption
            Item.Caption = Name;
            return Item;
        }
        #endregion
    }
}
