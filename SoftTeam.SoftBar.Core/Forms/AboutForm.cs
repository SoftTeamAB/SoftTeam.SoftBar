using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

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