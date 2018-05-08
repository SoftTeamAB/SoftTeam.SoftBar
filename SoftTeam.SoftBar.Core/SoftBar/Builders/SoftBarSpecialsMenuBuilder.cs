using DevExpress.Skins;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.ClipboardList;
using SoftTeam.SoftBar.Core.Misc;
using System.Drawing;
using System.Windows.Forms;

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
            // Build them "backwards" so that we know the width
            var clipboardVisible = _manager.SettingsManager.Settings.GetBooleanSetting(Constants.General_ClipboardMenuVisible);
            var performanceMeterVisible = _manager.SettingsManager.Settings.GetBooleanSetting(Constants.General_PerformanceMeterVisible);

            if (clipboardVisible && performanceMeterVisible)
            {
                var width = BuildClipboardMenu();
                BuildPerformanceMenu(width);
            }
            else if (clipboardVisible)
                BuildClipboardMenu();
            else if (performanceMeterVisible)
                BuildPerformanceMenu(0);
        }

        private void BuildPerformanceMenu(int clipboardWidth)
        {
            var text = "The performance meter show you how much of your computers CPU and memory that are being used. Click to start <b>Windows Task Manager</b>!";
            var width = 70;
            LabelControl labelCPU = new LabelControl();
            labelCPU.Name = "labelCPU";
            labelCPU.Text = "CPU : {0:#.0} %";
            labelCPU.Location = new Point(_manager.Form.Width - clipboardWidth - width, 2);
            labelCPU.AllowHtmlString = true;
            labelCPU.SuperTip = HelperFunctions.CreateInformationToolTip(text);
            labelCPU.ToolTipController = _manager.ToolTipController;
            _manager.Form.Controls.Add(labelCPU);

            LabelControl labelMem = new LabelControl();
            labelMem.Name = "labelMem";
            labelMem.Text = "Mem : {0:#.0} %";
            labelMem.AllowHtmlString = true;
            labelMem.Location = new Point(_manager.Form.Width - clipboardWidth - width, 15);
            labelMem.SuperTip = HelperFunctions.CreateInformationToolTip(text);
            labelMem.ToolTipController = _manager.ToolTipController;
            _manager.Form.Controls.Add(labelMem);
        }

        private int BuildClipboardMenu()
        {
            // Create the clipboard menu
            var width = _manager.SettingsManager.Settings.GetIntegerSetting(Constants.General_ClipboardMenuWidth, 100);
            var name = _manager.SettingsManager.Settings.GetStringSetting(Constants.General_ClipboardMenuName, "Clipboard");
            var left = _manager.Form.Width - width;
            var text = "Use clipboard hotkey to open the clipboard menu at mouse position.\n\nUse SHIFT+click to remove a clipboard history item (for example a password).";

            _specialsMenu = new SoftBarMenu(_manager.Form, name, left, width, true);
            _specialsMenu.Width = width;
            _manager.SpecialsArea.Menus.Add(_specialsMenu);
            _specialsMenu.Setup();
            _specialsMenu.Button.Click += _manager.SpecialsArea.ClipboardMenu_Clicked;
            _specialsMenu.Button.Tag = _specialsMenu;
            _specialsMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.clipboard_medium);
            _specialsMenu.Button.SuperTip = HelperFunctions.CreateInformationToolTip(text);
            _specialsMenu.Button.ToolTipController = _manager.ToolTipController;
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
                AddClipboardItem(item);

            return width;
        }

        private void AddClipboardItem(object item)
        {
            SoftBarMenuItem cliboardItem = new SoftBarMenuItem(_manager.Form, "", true);
            cliboardItem.Setup();

            if (item is ClipboardItemText)
            {
                // Create and SvgImage to reserve space where
                // where the text will be drawned
                var text = ((ClipboardItemText)item).Text.RestrictSize().Trim();
                cliboardItem.Item.ImageOptions.SvgImage = new SvgImage();
                cliboardItem.Item.ImageOptions.SvgImageSize = new Size(100, text.NumberOfLines() * 14);
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
        #endregion

        #region Draw item
        private void Manager_CustomDrawItem(object sender, DevExpress.XtraBars.BarItemCustomDrawEventArgs e)
        {
            BarItemLink link = e.LinkInfo?.Link as BarItemLink;
            if (link == null) return;
            if (link.Item.Tag == null) return;
            Graphics g = e.Graphics;

            var font = new Font("Tahoma", 8.25f);
            if (link.Item.Tag.ToString() == "clipboardComputerName")
            {
                var appearance = link.Item.ItemAppearance.GetAppearance(e.State);
                // Draw my computer name item
                e.DrawBackground();
                DrawItem(g, e.Bounds, new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.server), "Computer name", appearance.Font);
                e.Handled = true;
            }
            else if (link.Item.Tag.ToString() == "clipboardIp")
            {
                var appearance = link.Item.ItemAppearance.GetAppearance(e.State);
                // Draw my ip item
                e.DrawBackground();
                DrawItem(g, e.Bounds, new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.server_network), "Computer ip", appearance.Font);
                e.Handled = true;
            }
            else if (link.Item.Tag is ClipboardItem)
            {
                var appearance = link.Item.ItemAppearance.GetAppearance(e.State);
                BarButtonItem item = link.Item as BarButtonItem;
                // Get theme fore color for the text
                Skin currentSkin = DevExpress.Skins.EditorsSkins.GetSkin(_manager.Form.LookAndFeel);
                var backGroundColor = currentSkin.TranslateColor(SystemColors.Control);
                e.DrawBackground();
                e.DrawGlyph();
                DrawBorder(g, e.Bounds, ((ClipboardItem)link.Item.Tag).CurrentlyInClipboard);

                if (link.Item.Tag is ClipboardItemText)
                {
                    var color = currentSkin.TranslateColor(SystemColors.ControlText);
                    // Get the text that should be drawned
                    var text = ((ClipboardItemText)link.Item.Tag).Text.RestrictSize();
                    // Get the position to draw the text
                    var point = new Point(e.Bounds.Location.X + 2, e.Bounds.Location.Y + 5);
                    // Draw the text
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    g.DrawString(text, appearance.Font, new SolidBrush(color), point);
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
                    g.DrawImage(image, imageBounds);
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
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.DrawString(text, font, new SolidBrush(color), point);
        }

        private void DrawBorder(Graphics g, Rectangle bounds, bool currentlyInClipboard)
        {
            // Draw the border arounde the clipboard item
            Color color = Color.DarkGray;
            if (currentlyInClipboard)
                color = Color.Red;

            bounds.Inflate(-1, -1);
            ControlPaint.DrawBorder(g, bounds, color, ButtonBorderStyle.Dashed);
        }
    }
    #endregion
}

