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
            try
            {
                Image image = HelperFunctions.GetFileImage(path, ImageSize.Large);

                if (image == null)
                    // Return an error image
                    pictureBoxIcon.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
                else
                    // Return the correct image
                    pictureBoxIcon.Image = image;
            }
            catch
            {
                // Return an error image
                pictureBoxIcon.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
            }
        }
        #endregion

        private void textEditIconPath_EditValueChanged(object sender, EventArgs e)
        {
            UpdateImage(textEditIconPath.Text);
        }
    }
}
