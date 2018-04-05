using SoftTeam.SoftBar.Core.Controls;
using SoftTeam.SoftBar.Core.Misc;
using System;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using SoftTeam.SoftBar.Core.Xml;
using SoftTeam.SoftBar.Core.SoftBar;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

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
        private CustomizationInfoForm _infoForm = null;
        private XmlMenuItemBase _copiedNode = null;
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

            EnableDisableMenus();
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
            xtraScrollableControlMenu.Visible = false;

            // Remove all the old menu items
            ClearMenuItems();

            // Height is now zero
            _height = 0;

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

            xtraScrollableControlMenu.Visible = true;
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
            foreach (Control control in xtraScrollableControlMenu.Controls)
                control.Dispose();

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

        private void barButtonItemMoveUp_ItemClick(object sender, ItemClickEventArgs e)
        {
            MoveUp();
        }

        private void barButtonItemMoveDown_ItemClick(object sender, ItemClickEventArgs e)
        {
            MoveDown();
        }

        #endregion

        #region Add menu items
        private void AddMenu()
        {
            // First time users
            if (_area.Menus.Count == 0)
            {
                var firstMenu = CreateMenu();
                if (firstMenu == null) return;
                _area.Menus.Add((XmlMenu)firstMenu);
                _selectedNode = firstMenu;
                RefreshMenuItems();
                EnableDisableMenus();
                return;
            }

            var selected = GetSelectedItem();

            if (selected == null)
            {
                var message = "A node must be selected to indicate where the new menu should be created. Please select a node and click <b>Add menu</b> again.";
                XtraMessageBox.Show(message, "No node selected...");
                return;
            }

            // Create the new menu before or after the selected nodes parent menu
            var parentMenu = _area.GetParentMenu(selected);

            // Never allow menus inside menus
            var position = GetPosition(parentMenu, false);
            if (position == ItemPosition.None) return;

            var menu = CreateMenu();
            if (menu == null) return;

            if (position == ItemPosition.Before)
                _area.Menus.Insert(_area.Menus.IndexOf(parentMenu), (XmlMenu)menu);
            else
                _area.Menus.Insert(_area.Menus.IndexOf(parentMenu) + 1, (XmlMenu)menu);

            _selectedNode = menu;

            RefreshMenuItems();
            EnableDisableMenus();
        }

        private void AddSubMenu()
        {
            var selected = GetSelectedItem();

            if (selected == null)
            {
                var message = "A node must be selected to indicate where the new sub menu node should be created!";
                XtraMessageBox.Show(message, "No node selected...");
                return;
            }

            ItemPosition position = ItemPosition.None;
            if (selected is XmlMenu)
                position = ItemPosition.Inside;
            else
            {
                position = GetPosition(selected, selected is XmlSubMenu);
                if (position == ItemPosition.None) return;
            }

            var subMenu = CreateSubMenu();
            if (subMenu == null) return;

            if (position == ItemPosition.Inside)
            {
                // Create the new menu item at position 0 in the menu 
                var menu = selected as XmlMenuBase;
                menu.MenuItems.Insert(0, subMenu);
            }
            else
            {
                // Create the new menu item before or after the selected nodes 
                var parent = (XmlMenuBase)_area.GetParent(selected);
                if (position == ItemPosition.Before)
                    parent.MenuItems.Insert(parent.MenuItems.IndexOf(selected), subMenu);
                else
                    parent.MenuItems.Insert(parent.MenuItems.IndexOf(selected) + 1, subMenu);
            }

            _selectedNode = subMenu;

            RefreshMenuItems();
            EnableDisableMenus();
        }

        private void AddHeaderItem()
        {
            var selected = GetSelectedItem();

            if (selected == null)
            {
                var message = "A node must be selected to indicate where the new header item node should be created!";
                XtraMessageBox.Show(message);
                return;
            }

            ItemPosition position = ItemPosition.None;
            if (selected is XmlMenu)
                position = ItemPosition.Inside;
            else
            {
                position = GetPosition(selected, selected is XmlSubMenu);
                if (position == ItemPosition.None) return;
            }

            var headerItem = CreateHeaderItem();
            if (headerItem == null) return;

            AddHeaderItem(headerItem, selected, position);
        }

        private void AddHeaderItem(XmlMenuItemBase newItem, XmlMenuItemBase selected, ItemPosition position)
        {
            if (position == ItemPosition.Inside)
            {
                // Create the new menu item at position 0 in the menu or sub menu
                var menu = selected as XmlMenuBase;
                menu.MenuItems.Insert(0, newItem);
            }
            else
            {
                // Create the new menu item before or after the selected nodes 
                var parent = (XmlMenuBase)_area.GetParent(selected);
                if (position == ItemPosition.Before)
                    parent.MenuItems.Insert(parent.MenuItems.IndexOf(selected), newItem);
                else
                    parent.MenuItems.Insert(parent.MenuItems.IndexOf(selected) + 1, newItem);
            }

            _selectedNode = newItem;

            RefreshMenuItems();
            EnableDisableMenus();
        }

        private void AddMenuItem()
        {
            var selected = GetSelectedItem();

            if (selected == null)
            {
                var message = "A node must be selected to indicate where the new menu item node should be created!";
                XtraMessageBox.Show(message);
                return;
            }

            ItemPosition position = ItemPosition.None;
            if (selected is XmlMenu)
                position = ItemPosition.Inside;
            else
            {
                position = GetPosition(selected, selected is XmlSubMenu);
                if (position == ItemPosition.None) return;
            }

            var menuItem = CreateMenuItem();
            if (menuItem == null) return;

            AddMenuItem(menuItem, selected, position);
        }

        private void AddMenuItem(XmlMenuItemBase newItem, XmlMenuItemBase selected, ItemPosition position)
        {
            if (position == ItemPosition.Inside)
            {
                // Create the new menu item at position 0 in the menu or sub menu
                var menu = selected as XmlMenuBase;
                menu.MenuItems.Insert(0, newItem);
            }
            else
            {
                // Create the new menu item after the selected nodes 
                var parent = (XmlMenuBase)_area.GetParent(selected);
                if (position == ItemPosition.Before)
                    parent.MenuItems.Insert(parent.MenuItems.IndexOf(selected), newItem);
                else
                    parent.MenuItems.Insert(parent.MenuItems.IndexOf(selected) + 1, newItem);
            }

            _selectedNode = newItem;

            RefreshMenuItems();
            EnableDisableMenus();
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

        #region Misc functions
        private void EnableDisableMenus()
        {
            barButtonItemAddHeaderItem.Enabled = (_area.Menus.Count > 0);
            barButtonItemAddMenuItem.Enabled = (_area.Menus.Count > 0);
            barButtonItemAddSubMenu.Enabled = (_area.Menus.Count > 0);

            barButtonItemMenuAddMenuItem.Enabled = (_area.Menus.Count > 0);
            barButtonItemMenuHeaderItem.Enabled = (_area.Menus.Count > 0);
            barButtonItemMenuAddSubMenu.Enabled = (_area.Menus.Count > 0);

            barButtonItemMoveUp.Enabled = (_area.Menus.Count > 0);
            barButtonItemMoveDown.Enabled = (_area.Menus.Count > 0);
            barButtonItemMenuMoveUp.Enabled = (_area.Menus.Count > 0);
            barButtonItemMenuMoveDown.Enabled = (_area.Menus.Count > 0);

            barButtonItemMenuRemoveItem.Enabled = (_area.Menus.Count > 0);
            barButtonItemRemoveItem.Enabled = (_area.Menus.Count > 0);
        }

        private XmlMenuItemBase GetSelectedItem()
        {
            foreach (var menuItem in _menuItems)
                if (menuItem.Selected == MenuItemSelectedStatus.Selected)
                    return menuItem.Item;

            return null;
        }

        private ItemPosition GetPosition(XmlMenuItemBase selected, bool insideAvailable = false)
        {
            using (PositionForm form = new PositionForm(selected, insideAvailable))
            {
                form.ShowDialog();
                return form.Position;
            }
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

        private void Save()
        {
            // Save

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel()
        {
            DialogResult result = XtraMessageBox.Show("All changes will be lost! Are you sure?", "Cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CustomizationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void RemoveItem(bool askConfirmation = true)
        {
            var selected = GetSelectedItem();
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

            var parent = _area.GetParent(selected);
            if (parent == null)
                _area.Menus.Remove((XmlMenu)selected);
            else
                parent.MenuItems.Remove(selected);

            selected = null;
            _makeVisible = null;

            RefreshMenuItems();
            EnableDisableMenus();
        }
        #endregion

        #region Random events
        private void xtraScrollableControlMenu_Click(object sender, EventArgs e)
        {
            ClearSelected();
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

        private void toolTipControllerCustomization_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.Info != null && e.Info.Object is BarStaticItemLink)
            {
                var item = e.Info.Object as BarStaticItemLink;
                if (item.Item.Name == "barButtonItemBackupPath")
                    e.Info.SuperTip = HelperFunctions.CreateInformationToolTip("Click to open folder...\n" + barButtonItemBackupPath.Caption);
                else
                    e.Info.SuperTip = HelperFunctions.CreateInformationToolTip("Click to open file...\n" + barButtonItemPath.Caption);
            }
        }
        #endregion

        #region Keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                MoveUp();
                return true;
            }
            else if (keyData == Keys.Down)
            {
                MoveDown();
                return true;
            }
            else if (keyData == Keys.Right)
            {
                MoveIn();
                return true;
            }
            else if (keyData == Keys.Left)
            {
                MoveOut();
                return true;
            }
            else if (keyData == Keys.Delete)
            {
                RemoveItem();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.C))
            {
                Copy();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.X))
            {
                Cut();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.V))
            {
                Paste();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Cut, Copy and Paste
        private void Copy()
        {
            var selected = GetSelectedItem();

            if (selected == null)
            {
                var message = "A node must be selected to indicate which item should be copied!";
                XtraMessageBox.Show(message);
                return;
            }
            else if (selected is XmlMenu || selected is XmlSubMenu)
            {
                var message = "Copying of menus and sub menus is currently not supported!";
                XtraMessageBox.Show(message);
                return;
            }

            _copiedNode = selected.Copy();
        }

        private void Cut()
        {
            var selected = GetSelectedItem();

            if (selected == null)
            {
                var message = "A node must be selected to indicate which item should be copied!";
                XtraMessageBox.Show(message);
                return;
            }
            else if (selected is XmlMenu || selected is XmlSubMenu)
            {
                var message = "Copying of menus and sub menus is currently not supported!";
                XtraMessageBox.Show(message);
                return;
            }

            _copiedNode = selected.Copy();
            RemoveItem(false);
            ClearSelected();
        }

        private void Paste()
        {
            var selected = GetSelectedItem();

            if (selected == null)
            {
                var message = "A node must be selected to indicate where to place the copied node!";
                XtraMessageBox.Show(message);
                return;
            }
            else if (_copiedNode == null)
            {
                var message = "A node must be copied first!";
                XtraMessageBox.Show(message);
                return;
            }

            ItemPosition position = ItemPosition.None;
            if (selected is XmlMenu)
                position = ItemPosition.Inside;
            else
            {
                position = GetPosition(selected, selected is XmlSubMenu);
                if (position == ItemPosition.None) return;
            }

            if (_copiedNode is XmlHeaderItem)
                AddHeaderItem(_copiedNode, selected, position);
            else if (_copiedNode is XmlMenuItem)
                AddMenuItem(_copiedNode, selected, position);
        }
        #endregion

        #region Move items
        /// <summary>
        /// Moves an item up
        /// </summary>
        private void MoveUp()
        {
            var selected = GetSelectedItem();
            if (selected == null) return;

            if (selected is XmlMenu)
            {
                // We are on the first level, check if we can move up
                var index = _area.Menus.IndexOf((XmlMenu)selected);
                if (index == 0) return;
                // Get the item above us
                var above = _area.Menus[index - 1];
                // Switch places in the GUI
                SwitchPlaces(GetMenuItemControl(above), GetMenuItemControl(selected));
                // Switch places in the data structure behind the scene
                _area.Menus.Remove((XmlMenu)selected);
                _area.Menus.Insert(index - 1, (XmlMenu)selected);
            }
            else
            {
                // We are inside a menu/sub menu, check if we can move up
                var parent = _area.GetParent(selected);
                var index = parent.MenuItems.IndexOf(selected);
                if (index == 0) return;
                // Get the item above us
                var above = parent.MenuItems[index - 1];
                // Switch places in the GUI
                SwitchPlaces(GetMenuItemControl(above), GetMenuItemControl(selected));
                // Switch places in the data structure behind the scene
                parent.MenuItems.Remove(selected);
                parent.MenuItems.Insert(index - 1, selected);
            }

            _selectedNode = selected;
        }

        /// <summary>
        /// Moves an item down
        /// </summary>
        private void MoveDown()
        {
            var selected = GetSelectedItem();
            if (selected == null) return;

            if (selected is XmlMenu)
            {
                // We are on the first level, check if we can move down
                var index = _area.Menus.IndexOf((XmlMenu)selected);
                if (index == _area.Menus.Count - 1) return;
                // Get the item below us
                var below = _area.Menus[index + 1];
                // Switch places in the GUI
                SwitchPlaces(GetMenuItemControl(selected), GetMenuItemControl(below));
                // Switch places in the data structure behind the scene
                _area.Menus.Remove((XmlMenu)selected);
                _area.Menus.Insert(index + 1, (XmlMenu)selected);
            }
            else
            {
                // We are inside a menu/sub menu, check if we can move down
                var parent = _area.GetParent(selected);
                var index = parent.MenuItems.IndexOf(selected);
                if (index == parent.MenuItems.Count - 1) return;
                // Get the item below us
                var below = parent.MenuItems[index + 1];
                // Switch places in the GUI
                SwitchPlaces(GetMenuItemControl(selected), GetMenuItemControl(below));
                // Switch places in the data structure behind the scene
                parent.MenuItems.Remove(selected);
                parent.MenuItems.Insert(index + 1, selected);
            }

            _selectedNode = selected;
        }

        /// <summary>
        /// Moves an item into a sub menu
        /// </summary>
        private void MoveIn()
        {
        }

        /// <summary>
        /// Moves an item out of a sub menu
        /// </summary>
        private void MoveOut()
        {
        }

        // Get the MenuItemControl for a menu item node
        private MenuItemControl GetMenuItemControl(XmlMenuItemBase item)
        {
            foreach (var control in _menuItems)
            {
                if (control.Item.Equals(item))
                    return control;
            }

            // Should not happen!
            return null;
        }

        // Switch places between two MenuItemControls in the GUI
        private void SwitchPlaces(MenuItemControl item1, MenuItemControl item2)
        {
            // Calculate how much we need to move the items
            // and all the sub nodes of the items
            var item2Delta = -item1.ItemHeight;
            var item1Delta = item2.ItemHeight;

            // Move the items
            foreach (var item in _menuItems)
            {
                if (item1.Item.ContainsItem(item.Item))
                    item.Location = new Point(item.Location.X, item.Location.Y + item1Delta);

                if (item2.Item.ContainsItem(item.Item))
                    item.Location = new Point(item.Location.X, item.Location.Y + item2Delta);
            }
        }
        #endregion
    }
}