using SoftTeam.SoftBar.Core.Controls;
using System;
using System.Drawing;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class CustomizationForm : DevExpress.XtraEditors.XtraForm
    {
        private string _path = "";
        private const int SPACE = 4;
        private const int LEFT_MARGIN = 3;
        private const int TOP_MARGIN = 2;
        private const int SCROLLBAR_WIDTH = 20;
        private const int  LEVEL_INDENTATION = 36;
        private const int  ITEM_HEIGHT = 36;
        private int height = TOP_MARGIN;
        private int level = 0;

        public CustomizationForm(SoftBarManager manager, string path)
        {
            InitializeComponent();

            _path = path;
            LoadMenu(manager);
        }

        private void CustomizationForm_Load(object sender, EventArgs e)
        {
            barStaticItemPath.Caption = _path;
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
            foreach (SoftBarBaseItem menuItem in menu.MenuItems)
            {
                if (menuItem.SystemMenu)
                    continue;

                AddItemControl(menuItem);
                //switch (menuItem.GetType().Name)
                //{
                    
                //    case "SoftBarHeaderItem":
                //        AddMenuHeaderControl((SoftBarHeaderItem)menuItem);
                //        break;
                //    case SoftBarMenuItem.MenuItemType.MenuItem:
                //        AddMenuItemControl(menuItem);
                //        break;
                //    case SoftBarMenuItem.MenuItemType.SystemMenuItem:
                //        // Do nothing
                //        break;
                //    case SoftBarMenuItem.MenuItemType.SubLevelMenu:
                //        // Not implemented
                //        throw new NotImplementedException();                        
                //}
            }
            level -= 1;
        }

        private void AddItemControl(SoftBarBaseItem menu)
        {
            MenuItem item = new MenuItem(menu,level);
            AddItem(item);
        }

        private void AddItem(MenuItem item)
        {
            // Temporary width, change when sub menues are implemented
            var width = xtraScrollableControlMenu.ClientSize.Width - LEVEL_INDENTATION- SCROLLBAR_WIDTH;

            item.Location = new Point(level * LEVEL_INDENTATION+LEFT_MARGIN, height);
            item.Size = new Size(width, ITEM_HEIGHT);
            xtraScrollableControlMenu.Controls.Add(item);
            height += item.Height + SPACE;
        }

        private void barStaticItemFileExitWithoutSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}