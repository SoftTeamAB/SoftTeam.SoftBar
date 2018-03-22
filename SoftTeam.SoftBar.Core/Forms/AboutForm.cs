using System;
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
    }
}