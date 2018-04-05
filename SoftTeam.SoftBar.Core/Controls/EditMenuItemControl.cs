using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Forms;
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
        private bool _runAsAdministrator = false;
        private MenuItemInfoForm _infoForm = null;
        #endregion

        #region Properties
        public new string Name { get => _name; set => _name = value; }
        public string IconPath { get => _iconPath; set => _iconPath = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }
        public string ApplicationPath { get => _applicationPath; set => _applicationPath = value; }
        public string DocumentPath { get => _documentPath; set => _documentPath = value; }
        public string Parameters { get => _parameters; set => _parameters = value; }
        public bool RunAsAdministrator { get => _runAsAdministrator; set => _runAsAdministrator = value; }
        #endregion

        #region Constructor
        public EditMenuItemControl()
        {
            InitializeComponent();

            tabPaneMenuItem.SelectedPage = tabNavigationPageAppearance;
        }
        #endregion

        #region Misc functions
        public void LoadValues()
        {
            textEditName.Text = Name;
            textEditIconPath.Text = IconPath;
            checkEditBeginGroup.Checked = BeginGroup;
            checkEditRunAsAdministrator.Checked = RunAsAdministrator;

            textEditApplicationPath.Text = ApplicationPath;
            textEditDocumentPath.Text = DocumentPath;
            textEditParameters.Text = Parameters;

            UpdateImage();
        }

        public bool SaveValues(bool checkPaths = true)
        {
            Name = textEditName.Text;
            IconPath = textEditIconPath.Text;
            BeginGroup = checkEditBeginGroup.Checked;
            RunAsAdministrator = checkEditRunAsAdministrator.Checked;

            ApplicationPath = textEditApplicationPath.Text;
            DocumentPath = textEditDocumentPath.Text;
            Parameters = textEditParameters.Text;

            if (checkPaths)
            {
                if (string.IsNullOrEmpty(ApplicationPath) && string.IsNullOrEmpty(IconPath))
                {
                    DialogResult result = XtraMessageBox.Show("For this item to do anything, it need either an Application Path or an Document Path. Do you really want to save?", "Missing paths!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return false;
                }
            }

            return true;
        }

        private void UpdateImage()
        {
            pictureBoxIcon.Image = HelperFunctions.GetFileImage(textEditIconPath.Text, ImageSize.Medium_24x24);
        }
        #endregion

        #region Events
        private void simpleButtonIconPathBrowse_Click(object sender, EventArgs e)
        {
            openFileDialogMenuItem.InitialDirectory = textEditIconPath.Text;
            openFileDialogMenuItem.Filter = "Applications (*.exe;*.dll)|*.exe;*.dll|Bitmap images|*.bmp|GIF images|*.gif|JPEG images|*.jpg; *.jpeg; *.jpe; *.jif; *.jfif; *.jfi|PNG images|*.png|TIFF images|*.tiff; *.tif|All files|*.*";
            openFileDialogMenuItem.CheckFileExists = true;
            openFileDialogMenuItem.FilterIndex = 7;
            DialogResult result = openFileDialogMenuItem.ShowDialog();

            if (result == DialogResult.OK)
            {
                textEditIconPath.Text = openFileDialogMenuItem.FileName;
                UpdateImage();
            }
        }

        private void simpleButtonApplicationPathBrowse_Click(object sender, EventArgs e)
        {
            openFileDialogMenuItem.InitialDirectory = textEditApplicationPath.Text;
            openFileDialogMenuItem.Filter = "Applications (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialogMenuItem.CheckFileExists = true;
            openFileDialogMenuItem.FilterIndex = 0;
            DialogResult result = openFileDialogMenuItem.ShowDialog();

            if (result == DialogResult.OK)
            {
                textEditApplicationPath.Text = openFileDialogMenuItem.FileName;
            }
        }

        private void simpleButtonDocumentPathBrowse_Click(object sender, EventArgs e)
        {
            openFileDialogMenuItem.InitialDirectory = textEditDocumentPath.Text;
            openFileDialogMenuItem.Filter = "All files (*.*)|*.*";
            openFileDialogMenuItem.CheckFileExists = true;
            openFileDialogMenuItem.FilterIndex = 0;
            DialogResult result = openFileDialogMenuItem.ShowDialog();

            if (result == DialogResult.OK)
                textEditDocumentPath.Text = openFileDialogMenuItem.FileName;
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

        private void pictureBoxMenuItemInfo_MouseEnter(object sender, EventArgs e)
        {
            _infoForm = new MenuItemInfoForm();
            _infoForm.Show();

            var location = this.ParentForm.PointToScreen(pictureBoxMenuItemInfo.Location);
            var left = location.X - _infoForm.Width;
            var top = location.Y + pictureBoxMenuItemInfo.Height;

            _infoForm.Location = new Point(left, top);
        }

        private void pictureBoxMenuItemInfo_MouseLeave(object sender, EventArgs e)
        {
            _infoForm.Close();
            _infoForm.Dispose();
            _infoForm = null;
        }

        private void simpleButtonTest_Click(object sender, EventArgs e)
        {
            SaveValues(false);

            if (!File.Exists(ApplicationPath))
                XtraMessageBox.Show("WARNING : Application not found!");
            if (!File.Exists(DocumentPath))
                XtraMessageBox.Show("WARNING : Document not found!");

            using (CommandLineHelper cmd = new CommandLineHelper(ApplicationPath, DocumentPath, Parameters, RunAsAdministrator))
                cmd.Execute();
        }

        private void simpleButtonImport_Click(object sender, EventArgs e)
        {
            openFileDialogMenuItem.InitialDirectory = (Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
            openFileDialogMenuItem.Filter = "Link files (*.lnk)|*.lnk|All files (*.*)|*.*";
            openFileDialogMenuItem.CheckFileExists = true;
            openFileDialogMenuItem.FilterIndex = 0;
            DialogResult result = openFileDialogMenuItem.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (System.IO.File.Exists(openFileDialogMenuItem.FileName))
                {
                    string directory = Path.GetDirectoryName(openFileDialogMenuItem.FileName);
                    string file = Path.GetFileName(openFileDialogMenuItem.FileName);
                    string name = Path.GetFileNameWithoutExtension(openFileDialogMenuItem.FileName);

                    Shell32.Shell shell = new Shell32.Shell();
                    Shell32.Folder folder = shell.NameSpace(directory);
                    Shell32.FolderItem folderItem = folder.ParseName(file);

                    Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;

                    textEditName.Text = name;
                    textEditIconPath.Text = link.Path;
                    textEditApplicationPath.Text = link.Path;
                }
            }
        }
        #endregion

        public void SetFocus()
        {
            textEditName.Select();
        }

    }
}
