using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Core.Controls
{
    public partial class EditMenuItemControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields
        private string _name = "";
        private string _iconPath = "";
        private string _applicationPath = "";
        private string _documentPath = "";
        private string _parameters = "";
        private bool _beginGroup = false;
        #endregion

        #region Properties
        public new string Name { get => _name; set => _name = value; }
        public string IconPath { get => _iconPath; set => _iconPath = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }
        public string ApplicationPath { get => _applicationPath; set => _applicationPath = value; }
        public string DocumentPath { get => _documentPath; set => _documentPath = value; }
        public string Parameters { get => _parameters; set => _parameters = value; }
        #endregion

        #region Constructor
        public EditMenuItemControl()
        {
            InitializeComponent();

            tabPaneMenuItem.SelectedPage = tabNavigationPageAppearance;
        }
        #endregion

        #region Fields
        public void LoadValues()
        {
            textEditName.Text = Name;
            textEditIconPath.Text = IconPath;
            checkEditBeginGroup.Checked = BeginGroup;

            textEditApplicationPath.Text = ApplicationPath;
            textEditDocumentPath.Text = DocumentPath;
            textEditParameters.Text = Parameters;

            UpdateImage();
        }

        public void SaveValues()
        {
            Name = textEditName.Text;
            IconPath = textEditIconPath.Text;
            BeginGroup = checkEditBeginGroup.Checked;

            ApplicationPath = textEditApplicationPath.Text;
            DocumentPath = textEditDocumentPath.Text;
            Parameters = textEditParameters.Text;

        }
        #endregion

        #region Misc functions
        private void UpdateImage()
        {
            try
            {
                var path = IconPath.Replace("\"","");
                if (string.IsNullOrEmpty(path))
                    path = ApplicationPath;

                if (!string.IsNullOrEmpty(path))
                {
                    path = Environment.ExpandEnvironmentVariables(path);
                    // Extract the icon...
                    Image iconImage = Icon.ExtractAssociatedIcon(path).ToBitmap();
                    // and return an 16x16 image
                    pictureBoxIcon.Image = iconImage.ResizeImage(32, 32);
                }
                else
                    pictureBoxIcon.Image = null;
            }
            catch (Exception ex)
            {
                // Return an error image
                pictureBoxIcon.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
            }
        }
        #endregion

        #region Events
        private void simpleButtonIconPathBrowse_Click(object sender, EventArgs e)
        {
            xtraOpenFileDialogMenuItem.InitialDirectory = textEditIconPath.Text;
            xtraOpenFileDialogMenuItem.Filter = "Applications (*.exe;*.dll)|*.exe;*.dll";
            xtraOpenFileDialogMenuItem.CheckFileExists = true;
            xtraOpenFileDialogMenuItem.FilterIndex = 0;
            DialogResult result = xtraOpenFileDialogMenuItem.ShowDialog();

            if (result == DialogResult.OK)
            {
                textEditIconPath.Text = xtraOpenFileDialogMenuItem.FileName;
                UpdateImage();
            }
        }

        private void simpleButtonApplicationPathBrowse_Click(object sender, EventArgs e)
        {
            xtraOpenFileDialogMenuItem.InitialDirectory = textEditApplicationPath.Text;
            xtraOpenFileDialogMenuItem.Filter = "Applications (*.exe)|*.exe|All files (*.*)|*.*";
            xtraOpenFileDialogMenuItem.CheckFileExists = true;
            xtraOpenFileDialogMenuItem.FilterIndex = 0;
            DialogResult result = xtraOpenFileDialogMenuItem.ShowDialog();

            if (result == DialogResult.OK)
            {
                textEditApplicationPath.Text = xtraOpenFileDialogMenuItem.FileName;
            }
        }

        private void simpleButtonDocumentPathBrowse_Click(object sender, EventArgs e)
        {
            xtraOpenFileDialogMenuItem.InitialDirectory = textEditDocumentPath.Text;
            xtraOpenFileDialogMenuItem.Filter = "All files (*.*)|*.*";
            xtraOpenFileDialogMenuItem.CheckFileExists = true;
            xtraOpenFileDialogMenuItem.FilterIndex = 0;
            DialogResult result = xtraOpenFileDialogMenuItem.ShowDialog();

            if (result == DialogResult.OK)
                textEditDocumentPath.Text = xtraOpenFileDialogMenuItem.FileName;
        }

        private void textEditIconPath_EditValueChanged(object sender, EventArgs e)
        {
            IconPath = textEditIconPath.Text;
            UpdateImage();
        }

        private void textEditApplicationPath_EditValueChanged(object sender, EventArgs e)
        {
            ApplicationPath = textEditApplicationPath.Text;
            UpdateImage();
        }
        #endregion
    }
}
