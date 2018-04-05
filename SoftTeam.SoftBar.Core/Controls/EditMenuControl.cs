using System;
using System.Windows.Forms;
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Core.Controls
{
    public partial class EditMenuControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields
        private string _name = "";
        private string _iconPath = "";
        private bool _beginGroup = false;
        private int _menuWidth = 0;
        #endregion

        #region Properties
        public new string Name { get => _name; set => _name = value; }
        public string IconPath { get => _iconPath; set => _iconPath = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }
        public int MenuWidth { get => _menuWidth; set => _menuWidth = value; }
        #endregion

        #region Construction
        public EditMenuControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Misc functions
        private void simpleButtonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialogEditMenu.InitialDirectory = textEditIconPath.Text;
            openFileDialogEditMenu.Filter = "Applications (*.exe;*.dll)|*.exe;*.dll|Bitmap images|*.bmp|GIF images|*.gif|JPEG images|*.jpg; *.jpeg; *.jpe; *.jif; *.jfif; *.jfi|PNG images|*.png|TIFF images|*.tiff; *.tif|All files|*.*";
            openFileDialogEditMenu.CheckFileExists = true;
            openFileDialogEditMenu.FilterIndex = 7;
            DialogResult result = openFileDialogEditMenu.ShowDialog();

            if (result == DialogResult.OK)
            {
                textEditIconPath.Text = openFileDialogEditMenu.FileName;
                UpdateImage(openFileDialogEditMenu.FileName);
            }
        }

        private void UpdateImage(string path)
        {
            pictureBoxIcon.Image = HelperFunctions.GetFileImage(path, ImageSize.Medium_24x24);
        }
        #endregion

        #region Load/Save
        public void LoadValues()
        {
            textEditName.Text = Name;
            textEditIconPath.Text = IconPath;
            checkEditBeginGroup.Checked = BeginGroup;
            spinEditWidth.EditValue = MenuWidth;

            UpdateImage(IconPath);
        }

        public void SaveValues()
        {
            Name = textEditName.Text;
            IconPath = textEditIconPath.Text;
            BeginGroup = checkEditBeginGroup.Checked;
            MenuWidth = int.Parse(spinEditWidth.EditValue.ToString());
        }
        #endregion

        private void textEditIconPath_EditValueChanged(object sender, EventArgs e)
        {
            IconPath = textEditIconPath.Text;
            UpdateImage(IconPath);
        }

        public void SetFocus()
        {
            textEditName.Select();
        }

    }
}
