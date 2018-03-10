using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core;

namespace SoftTeam.SoftBar
{
    public partial class MainAppBarForm : DevExpress.XtraEditors.XtraForm
    {
        public MainAppBarForm()
        {
            InitializeComponent();

            // Set up the app bar at the top of the screen
            AppBarFunctions.SetAppBar(this, AppBarEdge.Top);
            // Create the app bar from XML
            SoftBarManager bar = new SoftBarManager(this, @"c:\temp\menu.xml");
        }

        private void MainAppBarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Remove the app bar when the form closes
            AppBarFunctions.SetAppBar(this, AppBarEdge.None);
        }

        private void MainAppBarForm_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder3D(e.Graphics, ((Control)sender).ClientRectangle, Border3DStyle.RaisedOuter);
        }
    }
}