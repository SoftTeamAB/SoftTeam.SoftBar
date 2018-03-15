using SoftTeam.SoftBar.Core.Controls;
using SoftTeam.SoftBar.Core.Misc;
using System;
using System.Drawing;
using System.Collections.ObjectModel;
using SoftTeam.SoftBar.Core.Helpers;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class CustomizationForm : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        private string _path = "";
        private string _backupDirectory = @"C:\ProgramData\SoftTeam\SoftBar";
        private int _height = Constants.TOP_MARGIN;
        private int _level = 0;
        private int _maxLevel = 0;
        private SoftBarManager _manager = null;
        private MenuItemControl _previousMenuItem = null;
        private ObservableCollection<MenuItemControl> _menuItems = new ObservableCollection<MenuItemControl>();
        #endregion

        #region Constructors
        public CustomizationForm(SoftBarManager manager, string path)
        {
            InitializeComponent();

            _path = path;
            RefreshMenuItems(manager);
            _manager = manager;
            barStaticItemPath.Caption = _path;
        }
        #endregion

        #region Calculate max level
        private int CalculateMaxLevel(SoftBarManager manager)
        {
            int maxLevel = 0;

            foreach (var menu in manager.Menus)
                CalculateMaxLevelEx(menu, ref maxLevel);

            return maxLevel;
        }

        private void CalculateMaxLevelEx(SoftBarBaseMenu menu, ref int maxLevel)
        {
            _level += 1;
            if (_level > maxLevel)
                maxLevel = _level;

            foreach (SoftBarBaseItem menuItem in menu.MenuItems)
                if (menuItem is SoftBarSubMenu)
                    CalculateMaxLevelEx((SoftBarBaseMenu)menuItem, ref maxLevel);

            _level -= 1;
        }
        #endregion

        #region Load menu for customization
        private void RefreshMenuItems(SoftBarManager manager)
        {
            ClearMenuItems();

            _maxLevel = CalculateMaxLevel(manager);

            foreach (var menu in manager.Menus)
            {
                AddItemControl(MenuItemType.Menu, menu);
                LoadMenu(menu);
            }
        }

        private void LoadMenu(SoftBarBaseMenu menu)
        {
            _level += 1;

            foreach (SoftBarBaseItem menuItem in menu.MenuItems)
            {
                if (menuItem.SystemMenu)
                    continue;

                if (menuItem is SoftBarSubMenu)
                {
                    AddItemControl(MenuItemType.SubMenu, menuItem);
                    LoadMenu((SoftBarBaseMenu)menuItem);
                }
                else if (menuItem is SoftBarHeaderItem)
                    AddItemControl(MenuItemType.HeaderItem, menuItem);
                else if (menuItem is SoftBarMenuItem)
                    AddItemControl(MenuItemType.MenuItem, menuItem);
            }
            _level -= 1;
        }

        private void ClearMenuItems()
        {
            _height = 0;
            xtraScrollableControlMenu.Controls.Clear();
        }

        private void AddItemControl(MenuItemType type, SoftBarBaseItem menu)
        {
            var step = 128 / _maxLevel;
            var color = Color.FromArgb(50, _level * step, _level * step, _level * step);
            MenuItemControl item = new MenuItemControl(this, type, menu, _level, color, _menuItems, _previousMenuItem);
            var width = xtraScrollableControlMenu.ClientSize.Width - _maxLevel * Constants.LEVEL_INDENTATION - Constants.SCROLLBAR_WIDTH;

            item.Location = new Point(_level * Constants.LEVEL_INDENTATION + Constants.LEFT_MARGIN, _height);
            item.Size = new Size(width, Constants.ITEM_HEIGHT);
            xtraScrollableControlMenu.Controls.Add(item);
            _height += item.Height + Constants.SPACE;
            menu.CustomizationMenuItem = item;
            item.ClearSelectedRequested += Item_ClearSelectedRequested;

            _previousMenuItem = item;
            _menuItems.Add(item);
        }
        #endregion

        #region Clear selected menu item
        private void Item_ClearSelectedRequested(object sender, EventArgs e)
        {
            foreach (var menuItem in _manager.Menus)
            {
                menuItem.CustomizationMenuItem.Selected = MenuItemSelectedStatus.NotSelected;
                SetSelected(menuItem, MenuItemSelectedStatus.NotSelected);
            }
        }

        private void SetSelected(SoftBarBaseMenu menu, MenuItemSelectedStatus selected)
        {
            foreach (var menuItem in menu.MenuItems)
            {
                menuItem.CustomizationMenuItem.Selected = selected;
                if (menuItem is SoftBarSubMenu)
                    SetSelected((SoftBarSubMenu)menuItem, selected);
            }
        }
        #endregion

        #region Event handlers (bar & menu)
        private void barStaticItemFileExitWithoutSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barStaticItemExitAndSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void barButtonItemAddMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddMenu();
        }

        private void barButtonItemAddMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddSubMenu();
        }

        private void barButtonItemAddHeaderItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddHeaderItem();
        }

        private void barButtonItemAddSubMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddMenuItem();
        }

        private void barStaticItemAddMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddMenu();
        }

        private void barStaticItemAddSubMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddSubMenu();
        }

        private void barStaticItemHeaderItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddHeaderItem();
        }

        private void barStaticItemMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddMenuItem();
        }
        #endregion

        private void AddMenu()
        {
            var selected = GetSelectedItem();

            var menuItem = CreateMenu();

            if (menuItem == null) return;

            if (selected == null)
                _manager.Menus.Insert(0, (SoftBarMenu)menuItem);
            else
                _manager.Menus.Insert(_manager.Menus.IndexOf((SoftBarMenu)selected)+1, (SoftBarMenu)menuItem);

            RefreshMenuItems(_manager);
        }

        private SoftBarBaseItem CreateMenu()
        {
            SoftBarMenu menu = new SoftBarMenu(_manager.Form, "[New item]", 0);

            using (CustomizationMenuItemForm form = new CustomizationMenuItemForm(menu))
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel)
                    return null;
            }

            return menu;
        }

        private void AddSubMenu()
        {
            throw new NotImplementedException();
        }
        private void AddHeaderItem()
        {
            throw new NotImplementedException();
        }
        private void AddMenuItem()
        {
            throw new NotImplementedException();
        }

        private void Save()
        {
            // Save

            this.Close();
        }

        private SoftBarBaseItem GetSelectedItem()
        {
            foreach (var menuItem in _menuItems)
                if (menuItem.Selected == MenuItemSelectedStatus.Selected)
                    return menuItem.Item;

            return null;
        }

        #region Bottom bar
        private void barStaticItemPath_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenSoftBarXml();
        }

        private void barStaticItemPathHeader_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenSoftBarXml();
        }

        private void barStaticItemBackupPathHeader_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenBackupDirectory();
        }

        private void barStaticItemBackupPath_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenBackupDirectory();
        }

        private void OpenSoftBarXml()
        {
            CommandLineHelper.ExecuteCommandLine($"Notepad.exe {_path}");
        }

        private void OpenBackupDirectory()
        {
            CommandLineHelper.ExecuteCommandLine($"Explorer.exe {_backupDirectory}");
        }
        #endregion
    }
}