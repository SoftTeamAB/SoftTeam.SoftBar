using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Core.Controls
{
    public partial class MenuItem : DevExpress.XtraEditors.XtraUserControl
    {
        private int _level = 0;
        private SoftBarBaseItem _item = null;
        private MenuItemType _type = MenuItemType.None;
        private bool _selected = false;
        private Color _color;
        public bool Selected { get => _selected; set { _selected = value; UpdateColor(); } }

        public class MenuItemClickedEventArgs
        {
            public SoftBarBaseMenu Menu { get; set; }
            public bool Selected { get; set; }
            public MenuItemClickedEventArgs(SoftBarBaseMenu menu, bool selected)
            {
                Menu = menu;
                Selected = selected;
            }
        }
        public delegate void MenuItemClickedEventHandler(object sender, MenuItemClickedEventArgs e);
        public event MenuItemClickedEventHandler MenuItemClicked;
        public event EventHandler ClearSelectedRequested;

        private void onMenuItemClicked(bool selected)
        {
            MenuItemClicked?.Invoke(this, new MenuItemClickedEventArgs((SoftBarBaseMenu)_item, selected));
        }

        private void onClearSelectedRequested()
        {
            ClearSelectedRequested?.Invoke(this, new EventArgs());
        }

        public MenuItem(MenuItemType type, SoftBarBaseItem item, int level, Color color)
        {
            _type = type;
            _level = level;
            _item = item;
            InitializeComponent();
            UpdateValues();
            this.BackColor = color;
            _color = color;
        }

        private void UpdateValues()
        {
            labelControlType.Text = HelperFunctions.GetTypeName(_type);
            pictureBoxIcon.BackColor = HelperFunctions.GetTypeColor(_type);
            labelControlName.Text = _item.Name;
            pictureBoxIcon.Image = _item.Image;
            if (_item.BeginGroup)
                pictureBoxBeginGroup.BringToFront();
            else
                pictureBoxNoBeginGroup.BringToFront();
        }

        private void item_Click(object sender, EventArgs e)
        {
            onClearSelectedRequested();

            Selected = !Selected;

            UpdateColor();
        }

        private void UpdateColor()
        {
            if (Selected)
                this.BackColor = Color.FromArgb(75, 150, 100);
            else
                this.BackColor = _color;
        }

        private void MenuItem_DoubleClick(object sender, EventArgs e)
        {
            if (_item is SoftBarMenu)
            {
                using (CustomizationMenuItemForm form = new CustomizationMenuItemForm((SoftBarMenu)_item))
                {
                    form.ShowDialog();
                    UpdateValues();
                }
            }
            else if (_item is SoftBarHeaderItem)
            {
                using (CustomizationMenuItemForm form = new CustomizationMenuItemForm((SoftBarHeaderItem)_item))
                {
                    form.ShowDialog();
                    UpdateValues();
                }
            }
            else if (_item is SoftBarSubMenu)
            {
                using (CustomizationMenuItemForm form = new CustomizationMenuItemForm((SoftBarSubMenu)_item))
                {
                    form.ShowDialog();
                    UpdateValues();
                }
            }
            else if (_item is SoftBarMenuItem)
            {
                using (CustomizationMenuItemForm form = new CustomizationMenuItemForm((SoftBarMenuItem)_item))
                {
                    form.ShowDialog();
                    UpdateValues();
                }
            }
        }

        private Point MouseDownLocation;

        private void MenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void MenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left += e.X - MouseDownLocation.X;
                this.Top += e.Y - MouseDownLocation.Y;
            }
        }
    }
}
