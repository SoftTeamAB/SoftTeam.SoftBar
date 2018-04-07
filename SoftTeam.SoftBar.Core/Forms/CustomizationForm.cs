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
        private XmlArea _area = null;
        private SoftBarManager _manager = null;
        private CustomizationInfoForm _infoForm = null;
        private XmlMenuItemBase _copiedNode = null;
        private CustomizationFormBuilder _builder = null;
        #endregion

        #region Constructors
        public CustomizationForm(SoftBarManager manager)
        {
            InitializeComponent();

            _manager = manager;
            _area = _manager.UserAreaXml;
            _builder = new CustomizationFormBuilder(this, xtraScrollableControlMenu, _area);
            _builder.MenuCustomized += _builder_MenuCustomized;
            barButtonItemPath.Caption = manager.FileManager.MenuPath;
            barButtonItemBackupPath.Caption = manager.FileManager.SoftBarDirectoryBackup;

            var darkerColor = HelperFunctions.ChangeColorBrightness(this.BackColor, -0.2f);
            panelControlScroll.BackColor = darkerColor;

            _builder.RefreshMenuItems();

            EnableDisableMenus();
        }

        private void _builder_MenuCustomized(object sender, EventArgs e)
        {
            EnableDisableMenus();
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
                _builder.SelectedXmlNode = firstMenu;
                _builder.RefreshMenuItems();
                EnableDisableMenus();
                return;
            }

            var selected = _builder.GetSelectedMenuItemControl();

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

            _builder.SelectedXmlNode = menu;

            _builder.RefreshMenuItems();
            EnableDisableMenus();
        }

        private void AddSubMenu()
        {
            var selected = _builder.GetSelectedMenuItemControl();

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

            _builder.SelectedXmlNode = subMenu;

            _builder.RefreshMenuItems();
            EnableDisableMenus();
        }

        private void AddHeaderItem()
        {
            var selected = _builder.GetSelectedMenuItemControl();

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

            _builder.SelectedXmlNode = newItem;

            _builder.RefreshMenuItems();
            EnableDisableMenus();
        }

        private void AddMenuItem()
        {
            var selected = _builder.GetSelectedMenuItemControl();

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

            _builder.SelectedXmlNode = newItem;

            _builder.RefreshMenuItems();
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
            _builder.RemoveItem();
        }

        private void barButtonItemMenuRemoveItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _builder.RemoveItem();
        }
        #endregion

        #region Random events
        private void xtraScrollableControlMenu_Click(object sender, EventArgs e)
        {
            _builder.ClearSelected();
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
                _builder.RemoveItem();
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
            var selected = _builder.GetSelectedMenuItemControl();

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
            var selected = _builder.GetSelectedMenuItemControl();

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
            _builder.RemoveItem(false);
            _builder.ClearSelected();
        }

        private void Paste()
        {
            var selected = _builder.GetSelectedMenuItemControl();

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
            var selected = _builder.GetSelectedMenuItemControl();
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

            _builder.SelectedXmlNode = selected;
        }

        /// <summary>
        /// Moves an item down
        /// </summary>
        private void MoveDown()
        {
            var selected = _builder.GetSelectedMenuItemControl();
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

            _builder.SelectedXmlNode = selected;
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
            foreach (var control in _builder.MenuItemControls)
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
            foreach (var item in _builder.MenuItemControls)
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