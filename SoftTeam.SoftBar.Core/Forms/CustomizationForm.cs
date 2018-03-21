using SoftTeam.SoftBar.Core.Controls;
using SoftTeam.SoftBar.Core.Misc;
using System;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using SoftTeam.SoftBar.Core.Xml;
using SoftTeam.SoftBar.Core.SoftBar;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class CustomizationForm : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        private string _backupDirectory = @"C:\ProgramData\SoftTeam\SoftBar";
        private int _height = Constants.TOP_MARGIN;
        private int _level = 0;
        private int _maxLevel = 0;
        private XmlArea _area = null;
        private ObservableCollection<MenuItemControl> _menuItems = new ObservableCollection<MenuItemControl>();
        private SoftBarManager _manager = null;
        #endregion

        #region Constructors
        public CustomizationForm(SoftBarManager manager)
        {
            InitializeComponent();

            _manager = manager;
            _area = _manager.UserAreaXml;

            barStaticItemPath.Caption = manager.Path;
            barStaticItemBackupPath.Caption = _backupDirectory;

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
            ClearMenuItems();

            _maxLevel = CalculateDepth();

            foreach (var menu in _area.Menus)
            {
                AddItemControl(MenuItemType.Menu, menu);
                LoadMenu(menu);
            }
        }

        private void LoadMenu(XmlMenuBase menu)
        {
            _level += 1;

            foreach (XmlMenuItemBase menuItem in menu.MenuItems)
            {
                if (menuItem is XmlSubMenu)
                {
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
            var color = Color.FromArgb(50, _level * step, _level * step, _level * step);
            MenuItemControl item = new MenuItemControl(this, type, menu, _level, color, _menuItems);
            var width = xtraScrollableControlMenu.ClientSize.Width - _maxLevel * Constants.LEVEL_INDENTATION - Constants.SCROLLBAR_WIDTH;

            item.Location = new Point(_level * Constants.LEVEL_INDENTATION + Constants.LEFT_MARGIN, _height);
            item.Size = new Size(width, Constants.ITEM_HEIGHT);
            xtraScrollableControlMenu.Controls.Add(item);
            _height += item.Height + Constants.SPACE;

            _menuItems.Add(item);
        }
        #endregion

        #region Event handlers (bar & menu)
        private void barStaticItemFileExitWithoutSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void barStaticItemExitAndSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
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
                _area.Menus.Insert(0, (XmlMenu)menuItem);
            else
                _area.Menus.Insert(_area.Menus.IndexOf((XmlMenu)selected)+1, (XmlMenu)menuItem);

            RefreshMenuItems();
        }

        private XmlMenuItemBase CreateMenu()
        {
            XmlMenu menu = new XmlMenu();

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
        }

        private XmlMenuItemBase GetSelectedItem()
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
            CommandLineHelper.ExecuteCommandLine($"Notepad.exe {_manager.Path}");
        }

        private void OpenBackupDirectory()
        {
            CommandLineHelper.ExecuteCommandLine($"Explorer.exe {_backupDirectory}");
        }
        #endregion
    }
}