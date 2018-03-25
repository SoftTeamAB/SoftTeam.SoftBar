using System;
using System.Windows.Forms;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.SoftBar;
using SoftTeam.SoftBar.Core.Xml;

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
            bool showCustomizationForm = false;
            UserTypeEnum userType = UserTypeEnum.None;

            // Get the path for the xml file
            var path = Core.Properties.Settings.Default.SoftBarPath;

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
                            showCustomizationForm = true;
                            path = ChooseWorkingDirectory();
                            break;
                        case UserTypeEnum.PHSAppBarUser:
                            showCustomizationForm = true;
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
            if (Core.Properties.Settings.Default.SoftBarPath != path)
            {
                Core.Properties.Settings.Default.SoftBarPath = path;
                Core.Properties.Settings.Default.Save();
            }

            // Create the app bar from XML
            SoftBarManager manager = new SoftBarManager(this, path);

            if (showCustomizationForm)
            {
                using (CustomizationForm form = new CustomizationForm(manager))
                {
                    form.ShowDialog();
                }
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
    }
}