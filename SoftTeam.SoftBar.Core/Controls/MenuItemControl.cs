﻿using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Xml;

namespace SoftTeam.SoftBar.Core.Controls
{
    public partial class MenuItemControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields
        private int _level = 0;
        private XmlMenuItemBase _item = null;
        private MenuItemType _type = MenuItemType.None;
        private MenuItemSelectedStatus _selected = MenuItemSelectedStatus.NotSelected;
        private Color _color;
        private ObservableCollection<MenuItemControl> _menuItems = new ObservableCollection<MenuItemControl>();
        private CustomizationForm _parentForm = null;
        #endregion

        #region Properties
        public MenuItemSelectedStatus Selected { get => _selected; set { _selected = value; UpdateColor(); } }
        public XmlMenuItemBase Item { get => _item; set => _item = value; }
        public int ItemHeight { get => CalculateItemHeight(); }
        #endregion

        #region Constructor
        public MenuItemControl(CustomizationForm parentForm, MenuItemType type, XmlMenuItemBase item, int level, Color color, ObservableCollection<MenuItemControl> menuItems)
        {
            InitializeComponent();

            _parentForm = parentForm;
            _type = type;
            _item = item;
            _level = level;
            _color = color;
            _menuItems = menuItems;

            UpdateValues();
            this.BackColor = color;
        }
        #endregion

        #region Events
        public event EventHandler ClearSelectedRequested;

        private void onClearSelectedRequested()
        {
            ClearSelectedRequested?.Invoke(this, new EventArgs());
        }

        public event EventHandler ItemSelected;

        private void onNoItemSelected()
        {
            ItemSelected?.Invoke(null, new EventArgs());
        }

        private void onItemSelected()
        {
            ItemSelected?.Invoke(this, new EventArgs());
        }
        #endregion

        #region Select menu item
        private void MenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            SelectMenuItem();
        }

        private void SelectMenuItem()
        {
            // If it is selected...
            if (Selected == MenuItemSelectedStatus.Selected)
            {
                // ...unselect it
                Selected = MenuItemSelectedStatus.NotSelected;
                onNoItemSelected();
            }
            else
            {
                //...otherwise, clear all, and select it.
                onClearSelectedRequested();
                Selected = MenuItemSelectedStatus.Selected;
                onItemSelected();
            }

            // Update the colors
            UpdateColor();
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
            // Make sure that this item is selected when we edit it
            onClearSelectedRequested();
            Selected = MenuItemSelectedStatus.Selected;

            CustomizationMenuItemForm form = null;

            if (_item is XmlMenu)
                form = new CustomizationMenuItemForm((XmlMenu)_item);
            else if (_item is XmlHeaderItem)
                form = new CustomizationMenuItemForm((XmlHeaderItem)_item);
            else if (_item is XmlSubMenu)
                form = new CustomizationMenuItemForm((XmlSubMenu)_item);
            else if (_item is XmlMenuItem)
                form = new CustomizationMenuItemForm((XmlMenuItem)_item);

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

            if (_item.BeginGroup)
                pictureBoxBeginGroup.BringToFront();
            else
                pictureBoxNoBeginGroup.BringToFront();

            if (_item is XmlMenuItem)
            {
                var menuItem = (XmlMenuItem)_item;
                var path = Environment.ExpandEnvironmentVariables(menuItem.IconPath);
                if (!string.IsNullOrEmpty(menuItem.IconPath))
                    pictureBoxIcon.Image = HelperFunctions.GetFileImage(path);
                else if (!string.IsNullOrEmpty(menuItem.ApplicationPath))
                    pictureBoxIcon.Image = HelperFunctions.GetFileImage(menuItem.ApplicationPath);
            }
            else
                pictureBoxIcon.Image = HelperFunctions.GetFileImage(_item.IconPath);
        }
        #endregion

        #region Private functions
        private int CalculateItemHeight()
        {
            var count = _item.CountItems();
            return count * Constants.ITEM_HEIGHT + (count - 1) * Constants.SEPARATOR_WIDTH;
        }
        #endregion
    }
}
