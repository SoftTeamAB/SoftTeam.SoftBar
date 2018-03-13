using System;
using System.Drawing;
using System.Windows.Forms;
using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Core.Controls
{
    public partial class MenuItem : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields
        private int _level = 0;
        private SoftBarBaseItem _item = null;
        private MenuItemType _type = MenuItemType.None;
        private MenuItemSelectedStatus _selected = MenuItemSelectedStatus.NotSelected;
        private Color _color;
        private MenuItem _previousMenuItem = null;
        #endregion

        #region Properties
        public MenuItemSelectedStatus Selected { get => _selected; set { _selected = value; UpdateColor(); } }
        public MenuItem PreviousMenuItem { get => _previousMenuItem; set => _previousMenuItem = value; }
        #endregion

        #region Constructor
        public MenuItem(MenuItemType type, SoftBarBaseItem item, int level, Color color, MenuItem previousMenuItem=null)
        {
            _type = type;
            _level = level;
            _item = item;
            InitializeComponent();
            UpdateValues();
            this.BackColor = color;
            _color = color;

            // Attach event handlers
            AttachEvents();
        }

        ~MenuItem()
        {
            // Remove event handlers
            DetachEvents();
        }

        private void AttachEvents()
        {
            this.MouseDown += MenuItem_MouseDown;
            this.labelControlName.MouseDown += MenuItem_MouseDown;
            this.labelControlType.MouseDown += MenuItem_MouseDown;
            this.pictureBoxIcon.MouseDown += MenuItem_MouseDown;
            this.pictureBoxBeginGroup.MouseDown += MenuItem_MouseDown;
            this.pictureBoxNoBeginGroup.MouseDown += MenuItem_MouseDown;
        }

        private void DetachEvents()
        {
            this.MouseDown -= MenuItem_MouseDown;
            this.labelControlName.MouseDown -= MenuItem_MouseDown;
            this.labelControlType.MouseDown -= MenuItem_MouseDown;
            this.pictureBoxIcon.MouseDown -= MenuItem_MouseDown;
            this.pictureBoxBeginGroup.MouseDown -= MenuItem_MouseDown;
            this.pictureBoxNoBeginGroup.MouseDown -= MenuItem_MouseDown;
        }
        #endregion

        #region Events
        public delegate void MenuItemClickedEventHandler(object sender, MenuSelectedEventArgs e);
        public event MenuItemClickedEventHandler MenuSelected;
        public event EventHandler ClearSelectedRequested;

        public class MenuSelectedEventArgs
        {
            public SoftBarBaseMenu Menu { get; set; }

            public MenuSelectedEventArgs(SoftBarBaseMenu menu)
            {
                Menu = menu;
            }
        }

        private void onMenuSelected()
        {
            MenuSelected?.Invoke(this, new MenuSelectedEventArgs((SoftBarBaseMenu)_item));
        }

        private void onClearSelectedRequested()
        {
            ClearSelectedRequested?.Invoke(this, new EventArgs());
        }
        #endregion

        #region Select menu item
        private void MenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            onClearSelectedRequested();
            SelectMenuItem();
        }

        private void SelectMenuItem()
        {
            onClearSelectedRequested();

            Selected = MenuItemSelectedStatus.Selected;

            UpdateColor();

            if (_item is SoftBarBaseMenu)
                onMenuSelected();
        }

        private void UpdateColor()
        {
            switch (Selected)
            {
                case MenuItemSelectedStatus.NotSelected:
                    this.BackColor = _color;
                    break;
                case MenuItemSelectedStatus.Selected:
                    this.BackColor = Color.FromArgb(75, 150, 100);
                    break;
                case MenuItemSelectedStatus.SubSelected:
                    this.BackColor = Color.FromArgb(125, 200, 150);
                    break;
            }
        }
        #endregion

        #region Edit menu item
        private void MenuItem_DoubleClick(object sender, EventArgs e)
        {
            CustomizationMenuItemForm form = null;

            if (_item is SoftBarMenu)
                form = new CustomizationMenuItemForm((SoftBarMenu)_item);
            else if (_item is SoftBarHeaderItem)
                form = new CustomizationMenuItemForm((SoftBarHeaderItem)_item);
            else if (_item is SoftBarSubMenu)
                form = new CustomizationMenuItemForm((SoftBarSubMenu)_item);
            else if (_item is SoftBarMenuItem)
                form = new CustomizationMenuItemForm((SoftBarMenuItem)_item);

            form.ShowDialog();
            UpdateValues();

            form.Dispose();
            form = null;
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
        #endregion
    }
}
