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

            // Get the path for the xml file
            var path = Core.Properties.Settings.Default.SoftBarXmlPath;
            // If the user has cancelled the initial dialogs, let's quit...
            if (exit)
            {
                this.Close();
                return;
            }

            // Set up the app bar at the top of the screen
            AppBarFunctions.SetAppBar(this, AppBarEdge.Top);

            // Create the app bar from XML
            BarManager bar = new BarManager(this, path);

        }

        private void MainAppBarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppBarFunctions.Edge != AppBarEdge.None)
                // Remove the app bar when the form closes
                AppBarFunctions.SetAppBar(this, AppBarEdge.None);
        }
    }
}