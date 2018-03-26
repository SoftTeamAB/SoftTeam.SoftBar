using SoftTeam.SoftBar.Core.Controls;
using SoftTeam.SoftBar.Core.Misc;
using System;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using SoftTeam.SoftBar.Core.Xml;
using SoftTeam.SoftBar.Core.SoftBar;
using DevExpress.XtraEditors;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class CustomizationForm : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        private int _height = Constants.TOP_MARGIN;
        private int _level = 0;
        private int _maxLevel = 0;
        private XmlArea _area = null;
        private ObservableCollection<MenuItemControl> _menuItems = new ObservableCollection<MenuItemControl>();
        private SoftBarManager _manager = null;
        private MenuItemControl _makeVisible = null;
        private XmlMenuItemBase _selectedNode = null;
        private bool _after = true;
        private bool _inside = false;
        private CustomizationInfoForm _infoForm = null;
        #endregion

        #region Constructors
        public CustomizationForm(SoftBarManager manager)
        {
            InitializeComponent();

            _manager = manager;
            _area = _manager.UserAreaXml;

            barButtonItemPath.Caption = manager.FileManager.MenuPath;
            barButtonItemBackupPath.Caption = manager.FileManager.SoftBarDirectoryBackup;

            var darkerColor = HelperFunctions.ChangeColorBrightness(this.BackColor, -0.2f);
            panelControlScroll.BackColor = darkerColor;

            RefreshMenuItems();
        }
        #endregion

        #region Calculate max level
        private int CalculateDepth()
        {
            int maxLevel = 0;

            foreach (var menu in _area.Menus)
                CalculateMaxLevelEx(menu, ref maxLevel);

            return maxLevel;
        }

        private void CalculateMaxLevelEx(XmlMenuBase menu, ref int maxLevel)
        {
            _level += 1;
            if (_level > maxLevel)
                maxLevel = _level;

            foreach (XmlMenuItemBase menuItem in menu.MenuItems)
                if (menuItem is XmlSubMenu)
                    CalculateMaxLevelEx((XmlMenuBase)menuItem, ref maxLevel);

            _level -= 1;
        }
        #endregion

        #region Load menu for customization
        private void RefreshMenuItems()
        {
            // Remove all the old menu items
            ClearMenuItems();

            // Calculate the new depth of the tree
            _maxLevel = CalculateDepth();

            // Create the new menu item controls, recursively
            foreach (var menu in _area.Menus)
            {
                AddItemControl(MenuItemType.Menu, menu);
                LoadMenu(menu);
            }

            if (_makeVisible != null)
            {
                // Clear old selected item
                ClearSelected();
                // Set the new item as selected
                _makeVisible.Selected = MenuItemSelectedStatus.Selected;
                // Scroll it into view
                xtraScrollableControlMenu.ScrollControlIntoView(_makeVisible);
            }
        }

        private void LoadMenu(XmlMenuBase menu)
        {
            _level += 1;

            foreach (XmlMenuItemBase menuItem in menu.MenuItems)
            {
                if (menuItem is XmlSubMenu)
                {
                    // Create the new sub menu and load its menu items recursively
                    AddItemControl(MenuItemType.SubMenu, menuItem);
                    LoadMenu((XmlMenuBase)menuItem);
                }
                else if (menuItem is XmlHeaderItem)
                    AddItemControl(MenuItemType.HeaderItem, menuItem);
                else if (menuItem is XmlMenuItem)
                    AddItemControl(MenuItemType.MenuItem, menuItem);
            }
            _level -= 1;
        }

        private void ClearMenuItems()
        {
            _height = 0;
            xtraScrollableControlMenu.Controls.Clear();
        }

        private void AddItemControl(MenuItemType type, XmlMenuItemBase menu)
        {
            var step = 128 / _maxLevel;
            var color = Color.FromArgb(50, _level * step + 127, _level * step + 127, _level * step + 127);
            MenuItemControl item = new MenuItemControl(this, type, menu, _level, color, _menuItems);
            var width = xtraScrollableControlMenu.ClientSize.Width - _maxLevel * Constants.LEVEL_INDENTATION - Constants.SCROLLBAR_WIDTH;

            item.Location = new Point(_level * Constants.LEVEL_INDENTATION + Constants.LEFT_MARGIN, _height);
            item.Size = new Size(width, Constants.ITEM_HEIGHT);
            xtraScrollableControlMenu.Controls.Add(item);
            item.ClearSelectedRequested += Item_ClearSelectedRequested;
            item.ItemSelected += Item_ItemSelected;
            _height += item.Height + Constants.SPACE;

            if (_selectedNode != null && _selectedNode.Equals(menu))
            {
                _selectedNode = null;
                _makeVisible = item;
            }

            _menuItems.Add(item);
        }

        private void Item_ItemSelected(object sender, EventArgs e)
        {
            if (sender == null)
                _makeVisible = null;
            else
                _makeVisible = (MenuItemControl)sender;
        }

        private void Item_ClearSelectedRequested(object sender, EventArgs e)
        {
            _makeVisible = null;
            ClearSelected();
        }

        private void ClearSelected()
        {
            foreach (var item in _menuItems)
                item.Selected = MenuItemSelectedStatus.NotSelected;
        }
        #endregion

        #region Event handlers (bar & menu)
        private void barButtonItemAddMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddMenu();
        }

        private void barButtonItemAddMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddMenuItem();
        }

        private void barButtonItemAddHeaderItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddHeaderItem();
        }

        private void barButtonItemAddSubMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddSubMenu();
        }

        private void barButtonItemMenuAddMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddMenu();
        }

        private void barButtonItemMenuAddSubMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddSubMenu();
        }

        private void barButtonItemMenuAddHeaderItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddHeaderItem();
        }

        private void barButtonItemMenuAddMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddMenuItem();
        }
        #endregion

        #region Add menu items
        private void AddMenu()
        {
            var selected = GetSelectedItem();

            CaptureControlKeys(selected);
            var menu = CreateMenu();
            if (menu == null) return;

            if (selected == null && _area.Menus.Count > 0)
            {
                XtraMessageBox.Show("Please select the menu you want create a new menu AFTER. Hold down shift to create the menu before the selected menu.");
                return;
            }
            else
            {
                // Create the new menu before or after the selected nodes parent menu
                var parentMenu = _area.GetParentMenu(selected);
                if (!_after)
                    _area.Menus.Insert(_area.Menus.IndexOf(parentMenu), (XmlMenu)menu);
                else
                    _area.Menus.Insert(_area.Menus.IndexOf(parentMenu) + 1, (XmlMenu)menu);
            }

            _selectedNode = menu;

            RefreshMenuItems();
        }

        private void AddSubMenu()
        {
            var selected = GetSelectedItem();

            if (selected == null)
            {
                var message = "A node must be selected to indicate where the new sub menu should be created!\n\nSelect a menu node, or sub menu node, to create a sub menu in the first position in that menu.\n\nSelect a menu item node or a header item node to create the new sub menu node after the selected item node.";
                XtraMessageBox.Show(message, "No node selected...");
                return;
            }

            CaptureControlKeys(selected);
            var subMenu = CreateSubMenu();
            if (subMenu == null) return;

            if (selected is XmlMenu || (selected is XmlSubMenu && _inside))
            {
                // Create the new menu item at position 0 in the menu 
                var menu = selected as XmlMenuBase;
                menu.MenuItems.Insert(0, subMenu);
            }
            else
            {
                // Create the new menu item before or after the selected nodes 
                var parent = (XmlMenuBase)_area.GetParent(selected);
                if (!_after)
                    parent.MenuItems.Insert(parent.MenuItems.IndexOf(selected), subMenu);
                else
                    parent.MenuItems.Insert(parent.MenuItems.IndexOf(selected) + 1, subMenu);
            }

            _selectedNode = subMenu;

            RefreshMenuItems();
        }

        private void AddHeaderItem()
        {
            var selected = GetSelectedItem();

            if (selected == null)
            {
                var message = "A node must be selected to indicate where the new header item should be created!\n\nSelect a menu node, or sub menu node, to create a header item in the first position in that menu.\n\nSelect a menu item node or a header item node to create the new header item node after the selected item node.";
                XtraMessageBox.Show(message);
                return;
            }

            CaptureControlKeys(selected);
            var headerItem = CreateHeaderItem();
            if (headerItem == null) return;

            if (selected is XmlMenu || (selected is XmlSubMenu && _inside))
            {
                // Create the new menu item at position 0 in the menu or sub menu
                var menu = selected as XmlMenuBase;
                menu.MenuItems.Insert(0, headerItem);
            }
            else
            {
                // Create the new menu item before or after the selected nodes 
                var parent = (XmlMenuBase)_area.GetParent(selected);
                if (!_after)
                    parent.MenuItems.Insert(parent.MenuItems.IndexOf(selected), headerItem);
                else
                    parent.MenuItems.Insert(parent.MenuItems.IndexOf(selected) + 1, headerItem);
            }

            _selectedNode = headerItem;

            RefreshMenuItems();
        }

        private void AddMenuItem()
        {
            var selected = GetSelectedItem();

            if (selected == null)
            {
                var message = "A node must be selected to indicate where the new menu item node should be created!\n\nSelect a menu node, or sub menu node, to create a menu item in the first position in that menu.\n\nSelect a menu item node or a header item node to create the new menu item node after the selected item node.";
                XtraMessageBox.Show(message);
                return;
            }

            CaptureControlKeys(selected);
            var menuItem = CreateMenuItem();
            if (menuItem == null) return;

            if (selected is XmlMenu || (selected is XmlSubMenu && _inside))
            {
                // Create the new menu item at position 0 in the menu or sub menu
                var menu = selected as XmlMenuBase;
                menu.MenuItems.Insert(0, menuItem);
            }
            else
            {
                // Create the new menu item after the selected nodes 
                var parent = (XmlMenuBase)_area.GetParent(selected);
                if (!_after)
                    parent.MenuItems.Insert(parent.MenuItems.IndexOf(selected), menuItem);
                else
                    parent.MenuItems.Insert(parent.MenuItems.IndexOf(selected) + 1, menuItem);
            }

            _selectedNode = menuItem;

            RefreshMenuItems();
        }
        #endregion

        #region CreateMenuItems
        private XmlMenuItemBase CreateMenu()
        {
            XmlMenu menu = new XmlMenu();
            menu.Width = 100;
            using (CustomizationMenuItemForm form = new CustomizationMenuItemForm(menu))
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel)
                    return null;
            }

            return menu;
        }

        private XmlMenuItemBase CreateSubMenu()
        {
            XmlSubMenu subMenu = new XmlSubMenu();

            using (CustomizationMenuItemForm form = new CustomizationMenuItemForm(subMenu))
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel)
                    return null;
            }

            return subMenu;
        }

        private XmlMenuItemBase CreateHeaderItem()
        {
            XmlHeaderItem headerItem = new XmlHeaderItem();

            using (CustomizationMenuItemForm form = new CustomizationMenuItemForm(headerItem))
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel)
                    return null;
            }

            return headerItem;
        }

        private XmlMenuItemBase CreateMenuItem()
        {
            XmlMenuItem menuItem = new XmlMenuItem();

            using (CustomizationMenuItemForm form = new CustomizationMenuItemForm(menuItem))
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel)
                    return null;
            }

            return menuItem;
        }
        #endregion

        #region GetSelectedItem
        private XmlMenuItemBase GetSelectedItem()
        {
            foreach (var menuItem in _menuItems)
                if (menuItem.Selected == MenuItemSelectedStatus.Selected)
                    return menuItem.Item;

            return null;
        }
        #endregion

        #region Bottom bar
        private void barButtonItemPath_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenSoftBarXml();
        }

        private void barButtonItemPathHeader_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenSoftBarXml();
        }

        private void barButtonItemBackupPathHeader_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenBackupDirectory();
        }

        private void barButtonItemBackupPath_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenBackupDirectory();
        }

        private void OpenSoftBarXml()
        {
            CommandLineHelper.ExecuteCommandLine($"Notepad.exe {_manager.FileManager.MenuPath}");
        }

        private void OpenBackupDirectory()
        {
            CommandLineHelper.ExecuteCommandLine($"Explorer.exe {_manager.FileManager.SoftBarDirectoryBackup}");
        }
        #endregion

        #region Save & Cancel
        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void barButtonItemExitAndSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void barButtonItemFileExitWithoutSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cancel();
        }

        private void Save()
        {
            // Save

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Remove item
        private void barButtonItemRemoveItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RemoveItem();
        }

        private void barButtonItemMenuRemoveItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RemoveItem();
        }
        private void RemoveItem()
        {
            var selected = GetSelectedItem();
            string message = "";
            if (selected == null)
            {
                message = "Please select the node that you want to remove, and hit <b>Remove item</b> item again!";
                XtraMessageBox.Show(message, "No node selected...", DevExpress.Utils.DefaultBoolean.True);
                return;
            }

            message = $"Are you sure you want to remove the node {selected.Name}?";
            DialogResult result = XtraMessageBox.Show(message, "Remove node...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, DevExpress.Utils.DefaultBoolean.True);
            if (result == DialogResult.No)
                return;

            var parent = _area.GetParent(selected);
            if (parent == null)
                _area.Menus.Remove((XmlMenu)selected);
            else
                parent.MenuItems.Remove(selected);

            selected = null;
            _makeVisible = null;

            RefreshMenuItems();
        }
        #endregion

        private void xtraScrollableControlMenu_Click(object sender, EventArgs e)
        {
            ClearSelected();
        }

        private void CaptureControlKeys(XmlMenuItemBase selected)
        {
            // Default values
            _inside = false;
            _after = true;

            // If we are inside a sub menu...
            if (selected is XmlSubMenu)
            {
                // ...and the CTRL key is pressed, create item inside the menu.
                if (Control.ModifierKeys == Keys.Control)
                    _inside = true;
                else if (Control.ModifierKeys == Keys.Shift)
                    _after = false;
            }
            else
            {
                // If shift key is pressed, create item before the selected item
                if (Control.ModifierKeys == Keys.Shift)
                    _after = false;
            }
        }

        private void pictureBoxPlacementInfo_MouseEnter(object sender, EventArgs e)
        {
            _infoForm = new CustomizationInfoForm();
            _infoForm.Show();

            var left = this.Left + pictureBoxPlacementInfo.Left - _infoForm.Width;
            var top = this.Top + pictureBoxPlacementInfo.Top + pictureBoxPlacementInfo.Height;

            _infoForm.Location = new Point(left, top);
        }

        private void pictureBoxPlacementInfo_MouseLeave(object sender, EventArgs e)
        {
            _infoForm.Close();
            _infoForm.Dispose();
            _infoForm = null;
        }
    }
}