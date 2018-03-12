using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core;
using SoftTeam.SoftBar.Core.Misc;

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
            var path = Core.Properties.Settings.Default.SoftBarXmlPath;

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
                            break;
                        case UserTypeEnum.Wizard:
                            xtraOpenFileDialogSoftBar.FileName = "menu.xml";
                            xtraOpenFileDialogSoftBar.CheckFileExists = true;
                            xtraOpenFileDialogSoftBar.Title = "Open menu.xml";
                            DialogResult result = xtraOpenFileDialogSoftBar.ShowDialog();

                            if (result == DialogResult.Cancel)
                                exit = true;

                            path = xtraOpenFileDialogSoftBar.FileName;
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
            SoftBarManager bar = new SoftBarManager(this, path);

            if (firstTimeUser)
            {
                using (CustomizationForm form = new CustomizationForm(bar, path))
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
    }
}