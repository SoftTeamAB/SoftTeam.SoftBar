using System;
using System.Windows.Forms;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.SoftBar;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class MainAppBarForm : DevExpress.XtraEditors.XtraForm
    {
        

        public MainAppBarForm()
        {
            InitializeComponent();
        }

        private void MainAppBarForm_Load(object sender, EventArgs e)
        {
            bool exit = false;
            bool firstTimeUser = false;

            // Get the path for the xml file
            var path = Core.Properties.Settings.Default.SoftBarPath;

            // First time user
            if (string.IsNullOrEmpty(path))
            {
                using (StartupForm form = new StartupForm())
                {
                    form.ShowDialog();

                    switch (form.UserType)
                    {
                        case UserTypeEnum.None:
                            exit = true;
                            break;
                        case UserTypeEnum.FirstTimeUser:
                            firstTimeUser = true;
                            path = ChooseWorkingDirectory();
                            break;
                        case UserTypeEnum.PHSAppBarUser:
                            // ToDo : Import from PHS AppBar
                            path = ChooseWorkingDirectory();
                            break;
                        case UserTypeEnum.Wizard:
                            xtraOpenFileDialogSoftBar.FileName = "menu.xml";
                            xtraOpenFileDialogSoftBar.CheckFileExists = true;
                            xtraOpenFileDialogSoftBar.Title = "Open menu.xml";
                            DialogResult result = xtraOpenFileDialogSoftBar.ShowDialog();

                            if (result == DialogResult.Cancel)
                                exit = true;

                            path = System.IO.Path.GetDirectoryName(xtraOpenFileDialogSoftBar.FileName);
                            break;
                    }
                }
            }

            // If the user has cancelled the initial dialogs, let's quit...
            if (exit)
            {
                this.Close();
                return;
            }

            // Set up the app bar at the top of the screen
            AppBarFunctions.SetAppBar(this, AppBarEdge.Top);

            // Create the app bar from XML
            SoftBarManager manager = new SoftBarManager(this, path);

            if (firstTimeUser)
            {
                using (CustomizationForm form = new CustomizationForm(manager))
                {
                    form.ShowDialog();
                }
            }

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
    }
}