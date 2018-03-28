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
            _specialsMenu.Button.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.clipboard);

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
                // Settings for the app bar
                var text = ((ClipboardItemText)item).Text;
                text.Replace("\n", " ");
                if (text.Length > 20)
                    text = text.Substring(0, 20);
                SoftBarMenuItem cliboardItem = new SoftBarMenuItem(_manager.Form, text, true);
                cliboardItem.Setup();
                cliboardItem.Item.ImageOptions.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.clipboard);
                cliboardItem.Item.ItemClick += _manager.SpecialsArea.clipboardItem_ItemClick;
                cliboardItem.Item.Tag = ((ClipboardItemText)item).Text;
                _specialsMenu.Item.AddItem(cliboardItem.Item);

                if (first)
                {
                    cliboardItem.Item.Links[0].BeginGroup = true;
                    first = false;
                }
            }
        }
        #endregion
    }
}
