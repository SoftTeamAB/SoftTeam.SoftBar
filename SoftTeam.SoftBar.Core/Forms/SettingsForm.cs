using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Settings;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class SettingsForm : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        private SettingsManager _manager;
        #endregion

        #region Constructor
        public SettingsForm()
        {
            InitializeComponent();

            // Load settings
            _manager = new SettingsManager(HelperFunctions.GetSettingsPath());
            LoadSettings();

            tabPaneSettings.SelectedPage = tabNavigationPageGeneral;
        }
        #endregion

        #region Load/Save settings
        private void LoadSettings()
        {
            // General
            if (_manager.Settings.ExistsSetting(Constants.General_DirectoriesMenuVisible))
                checkEditShowDirectoriesMenu.Checked = _manager.Settings.GetBooleanSetting(Constants.General_DirectoriesMenuVisible);
            if (_manager.Settings.ExistsSetting(Constants.General_ToolsMenuVisible))
                checkEditShowToolsMenu.Checked = _manager.Settings.GetBooleanSetting(Constants.General_ToolsMenuVisible);

            comboBoxEditTheme.SelectedIndex = _manager.Settings.GetIntegerSetting(Constants.General_Theme);

            spinEditSystemMenuWidth.EditValue = _manager.Settings.GetIntegerSetting(Constants.General_SystemMenuWidth,100);
            spinEditDirectoriesMenuWidth.EditValue = _manager.Settings.GetIntegerSetting(Constants.General_DirectoriesMenuWidth,100);
            spinEditToolsMenuWidth.EditValue = _manager.Settings.GetIntegerSetting(Constants.General_ToolsMenuWidth,100);

            string name = "SoftBar";
            if (_manager.Settings.ExistsSetting(Constants.General_SystemMenuName))
                name = _manager.Settings.GetSetting(Constants.General_SystemMenuName).Value;
            textEditSystemMenuName.Text = name;
            name = "Directories";
            if (_manager.Settings.ExistsSetting(Constants.General_DirectoriesMenuName))
                name = _manager.Settings.GetSetting(Constants.General_DirectoriesMenuName).Value;
            textEditDirectoriesMenuName.Text = name;
            name = "Tools";
            if (_manager.Settings.ExistsSetting(Constants.General_ToolsMenuName))
                name = _manager.Settings.GetSetting(Constants.General_ToolsMenuName).Value;
            textEditToolsMenuName.Text = name;

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
            listBoxControlMyDirectories.DataSource = _manager.Settings.MyDirectories;

            // My tools
            listBoxControlMyTools.DataSource = _manager.Settings.MyTools;
        }

        private void SaveSettings()
        {
            // General
            _manager.Settings.SetBooleanSetting(Constants.General_DirectoriesMenuVisible, checkEditShowDirectoriesMenu.Checked);
            _manager.Settings.SetBooleanSetting(Constants.General_ToolsMenuVisible, checkEditShowToolsMenu.Checked);
            _manager.Settings.SetIntegerSetting(Constants.General_Theme, comboBoxEditTheme.SelectedIndex);

            _manager.Settings.SetIntegerSetting(Constants.General_SystemMenuWidth, int.Parse(spinEditSystemMenuWidth.EditValue.ToString()));
            _manager.Settings.SetIntegerSetting(Constants.General_DirectoriesMenuWidth, int.Parse(spinEditDirectoriesMenuWidth.EditValue.ToString()));
            _manager.Settings.SetIntegerSetting(Constants.General_ToolsMenuWidth, int.Parse(spinEditToolsMenuWidth.EditValue.ToString()));

            _manager.Settings.SetSetting(Constants.General_SystemMenuName, textEditSystemMenuName.Text);
            _manager.Settings.SetSetting(Constants.General_DirectoriesMenuName, textEditDirectoriesMenuName.Text);
            _manager.Settings.SetSetting(Constants.General_ToolsMenuName, textEditToolsMenuName.Text);

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
            _manager.Settings.MyDirectories = (List<Directory>)listBoxControlMyDirectories.DataSource;

            // My tools
            listBoxControlMyTools.DataSource = (List<Tool>)_manager.Settings.MyTools;

            //// My directories
            //_manager.Settings.MyDirectories.Clear();
            //foreach (var directory in listBoxControlMyDirectories.Items)
            //{
            //    var item = new Directory();
            //    item.Name = directory.ToString();
            //    item.IconPath = "";
            //    item.Path = directory.ToString();
            //    item.BeginGroup = false;
            //    _manager.Settings.MyDirectories.Add(item);
            //}

            //// My tools
            //_manager.Settings.MyTools.Clear();
            //foreach (var tool in listBoxControlMyTools.Items)
            //{
            //    var itemTool = new Tool();
            //    itemTool.Name = tool.ToString();
            //    itemTool.IconPath = tool.ToString();
            //    itemTool.Path = tool.ToString();
            //    itemTool.Parameters = "";
            //    itemTool.BeginGroup = false;
            //    _manager.Settings.MyTools.Add(itemTool);
            //}
        }
        #endregion

        #region Save/cancel
        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            _manager.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Directory button events
        private void simpleButtonAddDirectory_Click(object sender, EventArgs e)
        {
            using (MyDirectoryForm form = new MyDirectoryForm())
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel) return;

                _manager.Settings.MyDirectories.Add(form.Directory);
            }
        }

        private void simpleButtonEditDirectory_Click(object sender, EventArgs e)
        {
            EditDirectory();
        }

        private void listBoxControlMyDirectories_DoubleClick(object sender, EventArgs e)
        {
            EditDirectory();
        }

        private void EditDirectory()
        {
            var index = listBoxControlMyDirectories.SelectedIndex;
            var directory = (Directory)listBoxControlMyDirectories.SelectedItem;

            using (MyDirectoryForm form = new MyDirectoryForm(directory))
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel) return;

                _manager.Settings.MyDirectories[index] = form.Directory;
            }
        }

        private void simpleButtonRemove_Click(object sender, EventArgs e)
        {
            var index = listBoxControlMyDirectories.SelectedIndex;
            var directory = (Directory)listBoxControlMyDirectories.SelectedItem;

            var message = $"Are you sure you want to delete the path '{directory.Name}'?";

            DialogResult result = XtraMessageBox.Show(message, "My directory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            _manager.Settings.MyDirectories.RemoveAt(index);
        }
        #endregion

        #region Tool button events
        private void simpleButtonAddTool_Click(object sender, EventArgs e)
        {
            using (MyToolsForm form = new MyToolsForm())
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel)
                    return;

                _manager.Settings.MyTools.Add(form.Tool);
            }
        }

        private void simpleButtonEditTool_Click(object sender, EventArgs e)
        {
            EditTool();
        }

        private void listBoxControlMyTools_DoubleClick(object sender, EventArgs e)
        {
            EditTool();
        }

        private void EditTool()
        {
            var index = listBoxControlMyTools.SelectedIndex;
            var tool = (Tool)listBoxControlMyTools.SelectedItem;

            using (MyToolsForm form = new MyToolsForm(tool))
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.Cancel) return;

                _manager.Settings.MyTools[index] = form.Tool;
            }
        }

        private void simpleButtonRemoveTool_Click(object sender, EventArgs e)
        {
            var index = listBoxControlMyTools.SelectedIndex;
            var tool = (Tool)listBoxControlMyTools.SelectedItem;

            var message = $"Are you sure you want to delete the tool '{tool.Name}'?";

            DialogResult result = XtraMessageBox.Show(message, "My tools", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            _manager.Settings.MyTools.RemoveAt(index);
        }
        #endregion

        private void comboBoxEditTheme_SelectedIndexChanged(object sender, EventArgs e)
        {

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = HelperFunctions.GetThemeName(comboBoxEditTheme.SelectedIndex);
        }
    }
}