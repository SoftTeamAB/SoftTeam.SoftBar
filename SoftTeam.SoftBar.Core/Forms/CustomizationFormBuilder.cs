using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Xml;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core.Forms
{
    public class CustomizationFormBuilder
    {
        private XtraScrollableControl ScrollableControl { get; }
        private XmlArea Area { get; }
        private int Height { get; set; } = Constants.TOP_MARGIN;

        public CustomizationFormBuilder(XtraScrollableControl scrollableControl, XmlArea area)
        {
            ScrollableControl = scrollableControl;
            Area = area;
        }

        //public void RefreshMenuItems()
        //{
        //    ScrollableControl.Visible = false;

        //    // Remove all the old menu items
        //    ClearMenuItems();

        //    // Height is no zero
        //    Height = 0;

        //    // Create the new menu item controls, recursively
        //    foreach (var menu in Area.Menus)
        //    {
        //        AddItemControl(MenuItemType.Menu, menu);
        //        LoadMenu(menu);
        //    }

        //    if (_makeVisible != null)
        //    {
        //        // Clear old selected item
        //        ClearSelected();
        //        // Set the new item as selected
        //        _makeVisible.Selected = MenuItemSelectedStatus.Selected;
        //        // Scroll it into view
        //        ScrollableControl.ScrollControlIntoView(_makeVisible);
        //    }

        //    ScrollableControl.Visible = true;
        //}

        //private void LoadMenu(XmlMenuBase menu)
        //{
        //    _level += 1;

        //    foreach (XmlMenuItemBase menuItem in menu.MenuItems)
        //    {
        //        if (menuItem is XmlSubMenu)
        //        {
        //            // Create the new sub menu and load its menu items recursively
        //            AddItemControl(MenuItemType.SubMenu, menuItem);
        //            LoadMenu((XmlMenuBase)menuItem);
        //        }
        //        else if (menuItem is XmlHeaderItem)
        //            AddItemControl(MenuItemType.HeaderItem, menuItem);
        //        else if (menuItem is XmlMenuItem)
        //            AddItemControl(MenuItemType.MenuItem, menuItem);
        //    }
        //    _level -= 1;
        //}

        //private void AddItemControl(MenuItemType type, XmlMenuItemBase menu)
        //{
        //    var step = 128 / _maxLevel;
        //    var color = Color.FromArgb(50, _level * step + 127, _level * step + 127, _level * step + 127);
        //    MenuItemControl item = new MenuItemControl(this, type, menu, _level, color, _menuItems);
        //    var width = xtraScrollableControlMenu.ClientSize.Width - _maxLevel * Constants.LEVEL_INDENTATION - Constants.SCROLLBAR_WIDTH;

        //    item.Location = new Point(_level * Constants.LEVEL_INDENTATION + Constants.LEFT_MARGIN, _height);
        //    item.Size = new Size(width, Constants.ITEM_HEIGHT);
        //    xtraScrollableControlMenu.Controls.Add(item);
        //    item.ClearSelectedRequested += Item_ClearSelectedRequested;
        //    item.ItemSelected += Item_ItemSelected;
        //    _height += item.Height + Constants.SPACE;

        //    if (_selectedNode != null && _selectedNode.Equals(menu))
        //    {
        //        _selectedNode = null;
        //        _makeVisible = item;
        //    }

        //    _menuItems.Add(item);
        //}

        //public void ClearMenuItems()
        //{
        //    foreach (Control control in ScrollableControl.Controls)
        //        control.Dispose();

        //    ScrollableControl.Controls.Clear();
        //}
    }
}
