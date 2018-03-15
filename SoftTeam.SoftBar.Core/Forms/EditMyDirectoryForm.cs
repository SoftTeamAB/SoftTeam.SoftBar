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
    public partial class EditMyDirectoryForm : DevExpress.XtraEditors.XtraForm
    {
        public string Path { get => textEditMyDirectory.Text; internal set => textEditMyDirectory.Text = value; }

        public EditMyDirectoryForm(string path)
        {
            InitializeComponent();

            Path = path;
        }

        private void simpleButtonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = xtraFolderBrowserDialogMyDirectory.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            textEditMyDirectory.Text = xtraFolderBrowserDialogMyDirectory.SelectedPath;
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(Path))
            {
                DialogResult result = XtraMessageBox.Show($"The path '{Path}' does not exist!\n\nDo you want to save it anyway?","My directory", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}