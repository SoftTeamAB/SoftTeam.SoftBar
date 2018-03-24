using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Settings;
using SoftTeam.SoftBar.Core.SoftBar.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core.SoftBar
{
    /// <summary>
    /// A SoftBar area, can be System, User or Info.
    /// - Each area can containt multiple buttons and menus
    /// </summary>
    public class SoftBarArea
    {
        #region Fields
        private AreaType _type = AreaType.System;
        private List<SoftBarMenu> _menus = null;
        private int _left = 0;
        private SoftBarManager _manager = null;
        #endregion

        #region Events
        public event EventHandler OnAreaResized;

        private void onAreaResized()
        {
            OnAreaResized?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Properties
        public List<SoftBarMenu> Menus { get => _menus; set => _menus = value; }
        //public MainAppBarForm Form { get => _form; set => _form = value; }
        public int Width { get => _left + _menus.Sum(m => m.Width + Constants.SEPARATOR_WIDTH); }
        public int Left { get => _left; set => _left = value; }
        public AreaType Type { get => _type; set => _type = value; }
        #endregion

        #region Constructor
        public SoftBarArea(SoftBarManager manager, AreaType type, int left = 0)
        {
            _manager = manager;
            _type = type;
            _left = left;
            _menus = new List<SoftBarMenu>();
        }
        #endregion

        #region Misc functions
        public void Resize()
        {
            // The system area might have been resized, reload the user area
            Load();
        }

        public void Load(bool hardReload = false)
        {
            foreach (var menu in Menus)
                menu.Clear();

            Menus.Clear();

            if (hardReload)
            {
                AppBarFunctions.SetAppBar(_manager.Form, AppBarEdge.None);
                Application.DoEvents();
                AppBarFunctions.SetAppBar(_manager.Form, AppBarEdge.Top);
            }

            switch (_type)
            {
                case AreaType.System:
                    // Create system area builder
                    var systemMenuBuilder = new SoftBarSystemMenuBuilder(_manager);
                    systemMenuBuilder.Build();
                    break;
                case AreaType.User:
                    // Create user area builder
                    var userMenuBuilder = new SoftBarUserMenuBuilder(_manager);
                    userMenuBuilder.Build();
                    break;
            }
        }
        #endregion

        #region Events
        public void aboutItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _menus[Constants.SYSTEM_MENU].Item.HidePopup();

            using (AboutForm form = new AboutForm())
                form.ShowDialog();
        }

        public void Reload_ItemClick(object sender, ItemClickEventArgs e)
        {
            Load(true);
        }

        public void Button_Click(object sender, EventArgs e)
        {
            var menu = (SoftBarMenu)((SimpleButton)sender).Tag;
            menu.Item.ShowPopup(new Point(menu.Left, 0));
        }

        public void ExitItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _manager.Form.Close();
        }

        public void SettingsItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (SettingsForm form = new SettingsForm(_manager))
            {
                _menus[Constants.SYSTEM_MENU].Item.HidePopup();
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel)
                    return;

                // Reload the settings
                _manager.SettingsManager.Load();

                // Reload the menus
                Load();

                Application.DoEvents();

                // Make sure the areaResized event is called
                onAreaResized();
            }
        }

        public void CustomizeItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (CustomizationForm form = new CustomizationForm(_manager))
            {
                _menus[Constants.SYSTEM_MENU].Item.HidePopup();
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel)
                    return;

                _manager.UserArea.Load();
            }
        }

        public void DesktopItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandLineHelper.ExecuteCommandLine(@"Explorer.exe %USERPROFILE%\Desktop");
        }

        public void DocumentsItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandLineHelper.ExecuteCommandLine(@"Explorer.exe %USERPROFILE%\Documents");
        }

        public void DownloadsItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandLineHelper.ExecuteCommandLine(@"Explorer.exe %USERPROFILE%\Downloads");
        }

        public void PicturesItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandLineHelper.ExecuteCommandLine(@"Explorer.exe %USERPROFILE%\Pictures");
        }

        public void VideosItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandLineHelper.ExecuteCommandLine(@"Explorer.exe %USERPROFILE%\Videos");
        }

        public void MusicItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandLineHelper.ExecuteCommandLine(@"Explorer.exe %USERPROFILE%\Music");
        }

        public void MyDirectory_ItemClick(object sender, ItemClickEventArgs e)
        {
            var directory = (Settings.Directory)e.Item.Tag;
            CommandLineHelper.ExecuteCommandLine($"Explorer.exe {directory.Path}");
        }

        public void DriveItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var drive = ((DriveInfo)e.Item.Tag);
            Process.Start(drive.Name);
        }

        public void toolItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tool = ((Tool)e.Item.Tag);
            Process.Start(tool.Path);
        }

        #endregion
    }
}
