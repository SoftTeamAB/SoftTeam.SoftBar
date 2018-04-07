using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Controls;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Xml;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core.Forms
{
    public class CustomizationFormBuilder
    {
        private CustomizationForm CustomizationForm { get; }
        private XtraScrollableControl ScrollableControl { get; }
        private XmlArea Area { get; }
        private MenuItemControl VisibleMenuItemControl { get; set; }
        public ObservableCollection<MenuItemControl> MenuItemControls { get; }
        public XmlMenuItemBase SelectedXmlNode { get; set; }

        public event EventHandler MenuCustomized;

        private void onMenuCustomized()
        {
            MenuCustomized?.Invoke(this, new EventArgs());
        }

        public CustomizationFormBuilder(CustomizationForm form, XtraScrollableControl scrollableControl, XmlArea area)
        {
            CustomizationForm = form;
            ScrollableControl = scrollableControl;
            Area = area;

            MenuItemControls = new ObservableCollection<MenuItemControl>();
        }

        public void RefreshMenuItems()
        {
            ScrollableControl.Visible = false;

            // Remove all the old menu items
            ClearMenuItems();

            // Create the new menu item controls, recursively
            foreach (var menu in Area.Menus)
            {
                AddItemControl(MenuItemType.Menu, menu, 0);
                LoadMenu(menu, 1);
            }

            if (VisibleMenuItemControl != null)
            {
                // Clear old selected item
                ClearSelected();
                // Set the new item as selected
                VisibleMenuItemControl.Selected = MenuItemSelectedStatus.Selected;
                // Scroll it into view
                ScrollableControl.ScrollControlIntoView(VisibleMenuItemControl);
            }

            ScrollableControl.Visible = true;
        }

        private void LoadMenu(XmlMenuBase menu, int level)
        {
            foreach (XmlMenuItemBase menuItem in menu.MenuItems)
            {
                if (menuItem is XmlSubMenu)
                {
                    // Create the new sub menu and load its menu items recursively
                    AddItemControl(MenuItemType.SubMenu, menuItem, level);
                    LoadMenu((XmlMenuBase)menuItem, level + 1);
                }
                else if (menuItem is XmlHeaderItem)
                    AddItemControl(MenuItemType.HeaderItem, menuItem, level);
                else if (menuItem is XmlMenuItem)
                    AddItemControl(MenuItemType.MenuItem, menuItem, level);
            }
        }

        private void AddItemControl(MenuItemType type, XmlMenuItemBase menu, int level)
        {
            // Calculate color
            var step = 128 / Area.Depth();
            var color = Color.FromArgb(50, (level + 1) * step + 127, (level + 1) * step + 127, (level + 1) * step + 127);
            // Create new menu item control
            MenuItemControl item = new MenuItemControl(CustomizationForm, type, menu, level, color, MenuItemControls);
            // Location and size
            var width = ScrollableControl.ClientSize.Width - Area.Depth() * Constants.LEVEL_INDENTATION - Constants.SCROLLBAR_WIDTH;
            var top = Constants.TOP_MARGIN + ScrollableControl.Controls.Count * (item.Height + Constants.SPACE);
            item.Location = new Point(level * Constants.LEVEL_INDENTATION + Constants.LEFT_MARGIN, top);
            item.Size = new Size(width, Constants.ITEM_HEIGHT);
            // Add the item to the scrollable control
            ScrollableControl.Controls.Add(item);
            // Add events
            item.ClearSelectedRequested += Item_ClearSelectedRequested;
            item.ItemSelected += Item_ItemSelected;

            if (SelectedXmlNode != null && SelectedXmlNode.Equals(menu))
            {
                SelectedXmlNode = null;
                VisibleMenuItemControl = item;
            }

            MenuItemControls.Add(item);
        }

        public void RemoveItem(bool askConfirmation = true)
        {
            var selected = GetSelectedMenuItemControl();
            string message = "";
            if (selected == null)
            {
                message = "Please select the node that you want to remove, and hit <b>Remove item</b> item again!";
                XtraMessageBox.Show(message, "No node selected...", DevExpress.Utils.DefaultBoolean.True);
                return;
            }

            if (askConfirmation)
            {
                message = $"Are you sure you want to remove the node {selected.Name}?";
                DialogResult result = XtraMessageBox.Show(message, "Remove node...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, DevExpress.Utils.DefaultBoolean.True);
                if (result == DialogResult.No)
                    return;
            }

            var parent = Area.GetParent(selected);
            if (parent == null)
                Area.Menus.Remove((XmlMenu)selected);
            else
                parent.MenuItems.Remove(selected);

            selected = null;
            VisibleMenuItemControl = null;

            RefreshMenuItems();

            // Call MenuCustomized event
            onMenuCustomized();
        }

        public XmlMenuItemBase GetSelectedMenuItemControl()
        {
            foreach (var menuItem in MenuItemControls)
                if (menuItem.Selected == MenuItemSelectedStatus.Selected)
                    Console.WriteLine("Selected:" + menuItem.Item.Name);

            foreach (var menuItem in MenuItemControls)
                if (menuItem.Selected == MenuItemSelectedStatus.Selected)
                    return menuItem.Item;

            return null;
        }

        public void ClearMenuItems()
        {
            foreach (Control control in ScrollableControl.Controls)
                control.Dispose();

            ScrollableControl.Controls.Clear();
        }

        public void ClearSelected()
        {
            foreach (MenuItemControl menuItemControl in MenuItemControls)
                menuItemControl.Selected = MenuItemSelectedStatus.NotSelected;
        }

        #region Event handlers
        private void Item_ItemSelected(object sender, EventArgs e)
        {
            if (sender == null)
                VisibleMenuItemControl = null;
            else
                VisibleMenuItemControl = (MenuItemControl)sender;
        }

        private void Item_ClearSelectedRequested(object sender, EventArgs e)
        {
            VisibleMenuItemControl = null;
            ClearSelected();
        }
        #endregion
    }
}
