using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Settings;
using SoftTeam.SoftBar.Core.SoftBar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class SettingsForm : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        private SettingsManager _settingsManager=null;
        private SoftBarManager _manager = null;
        #endregion

        #region Constructor
        public SettingsForm(SoftBarManager manager)
        {
            InitializeComponent();

            _manager = manager;

            // Load settings
            _settingsManager = new SettingsManager(manager.FileManager.SettingsPath);
            LoadSettings();

            // Set tab page and control captions
            tabNavigationPageDirectories.Caption = $"{textEditDirectoriesMenuName.Text} menu - General";
            tabNavigationPageMyDirectories.Caption = $"{textEditDirectoriesMenuName.Text} menu - My folders";
            tabNavigationPageMyTools.Caption = $"{textEditToolsMenuName.Text} menu";

            labelControlSystemMenuWidth.Text = $"{textEditSystemMenuName.Text} menu";
            labelControlSystemMenuName.Text = $"{textEditSystemMenuName.Text} menu";

            checkEditShowDirectoriesMenu.Text = $"{textEditDirectoriesMenuName.Text} menu";
            labelControlDirectoriesMenuWidth.Text = $"{textEditDirectoriesMenuName.Text} menu";
            labelControlDirectoriesMenuName.Text = $"{textEditDirectoriesMenuName.Text} menu";

            checkEditShowToolsMenu.Text = $"{textEditToolsMenuName.Text} menu";
            labelControlToolsMenuWidth.Text = $"{textEditToolsMenuName.Text} menu";
            labelControlToolsMenuName.Text = $"{textEditToolsMenuName.Text} menu";

            labelControlMyDirectoriesHeader.Text = $"Add any additional folders that you want to show in the {textEditDirectoriesMenuName.Text} menu";
            labelControlToolsHeader.Text = $"Add any Windows tools that you want in the {textEditToolsMenuName.Text} menu";

            tabPaneSettings.SelectedPage = tabNavigationPageGeneral;
        }
        #endregion

        #region Load/Save settings
        private void LoadSettings()
        {
            // General
            if (_settingsManager.Settings.ExistsSetting(Constants.General_DirectoriesMenuVisible))
                checkEditShowDirectoriesMenu.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.General_DirectoriesMenuVisible);
            if (_settingsManager.Settings.ExistsSetting(Constants.General_ToolsMenuVisible))
                checkEditShowToolsMenu.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.General_ToolsMenuVisible);

            comboBoxEditTheme.SelectedIndex = _settingsManager.Settings.GetIntegerSetting(Constants.General_Theme);

            spinEditSystemMenuWidth.EditValue = _settingsManager.Settings.GetIntegerSetting(Constants.General_SystemMenuWidth,100);
            spinEditDirectoriesMenuWidth.EditValue = _settingsManager.Settings.GetIntegerSetting(Constants.General_DirectoriesMenuWidth,100);
            spinEditToolsMenuWidth.EditValue = _settingsManager.Settings.GetIntegerSetting(Constants.General_ToolsMenuWidth,100);

            textEditSystemMenuName.Text = _settingsManager.Settings.GetStringSetting(Constants.General_SystemMenuName, "SoftBar");
            textEditDirectoriesMenuName.Text = _settingsManager.Settings.GetStringSetting(Constants.General_DirectoriesMenuName, "Directories");
            textEditToolsMenuName.Text = _settingsManager.Settings.GetStringSetting(Constants.General_ToolsMenuName,"Tools");

            // Directories menu
            if (_settingsManager.Settings.ExistsSetting(Constants.DirectoriesMenu_SubFolderMyFolders))
                checkEditSubFolderMyFolders.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMyFolders);
            if (_settingsManager.Settings.ExistsSetting(Constants.DirectoriesMenu_SubFolderMyDrives))
                checkEditSubFolderDrives.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMyDrives);
            if (_settingsManager.Settings.ExistsSetting(Constants.DirectoriesMenu_SubFolderMySpecialFolders))
                checkEditSubFolderSpecialFolders.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.DirectoriesMenu_SubFolderMySpecialFolders);

            // Drive types
            if (_settingsManager.Settings.ExistsSetting(Constants.DriveType_FixedDrive))
                checkEditFixedDrives.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.DriveType_FixedDrive);
            if (_settingsManager.Settings.ExistsSetting(Constants.DriveType_RemovableDrive))
                checkEditRemovableDrives.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.DriveType_RemovableDrive);
            if (_settingsManager.Settings.ExistsSetting(Constants.DriveType_CDRomDrive))
                checkEditCDRom.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.DriveType_CDRomDrive);
            if (_settingsManager.Settings.ExistsSetting(Constants.DriveType_NetworkDrive))
                checkEditNetworkDrives.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.DriveType_NetworkDrive);

            // Speical folders
            if (_settingsManager.Settings.ExistsSetting(Constants.SpecialFolder_Desktop))
                checkEditSpecialDesktop.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.SpecialFolder_Desktop);
            if (_settingsManager.Settings.ExistsSetting(Constants.SpecialFolder_Documents))
                checkEditSpecialDocuments.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.SpecialFolder_Documents);
            if (_settingsManager.Settings.ExistsSetting(Constants.SpecialFolder_Downloads))
                checkEditSpecialDownloads.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.SpecialFolder_Downloads);
            if (_settingsManager.Settings.ExistsSetting(Constants.SpecialFolder_Pictures))
                checkEditSpecialPictures.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.SpecialFolder_Pictures);
            if (_settingsManager.Settings.ExistsSetting(Constants.SpecialFolder_Videos))
                checkEditSpecialVideos.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.SpecialFolder_Videos);
            if (_settingsManager.Settings.ExistsSetting(Constants.SpecialFolder_Music))
                checkEditSpecialMusic.Checked = _settingsManager.Settings.GetBooleanSetting(Constants.SpecialFolder_Music);

            // My directories
            listBoxControlMyDirectories.DataSource = _settingsManager.Settings.MyDirectories;

            // My tools
            listBoxControlMyTools.DataSource = _settingsManager.Settings.MyTools;

            // Clipboard
            spinEditClipboard.Value = _settingsManager.Settings.GetIntegerSetting(Constants.Clipboard_HistoryItems, 10);
            textEditHotKey.Text = _settingsManager.Settings.GetStringSetting(Constants.Clipboard_Hotkey, "c");
        }

        private void SaveSettings()
        {
            _manager.FileManager.Backup(FileType.Settings);

            // General
            _settingsManager.Settings.SetBooleanSetting(Constants.General_DirectoriesMenuVisible, checkEditShowDirectoriesMenu.Checked);
            _settingsManager.Settings.SetBooleanSetting(Constants.General_ToolsMenuVisible, checkEditShowToolsMenu.Checked);
            _settingsManager.Settings.SetIntegerSetting(Constants.General_Theme, comboBoxEditTheme.SelectedIndex);

            _settingsManager.Settings.SetIntegerSetting(Constants.General_SystemMenuWidth, int.Parse(spinEditSystemMenuWidth.EditValue.ToString()));
            _settingsManager.Settings.SetIntegerSetting(Constants.General_DirectoriesMenuWidth, int.Parse(spinEditDirectoriesMenuWidth.EditValue.ToString()));
            _settingsManager.Settings.SetIntegerSetting(Constants.General_ToolsMenuWidth, int.Parse(spinEditToolsMenuWidth.EditValue.ToString()));

            _settingsManager.Settings.SetSetting(Constants.General_SystemMenuName, textEditSystemMenuName.Text);
            _settingsManager.Settings.SetSetting(Constants.General_DirectoriesMenuName, textEditDirectoriesMenuName.Text);
            _settingsManager.Settings.SetSetting(Constants.General_ToolsMenuName, textEditToolsMenuName.Text);

            // Directories menu
            _settingsManager.Settings.SetBooleanSetting(Constants.DirectoriesMenu_SubFolderMyFolders, checkEditSubFolderMyFolders.Checked);
            _settingsManager.Settings.SetBooleanSetting(Constants.DirectoriesMenu_SubFolderMyDrives, checkEditSubFolderDrives.Checked);
            _settingsManager.Settings.SetBooleanSetting(Constants.DirectoriesMenu_SubFolderMySpecialFolders, checkEditSubFolderSpecialFolders.Checked);


            // Drive types
            _settingsManager.Settings.SetBooleanSetting(Constants.DriveType_FixedDrive, checkEditFixedDrives.Checked);
            _settingsManager.Settings.SetBooleanSetting(Constants.DriveType_RemovableDrive, checkEditRemovableDrives.Checked);
            _settingsManager.Settings.SetBooleanSetting(Constants.DriveType_CDRomDrive, checkEditCDRom.Checked);
            _settingsManager.Settings.SetBooleanSetting(Constants.DriveType_NetworkDrive, checkEditNetworkDrives.Checked);

            // Special folders
            _settingsManager.Settings.SetBooleanSetting(Constants.SpecialFolder_Desktop, checkEditSpecialDesktop.Checked);
            _settingsManager.Settings.SetBooleanSetting(Constants.SpecialFolder_Documents, checkEditSpecialDocuments.Checked);
            _settingsManager.Settings.SetBooleanSetting(Constants.SpecialFolder_Downloads, checkEditSpecialDownloads.Checked);
            _settingsManager.Settings.SetBooleanSetting(Constants.SpecialFolder_Pictures, checkEditSpecialPictures.Checked);
            _settingsManager.Settings.SetBooleanSetting(Constants.SpecialFolder_Videos, checkEditSpecialVideos.Checked);
            _settingsManager.Settings.SetBooleanSetting(Constants.SpecialFolder_Music, checkEditSpecialMusic.Checked);

            // My directories
            _settingsManager.Settings.MyDirectories = (List<Directory>)listBoxControlMyDirectories.DataSource;

            // My tools
            listBoxControlMyTools.DataSource = (List<Tool>)_settingsManager.Settings.MyTools;

            _settingsManager.Settings.SetIntegerSetting(Constants.Clipboard_HistoryItems, int.Parse(spinEditClipboard.EditValue.ToString()));
            _manager.ClipboardManager.ChangeClipboardSize(int.Parse(spinEditClipboard.EditValue.ToString()));

            var hotkey = _settingsManager.Settings.GetStringSetting(Constants.Clipboard_Hotkey, "c");
            if (hotkey != textEditHotKey.Text)
                XtraMessageBox.Show("You need to restart SoftBar when the hotkey has changed!","Hotkey has changed...");

            if (textEditHotKey.Text.Length>0)
                _settingsManager.Settings.SetStringSetting(Constants.Clipboard_Hotkey, textEditHotKey.Text.ToLower());
        }
        #endregion

        #region Save/cancel
        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            _settingsManager.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("All changes will be lost! Are you sure?", "Cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                this.DialogResult = DialogResult.None;
                return;
            }

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

                _settingsManager.Settings.MyDirectories.Add(form.Directory);
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

                _settingsManager.Settings.MyDirectories[index] = form.Directory;
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

            _settingsManager.Settings.MyDirectories.RemoveAt(index);
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

                _settingsManager.Settings.MyTools.Add(form.Tool);
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

                _settingsManager.Settings.MyTools[index] = form.Tool;
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

            _settingsManager.Settings.MyTools.RemoveAt(index);
        }
        #endregion

        private void comboBoxEditTheme_SelectedIndexChanged(object sender, EventArgs e)
        {

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = HelperFunctions.GetThemeName(comboBoxEditTheme.SelectedIndex);
        }

        private void textEditSystemMenuName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditSystemMenuName.Text))
            {
                XtraMessageBox.Show("The System menu name cannot be empty!");
                textEditSystemMenuName.Focus();
                textEditSystemMenuName.Select();
                return;
            }

            labelControlSystemMenuWidth.Text = $"{textEditSystemMenuName.Text} menu";
            labelControlSystemMenuName.Text = $"{textEditSystemMenuName.Text} menu";
        }

        private void textEditDirectoriesMenuName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditDirectoriesMenuName.Text))
            {
                XtraMessageBox.Show("The Directories menu name cannot be empty!");
                textEditDirectoriesMenuName.Focus();
                textEditDirectoriesMenuName.Select();
                return;
            }

            tabNavigationPageDirectories.Caption = $"{textEditDirectoriesMenuName.Text} menu - General";
            tabNavigationPageMyDirectories.Caption = $"{textEditDirectoriesMenuName.Text} menu - My folders";

            checkEditShowDirectoriesMenu.Text = $"{textEditDirectoriesMenuName.Text} menu";
            labelControlDirectoriesMenuWidth.Text = $"{textEditDirectoriesMenuName.Text} menu";
            labelControlDirectoriesMenuName.Text = $"{textEditDirectoriesMenuName.Text} menu";

            labelControlMyDirectoriesHeader.Text = $"Add any additional folders that you want to show in the {textEditDirectoriesMenuName.Text} menu";
        }

        private void textEditToolsMenuName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditToolsMenuName.Text))
            {
                XtraMessageBox.Show("The Tools menu name cannot be empty!");
                textEditToolsMenuName.Focus();
                textEditToolsMenuName.Select();
                return;
            }

            tabNavigationPageMyTools.Caption = $"{textEditToolsMenuName.Text} menu";

            checkEditShowToolsMenu.Text = $"{textEditToolsMenuName.Text} menu";
            labelControlToolsMenuWidth.Text = $"{textEditToolsMenuName.Text} menu";
            labelControlToolsMenuName.Text = $"{textEditToolsMenuName.Text} menu";

            labelControlToolsHeader.Text = $"Add any Windows tools that you want in the {textEditToolsMenuName.Text} menu";
        }

        private void textEditHotKey_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!Constants.validHotKeys.Contains(e.NewValue.ToString()))
            {
                System.Media.SystemSounds.Beep.Play();
                e.Cancel = true;
            }
        }
    }
}