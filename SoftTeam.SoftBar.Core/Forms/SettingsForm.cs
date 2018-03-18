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
using SoftTeam.SoftBar.Core.Settings;
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class SettingsForm : DevExpress.XtraEditors.XtraForm
    {
        private SettingsManager _manager;

        public SettingsForm()
        {
            InitializeComponent();

            // Load settings
            _manager = new SettingsManager(HelperFunctions.GetSettingsPath());
            LoadSettings();

            tabPaneSettings.SelectedPage = tabNavigationPageGeneral;
        }

        private void LoadSettings()
        {
            // General
            if (_manager.Settings.ExistsSetting(Constants.General_DirectoriesMenuVisible))
                checkEditShowDirectoriesMenu.Checked = _manager.Settings.GetBooleanSetting(Constants.General_DirectoriesMenuVisible);

            // Drive types
            if (_manager.Settings.ExistsSetting(Constants.DriveType_FixedDrive))
                checkEditFixedDrives.Checked = _manager.Settings.GetBooleanSetting(Constants.DriveType_FixedDrive); 
            if (_manager.Settings.ExistsSetting(Constants.DriveType_RemovableDrive))
                checkEditRemovableDrives.Checked = _manager.Settings.GetBooleanSetting(Constants.DriveType_RemovableDrive); 
            if (_manager.Settings.ExistsSetting(Constants.DriveType_CDRomDrive))
                checkEditCDRom.Checked = _manager.Settings.GetBooleanSetting(Constants.DriveType_CDRomDrive); 
            if (_manager.Settings.ExistsSetting(Constants.DriveType_NetworkDrive))
                checkEditNetworkDrives.Checked = _manager.Settings.GetBooleanSetting(Constants.DriveType_NetworkDrive); 

            // Speical folders
            if (_manager.Settings.ExistsSetting(Constants.SpecialFolder_Desktop))
                checkEditSpecialDesktop.Checked = _manager.Settings.GetBooleanSetting(Constants.SpecialFolder_Desktop); 
            if (_manager.Settings.ExistsSetting(Constants.SpecialFolder_Documents))
                checkEditSpecialDocuments.Checked = _manager.Settings.GetBooleanSetting(Constants.SpecialFolder_Documents); 
            if (_manager.Settings.ExistsSetting(Constants.SpecialFolder_Downloads))
                checkEditSpecialDownloads.Checked = _manager.Settings.GetBooleanSetting(Constants.SpecialFolder_Downloads); 
            if (_manager.Settings.ExistsSetting(Constants.SpecialFolder_Pictures))
                checkEditSpecialPictures.Checked = _manager.Settings.GetBooleanSetting(Constants.SpecialFolder_Pictures); 
            if (_manager.Settings.ExistsSetting(Constants.SpecialFolder_Videos))
                checkEditSpecialVideos.Checked = _manager.Settings.GetBooleanSetting(Constants.SpecialFolder_Videos); 
            if (_manager.Settings.ExistsSetting(Constants.SpecialFolder_Music))
                checkEditSpecialMusic.Checked = _manager.Settings.GetBooleanSetting(Constants.SpecialFolder_Music); 

            // My directories
            foreach (var directory in _manager.Settings.MyDirectories)
                listBoxControlMyDirectories.Items.Add(directory);

            // My tools
            foreach (var tool in _manager.Settings.MyTools)
                listBoxControlMyTools.Items.Add(tool);
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            _manager.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveSettings()
        {
            // General
            _manager.Settings.SetBooleanSetting(Constants.General_DirectoriesMenuVisible, checkEditShowDirectoriesMenu.Checked);

            // Drive types
            _manager.Settings.SetBooleanSetting(Constants.DriveType_FixedDrive, checkEditFixedDrives.Checked);
            _manager.Settings.SetBooleanSetting(Constants.DriveType_RemovableDrive, checkEditRemovableDrives.Checked);
            _manager.Settings.SetBooleanSetting(Constants.DriveType_CDRomDrive, checkEditCDRom.Checked);
            _manager.Settings.SetBooleanSetting(Constants.DriveType_NetworkDrive, checkEditNetworkDrives.Checked);

            // Special folders
            _manager.Settings.SetBooleanSetting(Constants.SpecialFolder_Desktop, checkEditSpecialDesktop.Checked);
            _manager.Settings.SetBooleanSetting(Constants.SpecialFolder_Documents, checkEditSpecialDocuments.Checked);
            _manager.Settings.SetBooleanSetting(Constants.SpecialFolder_Downloads, checkEditSpecialDownloads.Checked);
            _manager.Settings.SetBooleanSetting(Constants.SpecialFolder_Pictures, checkEditSpecialPictures.Checked);
            _manager.Settings.SetBooleanSetting(Constants.SpecialFolder_Videos, checkEditSpecialVideos.Checked);
            _manager.Settings.SetBooleanSetting(Constants.SpecialFolder_Music, checkEditSpecialMusic.Checked);

            // My directories
            _manager.Settings.MyDirectories.Clear();
            foreach (var directory in listBoxControlMyDirectories.Items)
            {
                var item = new Directory();
                item.Name = directory.ToString();
                item.IconPath = "";
                item.Path = directory.ToString();
                item.BeginGroup = false;
                _manager.Settings.MyDirectories.Add(item);
            }

            // My tools
            _manager.Settings.MyTools.Clear();
            foreach (var tool in listBoxControlMyTools.Items)
            {
                var itemTool = new Tool();
                itemTool.Name = tool.ToString();
                itemTool.IconPath = tool.ToString();
                itemTool.Path = tool.ToString();
                itemTool.Parameters = "";
                itemTool.BeginGroup = false;
                _manager.Settings.MyTools.Add(itemTool);
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButtonAddDirectory_Click(object sender, EventArgs e)
        {
            using (EditMyDirectoryForm form = new EditMyDirectoryForm(""))
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel) return;

                listBoxControlMyDirectories.Items.Add(form.Path);
            }
        }

        private void simpleButtonEditDirectory_Click(object sender, EventArgs e)
        {
            var index = listBoxControlMyDirectories.SelectedIndex;

            using (EditMyDirectoryForm form = new EditMyDirectoryForm(listBoxControlMyDirectories.Items[index].ToString()))
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel) return;

                listBoxControlMyDirectories.Items[index] = form.Path;
            }
        }

        private void simpleButtonRemove_Click(object sender, EventArgs e)
        {
            var index = listBoxControlMyDirectories.SelectedIndex;
            var message = $"Are you sure you want to delete the path '{listBoxControlMyDirectories.Items[index].ToString()}'?";

            DialogResult result = XtraMessageBox.Show(message, "My directory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            listBoxControlMyDirectories.Items.RemoveAt(index);
        }

        private void simpleButtonAddTool_Click(object sender, EventArgs e)
        {
            using (AddToolsForm form = new AddToolsForm())
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel)
                    return;

                listBoxControlMyTools.Items.Add(form.SelectedTool);
            }
        }
    }
}