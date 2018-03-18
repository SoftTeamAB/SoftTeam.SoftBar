﻿using System;
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
            if (_manager.Settings.ExistsSetting("General.DirectoriesMenuVisible"))
                checkEditShowDirectoriesMenu.Checked = _manager.Settings.GetSetting("General.DirectoriesMenuVisible").Value.ToLower() == "true";
            else
                checkEditShowDirectoriesMenu.Checked = true;

            // Drive types
            if (_manager.Settings.ExistsSetting("DriveType.FixedDrive"))
                checkEditFixedDrives.Checked = _manager.Settings.GetSetting("DriveType.FixedDrive").Value.ToLower() == "true"; 
            else
                checkEditFixedDrives.Checked = true;
            if (_manager.Settings.ExistsSetting("DriveType.RemovableDrive"))
                checkEditRemovableDrives.Checked = _manager.Settings.GetSetting("DriveType.RemovableDrive").Value.ToLower() == "true"; 
            else
                checkEditRemovableDrives.Checked = true;
            if (_manager.Settings.ExistsSetting("DriveType.CDRomDrive"))
                checkEditCDRom.Checked = _manager.Settings.GetSetting("DriveType.CDRomDrive").Value.ToLower() == "true"; 
            else
                checkEditCDRom.Checked = true;
            if (_manager.Settings.ExistsSetting("DriveType.NetworkDrive"))
                checkEditNetworkDrives.Checked = _manager.Settings.GetSetting("DriveType.NetworkDrive").Value.ToLower() == "true"; 
            else
                checkEditNetworkDrives.Checked = true;

            // Speical folders
            if (_manager.Settings.ExistsSetting("SpecialFolder.Desktop"))
                checkEditSpecialDesktop.Checked = _manager.Settings.GetSetting("SpecialFolder.Desktop").Value.ToLower() == "true"; 
            else
                checkEditSpecialDesktop.Checked = true;
            if (_manager.Settings.ExistsSetting("SpecialFolder.Documents"))
                checkEditSpecialDocuments.Checked = _manager.Settings.GetSetting("SpecialFolder.Documents").Value.ToLower() == "true"; 
            else
                checkEditSpecialDocuments.Checked = true;
            if (_manager.Settings.ExistsSetting("SpecialFolder.Download"))
                checkEditSpecialDownloads.Checked = _manager.Settings.GetSetting("SpecialFolder.Download").Value.ToLower() == "true"; 
            else
                checkEditSpecialDownloads.Checked = true;
            if (_manager.Settings.ExistsSetting("SpecialFolder.Pictures"))
                checkEditSpecialPictures.Checked = _manager.Settings.GetSetting("SpecialFolder.Pictures").Value.ToLower() == "true"; 
            else
                checkEditSpecialPictures.Checked = true;
            if (_manager.Settings.ExistsSetting("SpecialFolder.Videos"))
                checkEditSpecialVideos.Checked = _manager.Settings.GetSetting("SpecialFolder.Videos").Value.ToLower() == "true"; 
            else
                checkEditSpecialVideos.Checked = true;
            if (_manager.Settings.ExistsSetting("SpecialFolder.Music"))
                checkEditSpecialMusic.Checked = _manager.Settings.GetSetting("SpecialFolder.Music").Value.ToLower() == "true"; 
            else
                checkEditSpecialMusic.Checked = true;

            // My directories
            foreach (var directory in _manager.Settings.MyDirectories)
                listBoxControlMyDirectories.Items.Add(directory.Name);

            // My tools
            foreach (var tool in _manager.Settings.MyTools)
                listBoxControlMyTools.Items.Add(tool.Name);
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
            _manager.Settings.SetSetting("General.DirectoriesMenuVisible", checkEditShowDirectoriesMenu.Checked.ToString().ToLower());

            // Drive types
            _manager.Settings.SetSetting("DriveType.FixedDrive", checkEditFixedDrives.Checked.ToString().ToLower());
            _manager.Settings.SetSetting("DriveType.RemovableDrive", checkEditRemovableDrives.Checked.ToString().ToLower());
            _manager.Settings.SetSetting("DriveType.CDRomDrive", checkEditCDRom.Checked.ToString().ToLower());
            _manager.Settings.SetSetting("DriveType.NetworkDrive", checkEditNetworkDrives.Checked.ToString().ToLower());

            // Speical folders
            _manager.Settings.SetSetting("SpecialFolder.Desktop", checkEditSpecialDesktop.Checked.ToString().ToLower());
            _manager.Settings.SetSetting("SpecialFolder.Documents", checkEditSpecialDocuments.Checked.ToString().ToLower());
            _manager.Settings.SetSetting("SpecialFolder.Downloads", checkEditSpecialDownloads.Checked.ToString().ToLower());
            _manager.Settings.SetSetting("SpecialFolder.Pictures", checkEditSpecialPictures.Checked.ToString().ToLower());
            _manager.Settings.SetSetting("SpecialFolder.Videos", checkEditSpecialVideos.Checked.ToString().ToLower());
            _manager.Settings.SetSetting("SpecialFolder.Music", checkEditSpecialMusic.Checked.ToString().ToLower());

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

                listBoxControlMyTools.Items.Add(form.Path);
            }
        }
    }
}