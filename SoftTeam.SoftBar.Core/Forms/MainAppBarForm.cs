using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.SoftBar;
using SoftTeam.SoftBar.Core.Xml;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class MainAppBarForm : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        private SoftBarManager _manager = null;

        private static int WM_HOTKEY = 0x0312;
        #endregion

        #region Properties
        public SoftBarManager Manager { get => _manager; set => _manager = value; }
        #endregion

        #region Constructor
        public MainAppBarForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void MainAppBarForm_Load(object sender, EventArgs e)
        {
            bool exit = false;
            bool newUser = false;
            UserTypeEnum userType = UserTypeEnum.None;

            // Get the path for the xml file
            var path = HelperFunctions.GetWorkingDirectory();

            // First time user
            if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(System.IO.Path.Combine(path, "menu.xml")))
            {
                using (StartupForm form = new StartupForm())
                {
                    form.ShowDialog();

                    userType = form.UserType;

                    switch (userType)
                    {
                        case UserTypeEnum.None:
                            exit = true;
                            break;
                        case UserTypeEnum.FirstTimeUser:
                            newUser = true;
                            path = ChooseWorkingDirectory();
                            break;
                        case UserTypeEnum.PHSAppBarUser:
                            newUser = true;
                            path = ChooseWorkingDirectory();
                            var success = ImportFromPHSAppBar(path);
                            if (!success)
                                exit = true;
                            break;
                        case UserTypeEnum.Wizard:
                            var fileName = ChooseMenuXmlPath();
                            if (string.IsNullOrEmpty(fileName))
                                exit = true;
                            else
                                path = System.IO.Path.GetDirectoryName(fileName);
                            break;
                    }
                }
            }

            if (string.IsNullOrEmpty(path))
                exit = true;

            // If the user has cancelled the initial dialogs, let's quit...
            if (exit)
            {
                this.Close();
                return;
            }

            // Save the path (working folder) for the xml file
            if (HelperFunctions.GetWorkingDirectory() != path)
                HelperFunctions.SetWorkingDirectory(path);

            // Create the app bar from XML
            _manager = new SoftBarManager(this, path);
            _manager.ToolTipController = toolTipControllerSoftBar;

            if (newUser)
            {
                var header = $"SoftBar - New user";
                var message = $"Since you are a new SoftBar user, it is recommended" + Environment.NewLine +
                              "that you check out <b>SoftBar/Settings</b> to set up <b>SoftBar</b>," + Environment.NewLine +
                              "and <b>SoftBar/Customize</b> to create your own menus!";
                XtraMessageBox.Show(message, header, MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);
            }
        }

        private void MainAppBarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _manager.HotkeyManager.UnregisterHotKeys();
            _manager.ApplicationBarManager.UnregisterApplicationBar();
        }

        private void MainAppBarForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                // Help page
                Process.Start("Http://www.softteam.se/softbar");
            }
        }
        #endregion

        #region Misc functions
        private bool ImportFromPHSAppBar(string workingDirectory)
        {
            openFileDialogSoftBar.FileName = "Config.ini";
            openFileDialogSoftBar.CheckFileExists = true;
            openFileDialogSoftBar.Title = "Open PHSAppBar config.ini";
            DialogResult result = openFileDialogSoftBar.ShowDialog();
            if (result == DialogResult.Cancel)
                return false;

            // Import from PHSAppBar config.ini
            XmlArea area = null;
            using (PHSAppBarImporter importer = new PHSAppBarImporter(openFileDialogSoftBar.FileName))
                area = importer.Import();

            // Save xml
            using (XmlSaver saver = new XmlSaver(area, System.IO.Path.Combine(workingDirectory, "menu.xml")))
                saver.Save();

            return true;
        }

        private string ChooseMenuXmlPath()
        {
            openFileDialogSoftBar.FileName = "menu.xml";
            openFileDialogSoftBar.CheckFileExists = true;
            openFileDialogSoftBar.Title = "Open SoftBarmenu.xml";
            DialogResult result = openFileDialogSoftBar.ShowDialog();

            if (result == DialogResult.Cancel)
                return "";
            else
                return openFileDialogSoftBar.FileName;
        }

        private string ChooseWorkingDirectory()
        {
            using (ChooseDirectoryForm form = new ChooseDirectoryForm())
            {
                form.ShowDialog();

                return form.Path;
            }
        }
        #endregion

        #region Overrides
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            // Process application bar messages
            _manager?.ApplicationBarManager?.ProcessApplicationBarMessages(ref m);            

            // Process hotkey messages
            if (m.Msg == WM_HOTKEY)
                _manager.HotkeyManager.ProcessHotKeys(ref m, MousePosition);
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= (~0x00C00000); // WS_CAPTION
                cp.Style &= (~0x00800000); // WS_BORDER
                cp.ExStyle = 0x00000080 | 0x00000008; // WS_EX_TOOLWINDOW | WS_EX_TOPMOST
                return cp;
            }
        }
        #endregion
    }
}