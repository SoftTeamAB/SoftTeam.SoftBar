using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class AboutForm : DevExpress.XtraEditors.XtraForm
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            labelControlVersion.Text = "Version : " + Application.ProductVersion;
        }

        private void AboutForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hyperlinkLabelControlSoftTeam_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            Process.Start("http://www.softteam.se");
        }

        private void hyperlinkLabelControlGitHub_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            Process.Start("https://github.com/Hultan/SoftTeam.SoftBar");
        }
    }
}