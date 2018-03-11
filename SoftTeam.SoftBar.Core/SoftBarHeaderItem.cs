using System;
using System.Drawing;
using System.IO;

using DevExpress.XtraBars;

using SoftTeam.SoftBar.Core.Extensions;
using SoftTeam.SoftBar.Core.Forms;

namespace SoftTeam.SoftBar.Core
{
    public class SoftBarHeaderItem : SoftBarBaseItem
    {
        #region Fields
        private string _iconPath = "";
        private bool _warning = false;
        private string _warningText = "";
        private BarHeaderItem _item = null;
        private PopupMenu _popupMenu = null;
        #endregion

        #region Constructor
        public SoftBarHeaderItem(MainAppBarForm form, string name, bool systemMenu = false) : base(form,name,systemMenu)
        {
        }
        #endregion

        #region Properties
        public string IconPath { get => _iconPath; set { _iconPath = value; UpdateImage(); } }

        public BarHeaderItem Item { get => _item; set => _item = value; }
        public PopupMenu PopupMenu { get => _popupMenu; set => _popupMenu = value; }

        public bool Warning { get => _warning; set => _warning = value; }
        public string WarningText { get => _warningText; set => _warningText = value; }
        #endregion

        #region Misc functions
        private void UpdateImage()
        {
            // If we have a potential icon...
            if (!string.IsNullOrEmpty(IconPath))
            {
                try
                {
                    if (!File.Exists(IconPath))
                    {
                        // Set warning message
                        Warning = true;
                        WarningText = "IconPath does not exist!";
                        // Return an error image
                        Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
                    }
                    else
                    {
                        // Extract the icon...
                        Image image = Icon.ExtractAssociatedIcon(IconPath).ToBitmap();
                        // and return an 16x16 image
                        Image = Image.ResizeImage(16, 16);
                    }
                }
                catch (Exception ex)
                {
                    // Set warning message
                    Warning = true;
                    WarningText = $"Unknown icon exception! : \n\n{ex.Message}";

                    // Return an error image
                    Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
                }
            }
            else
                // Return no image
                Image = null;
        }
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
