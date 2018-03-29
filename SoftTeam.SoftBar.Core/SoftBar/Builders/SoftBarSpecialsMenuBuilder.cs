using DevExpress.XtraBars;
using SoftTeam.SoftBar.Core.ClipboardList;
using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core.SoftBar.Builders
{
    public class SoftBarSpecialsMenuBuilder
    {
        #region Fields
        private SoftBarManager _manager = null;
        private SoftBarMenu _specialsMenu = null;
        #endregion

        #region Constructor
        public SoftBarSpecialsMenuBuilder(SoftBarManager manager)
        {
            _manager = manager;
        }
        #endregion

        #region Build
        public void Build()
        {
            BuildSpecialsMenu();
        }

        private void BuildSpecialsMenu()
        {
            // Create the actual system menu
            var width = _manager.SettingsManager.Settings.GetIntegerSetting(Constants.General_ClipboardMenuWidth, 100);
            var name = _manager.SettingsManager.Settings.GetStringSetting(Constants.General_ClipboardMenuName, "Clipboard");
            var left = _manager.Form.Width - width;

            _specialsMenu = new SoftBarMenu(_manager.Form, name, left, width, true);
            _specialsMenu.Width = width;
            _manager.SpecialsArea.Menus.Add(_specialsMenu);
            _specialsMenu.Setup();
            _specialsMenu.Button.Click += _manager.SpecialsArea.ClipboardMenu_Clicked;
            _specialsMenu.Button.Tag = _specialsMenu;
            _specialsMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.clipboard_medium);
            _specialsMenu.Item.Manager.CustomDrawItem += Manager_CustomDrawItem;

            // Computer name
            SoftBarMenuItem computerNameItem = new SoftBarMenuItem(_manager.Form, "Computer name", true);
            computerNameItem.Setup();
            computerNameItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.server);
            computerNameItem.Item.ItemClick += _manager.SpecialsArea.computerNameItem_ItemClick;
            _specialsMenu.Item.AddItem(computerNameItem.Item);

            // My ip
            SoftBarMenuItem ipItem = new SoftBarMenuItem(_manager.Form, "Computer ip", true);
            ipItem.Setup();
            ipItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.server_network);
            ipItem.Item.ItemClick += _manager.SpecialsArea.ipItem_ItemClick;
            _specialsMenu.Item.AddItem(ipItem.Item);

            bool first = true;
            foreach (var item in _manager.ClipboardManager.ClipboardList)
            {
                string text = "";

                if (item is ClipboardItemText)
                {
                    // Settings for the app bar
                    text = ((ClipboardItemText)item).Text;
                    text.Replace("\n", " ");
                    if (text.Length > 20)
                        text = text.Substring(0, 20);
                }
                else if (item is ClipboardItemImage)
                {
                    //var image = ((ClipboardItemImage)item).Image;
                    text = "";
                }

                SoftBarMenuItem cliboardItem = new SoftBarMenuItem(_manager.Form, text, true);
                cliboardItem.Setup();
                
                cliboardItem.Item.Glyph= new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.clipboard);
                cliboardItem.Item.ItemClick += _manager.SpecialsArea.clipboardItem_ItemClick;

                cliboardItem.Item.Tag = item;
                _specialsMenu.Item.AddItem(cliboardItem.Item);

                if (first)
                {
                    cliboardItem.Item.Links[0].BeginGroup = true;
                    first = false;
                }
            }
        }

        private void Manager_CustomDrawItem(object sender, DevExpress.XtraBars.BarItemCustomDrawEventArgs e)
        {
            BarButtonItemLink link = e.LinkInfo?.Link as BarButtonItemLink;

            if (link!=null && link.Item.Tag is ClipboardItem)
            {
                e.DrawBackground();
                e.DrawGlyph();

                if (link.Item.Tag is ClipboardItemText)
                {
                    var text = ((ClipboardItemText)link.Item.Tag).Text;
                    var color = link.Item.ItemAppearance.Normal.ForeColor;
                    var point = new Point(e.Bounds.Location.X + 30, e.Bounds.Location.Y + 3);
                    e.Graphics.DrawString(text, link.Font, new SolidBrush(Color.White), point);
                    e.Handled = true;
                }
                else if (link.Item.Tag is ClipboardItemImage)
                {
                    var image = ((ClipboardItemImage)link.Item.Tag).Image;

                    var location = new Point(e.Bounds.X + 30, e.Bounds.Y + 2);
                    var size = new Size(e.Bounds.Width - 32, e.Bounds.Height - 4);
                    var imageBounds = new Rectangle(location, size);
                    e.Graphics.DrawImage(image, imageBounds);
                    e.Handled = true;
                }
            }
        }
    }
    #endregion
}

