using System;

using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Xml;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class CustomizationMenuItemForm : DevExpress.XtraEditors.XtraForm
    {
        private MenuItemType _type = MenuItemType.None;

        private XmlMenu _menu = null;
        private XmlHeaderItem _headerItem = null;
        private XmlSubMenu _subMenu = null;
        private XmlMenuItem _menuItem = null;

        public CustomizationMenuItemForm(XmlMenu menu)
        {
            InitializeComponent();

            _type = MenuItemType.Menu;
            editMenu.BringToFront();

            editMenu.Name = menu.Name;
            editMenu.IconPath = menu.IconPath;
            editMenu.BeginGroup = menu.BeginGroup;
            editMenu.MenuWidth = menu.Width;

            _menu = menu;

            editMenu.LoadValues();
        }

        public CustomizationMenuItemForm(XmlHeaderItem headerItem)
        {
            InitializeComponent();

            _type = MenuItemType.HeaderItem;
            editHeaderItem.BringToFront();

            editHeaderItem.Name = headerItem.Name;
            editHeaderItem.BeginGroup = headerItem.BeginGroup;
            _headerItem = headerItem;

            editHeaderItem.LoadValues();
        }

        public CustomizationMenuItemForm(XmlSubMenu subMenu)
        {
            InitializeComponent();

            _type = MenuItemType.SubMenu;
            editSubMenu.BringToFront();

            editSubMenu.Name = subMenu.Name;
            editSubMenu.IconPath = subMenu.IconPath;
            editSubMenu.BeginGroup = subMenu.BeginGroup;
            _subMenu = subMenu;

            editSubMenu.LoadValues();
        }

        public CustomizationMenuItemForm(XmlMenuItem menuItem)
        {
            InitializeComponent();

            _type = MenuItemType.MenuItem;
            editMenuItem.BringToFront();

            editMenuItem.Name = menuItem.Name;
            editMenuItem.IconPath = menuItem.IconPath;
            editMenuItem.BeginGroup = menuItem.BeginGroup;
            editMenuItem.RunAsAdministrator = menuItem.RunAsAdministrator;

            editMenuItem.ApplicationPath = menuItem.ApplicationPath;
            editMenuItem.DocumentPath = menuItem.DocumentPath;
            editMenuItem.Parameters = menuItem.Parameters;
            _menuItem = menuItem;

            editMenuItem.LoadValues();
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case MenuItemType.Menu:
                    editMenu.SaveValues();

                    _menu.Name = editMenu.Name;
                    _menu.IconPath = editMenu.IconPath;
                    _menu.BeginGroup = editMenu.BeginGroup;
                    break;
                case MenuItemType.HeaderItem:
                    editHeaderItem.SaveValues();

                    _headerItem.Name = editHeaderItem.Name;
                    _headerItem.BeginGroup = editHeaderItem.BeginGroup;
                    break;
                case MenuItemType.SubMenu:
                    editSubMenu.SaveValues();

                    _subMenu.Name = editSubMenu.Name;
                    _subMenu.IconPath = editSubMenu.IconPath;
                    _subMenu.BeginGroup = editSubMenu.BeginGroup;
                    break;
                case MenuItemType.MenuItem:
                    editMenuItem.SaveValues();

                    _menuItem.Name = editMenuItem.Name;
                    _menuItem.IconPath = editMenuItem.IconPath;
                    _menuItem.BeginGroup = editMenuItem.BeginGroup;
                    _menuItem.RunAsAdministrator = editMenuItem.RunAsAdministrator;

                    _menuItem.ApplicationPath = editMenuItem.ApplicationPath;
                    _menuItem.DocumentPath = editMenuItem.DocumentPath;
                    _menuItem.Parameters = editMenuItem.Parameters;
                    break;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}