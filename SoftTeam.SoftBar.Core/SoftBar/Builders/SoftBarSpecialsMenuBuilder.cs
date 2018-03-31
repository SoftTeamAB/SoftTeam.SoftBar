using DevExpress.Skins;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using SoftTeam.SoftBar.Core.ClipboardList;
using SoftTeam.SoftBar.Core.Misc;
using System.Drawing;

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

            // My computer name
            SoftBarMenuItem computerNameItem = new SoftBarMenuItem(_manager.Form, "Computer name", true);
            computerNameItem.Setup();
            computerNameItem.Item.Tag = "clipboardComputerName";
            computerNameItem.Item.ItemClick += _manager.SpecialsArea.computerNameItem_ItemClick;
            _specialsMenu.Item.AddItem(computerNameItem.Item);

            // My computer ip
            SoftBarMenuItem ipItem = new SoftBarMenuItem(_manager.Form, "Computer ip", true);
            ipItem.Setup();
            ipItem.Item.Tag = "clipboardIp";
            ipItem.Item.ItemClick += _manager.SpecialsArea.ipItem_ItemClick;
            _specialsMenu.Item.AddItem(ipItem.Item);

            // Clipboard items header
            SoftBarHeaderItem clipboardHeaderItem = new SoftBarHeaderItem(_manager.Form, "Clipboard history", true);
            clipboardHeaderItem.Setup();
            _specialsMenu.Item.AddItem(clipboardHeaderItem.Item);

            // Clipboard items
            foreach (var item in _manager.ClipboardManager.ClipboardList)
            {
                SoftBarMenuItem cliboardItem = new SoftBarMenuItem(_manager.Form, "", true);
                cliboardItem.Setup();

                if (item is ClipboardItemText)
                {
                    // Create and SvgImage to reserve space where
                    // where the text will be drawned
                    var text = ((ClipboardItemText)item).Text.RestrictSize();
                    cliboardItem.Item.ImageOptions.SvgImage = new SvgImage();
                    cliboardItem.Item.ImageOptions.SvgImageSize = new Size(100, text.NumberOfLines() * 16);
                }
                else if (item is ClipboardItemImage)
                {
                    // Create and SvgImage to reserve space where
                    // where the image will be drawned                    
                    cliboardItem.Item.ImageOptions.SvgImage = new SvgImage();
                    cliboardItem.Item.ImageOptions.SvgImageSize = new Size(100, 60);
                }

                cliboardItem.Item.ItemClick += _manager.SpecialsArea.clipboardItem_ItemClick;

                cliboardItem.Item.Tag = item;
                _specialsMenu.Item.AddItem(cliboardItem.Item);
            }
        }

        private void Manager_CustomDrawItem(object sender, DevExpress.XtraBars.BarItemCustomDrawEventArgs e)
        {
            BarItemLink link = e.LinkInfo?.Link as BarItemLink;
            if (link == null) return;
            if (link.Item.Tag == null) return;

            var font = new Font("Tahoma", 8.25f);
            if (link.Item.Tag.ToString() == "clipboardComputerName")
            {
                // Draw my computer name item
                e.DrawBackground();
                DrawItem(e.Graphics, e.Bounds, new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.server), "Computer name", font);
                e.Handled = true;
            }
            else if (link.Item.Tag.ToString() == "clipboardIp")
            {
                // Draw my ip item
                e.DrawBackground();
                DrawItem(e.Graphics, e.Bounds, new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.server_network), "Computer ip", font);
                e.Handled = true;
            }
            else if (link.Item.Tag is ClipboardItem)
            {
                BarButtonItem item = link.Item as BarButtonItem;

                e.DrawBackground();
                e.DrawGlyph();

                if (link.Item.Tag is ClipboardItemText)
                {
                    // Get theme fore color for the text
                    Skin currentSkin = DevExpress.Skins.EditorsSkins.GetSkin(_manager.Form.LookAndFeel);
                    var color = currentSkin.TranslateColor(SystemColors.ControlText);
                    // Get the text that should be drawned
                    var text = ((ClipboardItemText)link.Item.Tag).Text.RestrictSize();
                    // Get the position to draw the text
                    var point = new Point(e.Bounds.Location.X + 2, e.Bounds.Location.Y + 2);
                    // Draw the text
                    e.Graphics.DrawString(text, font, new SolidBrush(color), point);
                    e.Handled = true;
                }
                else if (link.Item.Tag is ClipboardItemImage)
                {
                    // Get the image to be drawned
                    var image = ((ClipboardItemImage)link.Item.Tag).Image;
                    // Get the position for the image
                    var location = new Point(e.Bounds.X + 2, e.Bounds.Y + 2);
                    // Get the size for the image
                    var size = new Size(e.Bounds.Width - 4, e.Bounds.Height - 4);
                    // Create the bounds
                    var imageBounds = new Rectangle(location, size);
                    // Draw the image
                    e.Graphics.DrawImage(image, imageBounds);
                    e.Handled = true;
                }
            }
        }

        private void DrawItem(Graphics g, Rectangle bounds, Image image, string text, Font font)
        {
            // Get the position for the image
            var location = new Point(bounds.X + 4, bounds.Y + 4);
            // Get the size for the image
            var size = new Size(16, 16);
            // Create the bounds
            var imageBounds = new Rectangle(location, size);
            // Draw the image
            g.DrawImage(image, imageBounds);


            // Get theme fore color for the text
            Skin currentSkin = DevExpress.Skins.EditorsSkins.GetSkin(_manager.Form.LookAndFeel);
            var color = currentSkin.TranslateColor(SystemColors.ControlText);
            // Get the position to draw the text
            var point = new Point(bounds.Location.X + 32, bounds.Location.Y + 4);
            // Draw the text
            g.DrawString(text, font, new SolidBrush(color), point);
        }
    }
    #endregion
}

