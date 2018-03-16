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
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Helpers;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class AddToolsForm : DevExpress.XtraEditors.XtraForm
    {
        public string Path { get => textEditToolPath.Text; }

        public AddToolsForm()
        {
            InitializeComponent();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
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

        private void SetPath(ToolPath tool)
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

            textEditToolPath.Text = path;
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

        private void pictureEditBash_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.Bash);
        }

        private void pictureEditCalculator_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.Calculator);
        }

        private void pictureEditDiskCleaner_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.DiskCleaner);
        }

        private void pictureEditCommandLine_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.CommandLine);
        }

        private void pictureEditControlPanel_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.ControlPanel);
        }

        private void pictureEditDefrag_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.Defrag);
        }

        private void pictureEditEventViewer_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.EventViewer);
        }

        private void pictureEditExplorer_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.Explorer);
        }

        private void pictureEditMagnify_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.Magnify);
        }

        private void pictureEditSystemInfo_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.SystemInfo);
        }

        private void pictureEditPaint_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.Paint);
        }

        private void pictureEditNotepad_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.Notepad);
        }

        private void pictureEditOSK_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.OnScreenKeyboard);
        }

        private void pictureEditPerfMon_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.PerformanceMonitor);
        }

        private void pictureEditRegEdit_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.RegistryEditor);
        }

        private void pictureEditResourceMonitor_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.ResourceMonitor);
        }

        private void pictureEditVolumeMixer_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.VolumeMixer);
        }

        private void pictureEditSnippingTool_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.SnippingTool);
        }

        private void pictureEditTaskManager_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.TaskManager);
        }

        private void pictureEditWordPad_Click(object sender, EventArgs e)
        {
            SetPath(ToolPath.WordPad);
        }
    }
}