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
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class StartupForm : DevExpress.XtraEditors.XtraForm
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        public UserTypeEnum UserType { get; set; } = UserTypeEnum.None;

        private void simpleButtonFirstTimeUser_Click(object sender, EventArgs e)
        {
            UserType = UserTypeEnum.FirstTimeUser;
            this.Close();
        }

        private void simpleButtonWizard_Click(object sender, EventArgs e)
        {
            UserType = UserTypeEnum.Wizard;
            this.Close();
        }

        private void simpleButtonPHSAppBarUser_Click(object sender, EventArgs e)
        {
            UserType = UserTypeEnum.PHSAppBarUser;
            this.Close();
        }
    }
}