using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.SoftBar;
using SoftTeam.SoftBar.Core.Xml;
using static SoftTeam.SoftBar.Core.AppBarFunctions;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class MainAppBarForm : DevExpress.XtraEditors.XtraForm
    {
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        public MainAppBarForm()
        {
            InitializeComponent();

            IntPtr hWnd = this.Handle;            
            PostMessage(hWnd, (int)Interop.ABNotify.ABN_STATECHANGE, IntPtr.Zero, IntPtr.Zero);
        }

        private void MainAppBarForm_Load(object sender, EventArgs e)
        {
            bool exit = false;
            bool newUser = false;
            UserTypeEnum userType = UserTypeEnum.None;

            // Get the path for the xml file
            var path = HelperFunctions.GetWorkingDirectory();

            // First time user
            if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(System.IO.Path.Combine(path,"menu.xml")))
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

            // Set up the app bar at the top of the screen
            AppBarFunctions.SetAppBar(this, AppBarEdge.Top);

            // Save the path (working folder) for the xml file
            if (HelperFunctions.GetWorkingDirectory() != path)
                HelperFunctions.SetWorkingDirectory(path);

            // Create the app bar from XML
            SoftBarManager manager = new SoftBarManager(this, path);

            if (newUser)
            {
                var header = $"SoftBar - New user";
                var message = $"Since you are a new SoftBar user, it is recommended" + Environment.NewLine +
                              "that you check out <b>System/Settings</b> to set up <b>SoftBar</b>," + Environment.NewLine +
                              "and <b>System/Customize</b> to create your own menus!"; 
                XtraMessageBox.Show(message, header, MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);
            }
        }

        private bool ImportFromPHSAppBar(string workingDirectory)
        {
            xtraOpenFileDialogSoftBar.FileName = "Config.ini";
            xtraOpenFileDialogSoftBar.CheckFileExists = true;
            xtraOpenFileDialogSoftBar.Title = "Open PHSAppBar config.ini";
            DialogResult result = xtraOpenFileDialogSoftBar.ShowDialog();
            if (result == DialogResult.Cancel)
                return false;

            // Import from PHSAppBar config.ini
            XmlArea area = null;
            using (PHSAppBarImporter importer = new PHSAppBarImporter(xtraOpenFileDialogSoftBar.FileName))
                area = importer.Import();

            // Save xml
            using (XmlSaver saver = new XmlSaver(area, System.IO.Path.Combine(workingDirectory, "menu.xml")))
                saver.Save();

            return true;
        }

        private string ChooseMenuXmlPath()
        {
            xtraOpenFileDialogSoftBar.FileName = "menu.xml";
            xtraOpenFileDialogSoftBar.CheckFileExists = true;
            xtraOpenFileDialogSoftBar.Title = "Open SoftBarmenu.xml";
            DialogResult result = xtraOpenFileDialogSoftBar.ShowDialog();

            if (result == DialogResult.Cancel)
                return "";
            else
                return xtraOpenFileDialogSoftBar.FileName;
        }

        private void MainAppBarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppBarFunctions.Edge != AppBarEdge.None)
                // Remove the app bar when the form closes
                AppBarFunctions.SetAppBar(this, AppBarEdge.None);
        }

        private string ChooseWorkingDirectory()
        {
            using (ChooseDirectoryForm form = new ChooseDirectoryForm())
            {
                form.ShowDialog();

                return form.Path;
            }
        }

        protected override void WndProc(ref Message msg)
        {
            RegisterInfo info = AppBarFunctions.GetRegisterInfo(this);
            bool handled = false;
            info.WndProc(msg.HWnd, msg.Msg, msg.WParam, msg.LParam, ref handled);

            //if (msg.Msg == (int)Interop.ABNotify.ABN_STATECHANGE)
            //    Console.WriteLine("ABN_STATECHANGE");
            //if (msg.Msg == (int)Interop.ABNotify.ABN_FULLSCREENAPP)
            //    Console.WriteLine("ABN_FULLSCREENAPP");
            //if (msg.Msg == (int)Interop.ABNotify.ABN_POSCHANGED)
            //    Console.WriteLine("ABN_POSCHANGED");

            base.WndProc(ref msg);
        }
    }
}