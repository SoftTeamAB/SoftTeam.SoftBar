using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Core.Controls
{
    public partial class EditSubMenuControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields
        private string _name = "";
        private string _iconPath = "";
        private bool _beginGroup = false;
        #endregion

        #region Properties
        public new string Name { get => _name; set => _name = value; }
        public string IconPath { get => _iconPath; set => _iconPath = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }
        #endregion

        #region Constructors
        public EditSubMenuControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Fields
        public void LoadValues()
        {
            textEditName.Text = Name;
            textEditIconPath.Text = IconPath;
            checkEditBeginGroup.Checked = BeginGroup;

            UpdateImage(IconPath);
        }

        public void SaveValues()
        {
            Name = textEditName.Text;
            IconPath = textEditIconPath.Text;
            BeginGroup = checkEditBeginGroup.Checked;
        }
        #endregion

        #region Misc functions and events
        private void simpleButtonBrowse_Click(object sender, EventArgs e)
        {
            xtraOpenFileDialogEditSubMenu.InitialDirectory = textEditIconPath.Text;
            xtraOpenFileDialogEditSubMenu.Filter = "Applications (*.exe;*.dll)|*.exe;*.dll";
            xtraOpenFileDialogEditSubMenu.CheckFileExists = true;
            xtraOpenFileDialogEditSubMenu.FilterIndex = 0;
            DialogResult result = xtraOpenFileDialogEditSubMenu.ShowDialog();

            if (result == DialogResult.OK)
            {
                textEditIconPath.Text = xtraOpenFileDialogEditSubMenu.FileName;
                UpdateImage(xtraOpenFileDialogEditSubMenu.FileName);
            }
        }

        private void UpdateImage(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;

            try
            {
                path = Environment.ExpandEnvironmentVariables(path);
                // Extract the icon...
                Image iconImage = Icon.ExtractAssociatedIcon(path).ToBitmap();
                // and return an 16x16 image
                pictureBoxIcon.Image = iconImage.ResizeImage(32, 32);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                // Return an error image
                pictureBoxIcon.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
            }
        }
        #endregion
    }
}
