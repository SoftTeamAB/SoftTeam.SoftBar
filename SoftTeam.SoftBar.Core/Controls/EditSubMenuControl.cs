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
            openFileDialogEditSubMenu.InitialDirectory = textEditIconPath.Text;
            openFileDialogEditSubMenu.Filter = "Applications (*.exe;*.dll)|*.exe;*.dll|Bitmap images|*.bmp|GIF images|*.gif|JPEG images|*.jpg; *.jpeg; *.jpe; *.jif; *.jfif; *.jfi|PNG images|*.png|TIFF images|*.tiff; *.tif|All files|*.*";
            openFileDialogEditSubMenu.CheckFileExists = true;
            openFileDialogEditSubMenu.FilterIndex = 7;
            DialogResult result = openFileDialogEditSubMenu.ShowDialog();

            if (result == DialogResult.OK)
            {
                textEditIconPath.Text = openFileDialogEditSubMenu.FileName;
                UpdateImage(openFileDialogEditSubMenu.FileName);
            }
        }

        private void UpdateImage(string path)
        {
            pictureBoxIcon.Image = HelperFunctions.GetFileImage(path, ImageSize.Medium_24x24);
        }
        #endregion

        private void textEditIconPath_EditValueChanged(object sender, EventArgs e)
        {
            UpdateImage(textEditIconPath.Text);
        }
    }
}
