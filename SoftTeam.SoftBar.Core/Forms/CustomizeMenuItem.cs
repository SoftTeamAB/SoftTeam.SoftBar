using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class CustomizeMenuItem : DevExpress.XtraEditors.XtraForm
    {
        private MenuItemType _type = MenuItemType.None;

        private SoftBarMenu _menu = null;
        private SoftBarHeaderItem _headerItem = null;

        public CustomizeMenuItem(SoftBarMenu menu)
        {
            InitializeComponent();

            _type = MenuItemType.Menu;
            editMenu.BringToFront();

            editMenu.Name = menu.Name;
            editMenu.IconPath = menu.IconPath;
            editMenu.BeginGroup = menu.BeginGroup;
            _menu = menu;

            editMenu.LoadValues();
        }

        public CustomizeMenuItem(SoftBarHeaderItem headerItem)
        {
            InitializeComponent();

            _type = MenuItemType.HeaderItem;
            editHeaderItem.BringToFront();

            editHeaderItem.Name = headerItem.Name;
            editHeaderItem.BeginGroup = headerItem.BeginGroup;
            _headerItem = headerItem;

            editHeaderItem.LoadValues();
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
            }

            this.Close();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}