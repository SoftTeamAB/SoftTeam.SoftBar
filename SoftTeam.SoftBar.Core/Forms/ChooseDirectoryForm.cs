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

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class ChooseDirectoryForm : DevExpress.XtraEditors.XtraForm
    {
        public string Path = "";

        public ChooseDirectoryForm()
        {
            InitializeComponent();
        }

        private void ChooseDirectoryForm_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Path))
                labelControlChoosenDirectory.Text = @"%HOMEPATH%\AppData\Local\SoftTeam AB\SoftBar";
            else
                labelControlChoosenDirectory.Text = Path;
        }

        private void labelControlChoosenDirectory_Click(object sender, EventArgs e)
        {

        }

        private void radioGroupChooseDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            simpleButtonChooseDirectory.Enabled = (radioGroupChooseDirectory.SelectedIndex == 1);
        }

        private void simpleButtonChooseDirectory_Click(object sender, EventArgs e)
        {
            xtraFolderBrowserDialogSoftBar.Description = "Please choose a SoftBar working folder...";
            xtraFolderBrowserDialogSoftBar.Title = "Please choose a folder...";
            DialogResult result = xtraFolderBrowserDialogSoftBar.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            labelControlChoosenDirectory.Text = xtraFolderBrowserDialogSoftBar.SelectedPath;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            Path = "";

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            Path = Environment.ExpandEnvironmentVariables(labelControlChoosenDirectory.Text);

            if (!System.IO.Directory.Exists(Path))
            {
                XtraMessageBox.Show("Please select an existing directory!", "Directory does not exist!");
                return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}