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
    public class SoftBarMenuItem
    {
        #region Enums
        public enum MenuItemType
        {
            NotSet = 0,
            SystemMenuItem = 1,
            SubLevelMenu = 2,
            MenuItem = 3,
            Header = 4
        }
        #endregion

        #region Fields
        private readonly List<SoftBarMenuItem> _menuItems = new List<SoftBarMenuItem>();

        private MainAppBarForm _form = null;
        private MenuItemType _type = MenuItemType.NotSet;
        private string _name = "";
        private readonly bool _isFolder = false;
        private bool _beginGroup = false;
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
        public SoftBarMenuItem(MainAppBarForm form, MenuItemType type, string name, bool beginGroup = false, bool isFolder = false)
        {
            _form = form;
            _isFolder = isFolder;
            _type = type;
            _beginGroup = beginGroup;
            _name = name;
            _commandLine = new CommandLine();
        }
        #endregion

        #region Properties
        public MenuItemType Type { get => _type; set => _type = value; }
        public string Name { get => _name; set => _name = value; }
        public string DocumentPath { get => _commandLine.Document; set => _commandLine.Document = value; }
        public string ApplicationPath { get => _commandLine.Application; set => _commandLine.Application = value; }
        public string IconPath { get => _iconPath; set => _iconPath = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }
        public bool IsFolder => _isFolder;
        public List<SoftBarMenuItem> Menus => _menuItems;
        public int Width { get => _width; set => _width = value; }
        public int Left { get => _left; set => _left = value; }

        public BarItem Item { get => _item; set => _item = value; }
        public PopupMenu PopupMenu { get => _popupMenu; set => _popupMenu = value; }

        public Image Image
        {
            get
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
                            return new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
                        }
                        else
                        {
                            // Extract the icon...
                            Image image = Icon.ExtractAssociatedIcon(path).ToBitmap();
                            // and return an 16x16 image
                            return image.ResizeImage(16, 16);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Set warning message
                        Warning = true;
                        WarningText = $"Unknown icon exception! : \n\n{ex.Message}";

                        // Return an error image
                        return new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
                    }
                }
                else
                    // Return no image
                    return null;
            }
        }

        public bool Warning { get => _warning; set => _warning = value; }
        public string WarningText { get => _warningText; set => _warningText = value; }
        #endregion

        #region Create menu item
        public void Setup(PopupMenu popupMenu)
        {
            // Is it a Header, MenuItem, or SystemMenuItem?
            switch (Type)
            {
                case MenuItemType.Header:
                    CreateHeaderItem(popupMenu);
                    break;
                case MenuItemType.MenuItem:
                    CreateMenuItem(popupMenu);
                    break;
                case MenuItemType.SystemMenuItem:
                    CreateSystemMenuItem(popupMenu);
                    break;
            }
        }

        private void CreateHeaderItem(PopupMenu popupMenu)
        {
            // Store the popup menu this item belongs to
            PopupMenu = popupMenu;
            // Create the new BarHeaderItem
            Item = new BarHeaderItem();
            // Set the caption
            Item.Caption = _name;
            // And add it
            _popupMenu.AddItem(Item);
        }

        public void CreateMenuItem(PopupMenu popupMenu)
        {
            // Sote the popup menu this item belongs to
            PopupMenu = popupMenu;
            // Create the BarButtonIem
            Item = new BarStaticItem();
            Item.Manager = _form.barManagerSoftBar;
            Item.Caption = _name;
            // Add the item
            _popupMenu.AddItem(Item);

            // Begin a new group (creates a line) if that property is set
            if (_beginGroup)
                Item.Links[0].BeginGroup = true;

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

            // Associate the BarButtonItem with the MenuItem, used when clicked
            Item.Tag = this;
            Item.ItemClick += Item_ItemClick;

            // If we have a warning...
            if (Warning)
            {
                // Create a tool tip and set the warning image
                Item.SuperTip = ToolTipHelper.CreateWarningToolTip(WarningText);
                Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
            }
        }

        private void CreateSystemMenuItem(PopupMenu popupMenu)
        {
            // Store the popup menu this item belong to
            PopupMenu = popupMenu;
            // Create the BarStaticItem for this item
            Item = new BarStaticItem();
            Item.Manager = _form.barManagerSoftBar;
            Item.Caption = _name;

            // Associate the BarButtonItem with the MenuItem, used when clicked
            // Click event is created by system menu creator
            Item.Tag = this;

            // Add the item
            _popupMenu.AddItem(Item);

            // Begin a new group (creates a line) if that property is set
            if (_beginGroup)
                Item.Links[0].BeginGroup = true;
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
