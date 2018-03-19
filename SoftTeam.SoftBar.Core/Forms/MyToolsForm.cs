using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Settings;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class MyToolsForm : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        public Tool Tool { get; set; }
        #endregion

        #region Constructor
        // Constructor for add tool
        public MyToolsForm()
        {
            InitializeComponent();
        }

        // Constructor for edit tool
        public MyToolsForm(Tool tool)
        {
            InitializeComponent();

            Tool = tool;

            textEditToolName.Text = Tool.Name;
            textEditToolPath.Text = Tool.Path;
            textEditToolIconPath.Text = Tool.IconPath;
            textEditToolParameters.Text = Tool.Parameters;
            checkEditToolBeginGroup.Checked = Tool.BeginGroup;
        }
        #endregion

        #region Button events
        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(textEditToolPath.Text))
            {
                DialogResult result = XtraMessageBox.Show($"The tool path '{textEditToolPath.Text}' does not exist!\n\nDo you want to save it anyway?", "My directory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            if (Tool == null)
                Tool = new Tool();

            Tool.Name = textEditToolName.Text;
            Tool.IconPath = textEditToolIconPath.Text;
            Tool.Path = textEditToolPath.Text;
            Tool.BeginGroup = checkEditToolBeginGroup.Checked;
            Tool.Parameters = textEditToolParameters.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButtonBrowse_Click(object sender, EventArgs e)
        {
            xtraOpenFileDialogTool.Filter = "Exe-files (*.exe)|*.exe|All files (*.*)|*.*";
            xtraOpenFileDialogTool.FilterIndex = 0;
            xtraOpenFileDialogTool.CheckFileExists = true;
            xtraOpenFileDialogTool.Title = "Select a tool...";

            DialogResult result = xtraOpenFileDialogTool.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            textEditToolPath.Text = xtraOpenFileDialogTool.FileName;
        }

        private void simpleButtonTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditToolPath.Text))
            {
                XtraMessageBox.Show("Please click on a tool, or browse to the tool with the browse button to the right.");
                return;
            }

            CommandLineHelper.ExecuteCommandAsync(textEditToolPath.Text);
        }
        #endregion

        #region Misc functions
        private string SetPath(ToolPath tool)
        {
            string path = "";

            switch (tool)
            {
                case ToolPath.Bash:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\bash.exe";
                    break;
                case ToolPath.Calculator:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\calc.exe";
                    break;
                case ToolPath.CommandLine:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\cmd.exe";
                    break;
                case ToolPath.ControlPanel:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\control.exe";
                    break;
                case ToolPath.Defrag:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\dfrgui.exe";
                    break;

                case ToolPath.DiskCleaner:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\cleanmgr.exe";
                    break;
                case ToolPath.EventViewer:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\eventvwr.exe";
                    break;
                case ToolPath.Explorer:
                    path = @"[WINDOWSFOLDER]\explorer.exe";
                    break;
                case ToolPath.Magnify:
                    path = @"[WINDOWSFOLDER]\[SYSTEM32FOLDER]\magnify.exe";
                    break;
                case ToolPath.Notepad:
                    path = @"[WINDOWSFOLDER]\notepad.exe";
                    break;

                case ToolPath.OnScreenKeyboard:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\osk.exe";
                    break;
                case ToolPath.Paint:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\mspaint.exe";
                    break;
                case ToolPath.PerformanceMonitor:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\perfmon.exe";
                    break;
                case ToolPath.RegistryEditor:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\regedit.exe";
                    break;
                case ToolPath.ResourceMonitor:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\resmon.exe";
                    break;

                case ToolPath.SnippingTool:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\SnippingTool.exe";
                    break;
                case ToolPath.SystemInfo:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\msinfo32.exe";
                    break;
                case ToolPath.TaskManager:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\taskmgr.exe";
                    break;
                case ToolPath.VolumeMixer:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\SndVol.exe";
                    break;
                case ToolPath.WordPad:
                    path = @"[WINDOWSFOLDER]\[SYSTEMFOLDER]\Write.exe";
                    break;
            }

            path = path.Replace("[WINDOWSFOLDER]", Environment.GetFolderPath(Environment.SpecialFolder.Windows));

            if (Environment.Is64BitOperatingSystem)
                path = path.Replace("[SYSTEMFOLDER]", "Sysnative");
            else
                path = path.Replace("[SYSTEMFOLDER]", "SysWow32");

            path = path.Replace("[SYSTEM32FOLDER]", "System32");

            return path;
        }
        #endregion

        #region Prepared tools
        private void pictureEditBash_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Bash";
            textEditToolIconPath.Text = SetPath(ToolPath.Bash);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditCalculator_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Calculator";
            textEditToolIconPath.Text = SetPath(ToolPath.Calculator);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditDiskCleaner_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Disk cleaner";
            textEditToolIconPath.Text = SetPath(ToolPath.DiskCleaner);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditCommandLine_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Command line";
            textEditToolIconPath.Text = SetPath(ToolPath.CommandLine);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditControlPanel_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Control panel";
            textEditToolIconPath.Text = SetPath(ToolPath.ControlPanel);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditDefrag_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Defrag tool";
            textEditToolIconPath.Text = SetPath(ToolPath.Defrag);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditEventViewer_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Event viewer";
            textEditToolIconPath.Text = SetPath(ToolPath.EventViewer);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditExplorer_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Explorer";
            textEditToolIconPath.Text = SetPath(ToolPath.Explorer);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditMagnify_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Magnify";
            textEditToolIconPath.Text = SetPath(ToolPath.Magnify);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditSystemInfo_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "System info";
            textEditToolIconPath.Text = SetPath(ToolPath.SystemInfo);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditPaint_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Paint";
            textEditToolIconPath.Text = SetPath(ToolPath.Paint);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditNotepad_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Notepad";
            textEditToolIconPath.Text = SetPath(ToolPath.Notepad);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditOSK_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "On screen keyboard";
            textEditToolIconPath.Text = SetPath(ToolPath.OnScreenKeyboard);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditPerfMon_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Performance monitor";
            textEditToolIconPath.Text = SetPath(ToolPath.PerformanceMonitor);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditRegEdit_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Registry editor";
            textEditToolIconPath.Text = SetPath(ToolPath.RegistryEditor);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditResourceMonitor_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Resource monitor";
            textEditToolIconPath.Text = SetPath(ToolPath.ResourceMonitor);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditVolumeMixer_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Volume mixer";
            textEditToolIconPath.Text = SetPath(ToolPath.VolumeMixer);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditSnippingTool_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Snipping tool";
            textEditToolIconPath.Text = SetPath(ToolPath.SnippingTool);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditTaskManager_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "Task manager";
            textEditToolIconPath.Text = SetPath(ToolPath.TaskManager);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }

        private void pictureEditWordPad_Click(object sender, EventArgs e)
        {
            textEditToolName.Text = "WordPad";
            textEditToolIconPath.Text = SetPath(ToolPath.WordPad);
            textEditToolPath.Text = textEditToolIconPath.Text;
            checkEditToolBeginGroup.Checked = false;
            textEditToolParameters.Text = "";
        }
        #endregion
    }
}