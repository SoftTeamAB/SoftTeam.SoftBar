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

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class MyDirectoryForm : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        public Directory Directory { get; set; }
        #endregion

        #region Constructor
        // Constructor for add directory
        public MyDirectoryForm()
        {
            InitializeComponent();
        }

        // Constructor for edit directory
        public MyDirectoryForm(Directory directory)
        {
            InitializeComponent();

            Directory = directory;

            textEditName.Text = Directory.Name;
            textEditPath.Text = Directory.Path;
            textEditIconPath.Text = Directory.IconPath;
            checkEditBegingGroup.Checked = Directory.BeginGroup;
        }
        #endregion

        #region Button events
        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(textEditPath.Text))
            {
                DialogResult result = XtraMessageBox.Show($"The path '{textEditPath.Text}' does not exist!\n\nDo you want to save it anyway?", "My directory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            if (Directory == null)
                Directory = new Directory();

            Directory.Name = textEditName.Text;
            Directory.Path = textEditPath.Text;
            Directory.IconPath = textEditIconPath.Text;
            Directory.BeginGroup = checkEditBegingGroup.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButtonBrowsePath_Click(object sender, EventArgs e)
        {
            DialogResult result = xtraFolderBrowserDialogMyDirectory.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            textEditPath.Text = xtraFolderBrowserDialogMyDirectory.SelectedPath;
        }

        private void simpleButtonBrowseIconPath_Click(object sender, EventArgs e)
        {
            DialogResult result = xtraFolderBrowserDialogMyDirectory.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            textEditIconPath.Text = xtraFolderBrowserDialogMyDirectory.SelectedPath;
        }
        #endregion
    }
}