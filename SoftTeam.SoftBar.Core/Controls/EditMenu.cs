using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Extensions;

namespace SoftTeam.SoftBar.Core.Controls
{
    public partial class EditMenu : DevExpress.XtraEditors.XtraUserControl
    {
        private string _name = "";
        private string _iconPath = "";
        private bool _beginGroup = false;

        public new string Name { get => _name; set => _name = value; }
        public string IconPath { get => _iconPath; set => _iconPath = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }

        public EditMenu()
        {
            InitializeComponent();
        }

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
    }
}
