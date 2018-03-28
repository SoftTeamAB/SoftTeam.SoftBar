using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
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
            xtraOpenFileDialogEditMenu.InitialDirectory = textEditIconPath.Text;
            xtraOpenFileDialogEditMenu.Filter = "Applications (*.exe;*.dll)|*.exe;*.dll";
            xtraOpenFileDialogEditMenu.CheckFileExists = true;
            xtraOpenFileDialogEditMenu.FilterIndex = 0;
            DialogResult result = xtraOpenFileDialogEditMenu.ShowDialog();

            if (result == DialogResult.OK)
            {
                textEditIconPath.Text = xtraOpenFileDialogEditMenu.FileName;
                UpdateImage(xtraOpenFileDialogEditMenu.FileName);
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
    }
}
