using System;
using System.Drawing;

namespace SoftTeam.SoftBar.Core
{
    public partial class CustomizationForm : DevExpress.XtraEditors.XtraForm
    {
        private const int SPACE = 4;
        private const int SCROLLBAR_WIDTH = 20;
        private const int  LEVEL_INDENTATION = 36;
        private const int  ITEM_HEIGHT = 36;
        private int height = 0;
        private int level = 0;
        public CustomizationForm(SoftBarManager manager)
        {
            InitializeComponent();

            LoadMenu(manager);
        }

        private void CustomizationForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadMenu(SoftBarManager manager)
        {

            foreach (var menu in manager.Menus)
            {
                LoadMenu(menu);
            }
        }
        private void LoadMenu(SoftBarMenu menu)
        {
            AddItemControl(menu);
            level += 1;
            foreach (var menuItem in menu.MenuItems)
            {
                switch (menuItem.Type)
                {
                    case SoftBarMenuItem.MenuItemType.Header:
                        AddMenuHeaderControl(menuItem);
                        break;
                    case SoftBarMenuItem.MenuItemType.MenuItem:
                        AddMenuItemControl(menuItem);
                        break;
                    case SoftBarMenuItem.MenuItemType.SystemMenuItem:
                        // Do nothing
                        break;
                    case SoftBarMenuItem.MenuItemType.SubLevelMenu:
                        // Not implemented
                        throw new NotImplementedException();                        
                }
            }
            level -= 1;
        }

        private void AddItemControl(SoftBarMenu menu)
        {
            MenuItem item = new MenuItem(menu,level);
            AddItem(item);
        }

        private void AddMenuHeaderControl(SoftBarMenuItem menuItem)
        {
            MenuItem item = new MenuItem(menuItem, level, true);
            AddItem(item);
        }

        private void AddMenuItemControl(SoftBarMenuItem menuItem)
        {
            MenuItem item = new MenuItem(menuItem, level);
            AddItem(item);
        }

        private void AddItem(MenuItem item)
        {
            // Temporary width, change when sub menues are implemented
            var width = xtraScrollableControlMenu.ClientSize.Width - LEVEL_INDENTATION- SCROLLBAR_WIDTH;

            item.Location = new Point(level * LEVEL_INDENTATION, height);
            item.Size = new Size(width, ITEM_HEIGHT);
            xtraScrollableControlMenu.Controls.Add(item);
            height += item.Height + SPACE;
        }
    }
}