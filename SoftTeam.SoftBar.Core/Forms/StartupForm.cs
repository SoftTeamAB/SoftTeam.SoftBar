using System;
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class StartupForm : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        public UserTypeEnum UserType { get; set; } = UserTypeEnum.None;
        #endregion

        #region Constructor
        public StartupForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
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
        #endregion
    }
}