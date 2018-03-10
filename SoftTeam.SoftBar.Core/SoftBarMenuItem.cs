using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core
{
    public class SoftBarMenuItem : SoftBarBaseItem
    {
        #region Fields
        private readonly List<SoftBarMenuItem> _menuItems = new List<SoftBarMenuItem>();

        private string _iconPath = "";
        private int _width;
        private int _left;
        private bool _warning = false;
        private string _warningText = "";
        private BarItem _item = null;
        private PopupMenu _popupMenu = null;
        private CommandLine _commandLine = null;
        #endregion

        #region Constructor
        public SoftBarMenuItem(MainAppBarForm form, string name, bool beginGroup = false, bool systemMenu = false) : base(form,name,beginGroup,systemMenu)
        {
            _commandLine = new CommandLine();
        }
        #endregion

        #region Properties
        public string DocumentPath { get => _commandLine.Document; set => _commandLine.Document = value; }
        public string ApplicationPath { get => _commandLine.Application; set { _commandLine.Application = value; UpdateImage(); } }
        public string IconPath { get => _iconPath; set { _iconPath = value; UpdateImage(); } }
        public int Width { get => _width; set => _width = value; }
        public int Left { get => _left; set => _left = value; }

        public BarItem Item { get => _item; set => _item = value; }
        public PopupMenu PopupMenu { get => _popupMenu; set => _popupMenu = value; }

        public bool Warning { get => _warning; set => _warning = value; }
        public string WarningText { get => _warningText; set => _warningText = value; }
        #endregion

        private void UpdateImage()
        {
            // First check IconPath...
            var path = IconPath;
            // ...then check application path if IconPath is empty
            if (string.IsNullOrEmpty(path))
                path = ApplicationPath;

            // If we have a potential icon...
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    if (!File.Exists(path))
                    {
                        // Set warning message
                        Warning = true;
                        WarningText = "IconPath does not exist!";
                        // Return an error image
                        Image =  new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
                    }
                    else
                    {
                        // Extract the icon...
                        Image image = Icon.ExtractAssociatedIcon(path).ToBitmap();
                        // and return an 16x16 image
                        Image =  image.ResizeImage(16, 16);
                    }
                }
                catch (Exception ex)
                {
                    // Set warning message
                    Warning = true;
                    WarningText = $"Unknown icon exception! : \n\n{ex.Message}";

                    // Return an error image
                    Image =  new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
                }
            }
            else
                // Return no image
                Image =  null;

    }
    #region Create menu item
    public void Setup(PopupMenu popupMenu)
        {
            // Set the popup menu this item belongs to
            PopupMenu = popupMenu;
            // Create the BarButtonIem
            Item = new BarStaticItem();
            Item.Manager = Form.barManagerSoftBar;
            Item.Caption = Name;
            // Add the item
            _popupMenu.AddItem(Item);

            // Begin a new group (creates a line) if that property is set
            if (BeginGroup)
                Item.Links[0].BeginGroup = true;

            // Associate the BarButtonItem with the MenuItem, used when clicked
            Item.Tag = this;
            Item.ItemClick += Item_ItemClick;

            if (SystemMenu) return;

            try
            {
                // Set the image 
                Item.ImageOptions.Image = Image;
            }
            catch (Exception e)
            {
                // No icon on error
                WarningText = $"Unknown icon exception! : \n\n{e.Message}";
                Warning = true;
            }

            // If we have a warning...
            if (Warning)
            {
                // Create a tool tip and set the warning image
                Item.SuperTip = ToolTipHelper.CreateWarningToolTip(WarningText);
                Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
            }
        }
        #endregion

        #region Events
        private void Item_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Get the menu item that was clicked
            var menuItem = (SoftBarMenuItem)e.Item.Tag;

            if (_commandLine.CanExecute())
                _commandLine.Execute();                
        }
        #endregion
    }
}
