namespace SoftTeam.SoftBar.Core.Forms
{
    partial class StartupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            this.simpleButtonFirstTimeUser = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonWizard = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonPHSAppBarUser = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // simpleButtonFirstTimeUser
            // 
            this.simpleButtonFirstTimeUser.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonFirstTimeUser.Appearance.Options.UseFont = true;
            this.simpleButtonFirstTimeUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonFirstTimeUser.ImageOptions.Image")));
            this.simpleButtonFirstTimeUser.Location = new System.Drawing.Point(12, 12);
            this.simpleButtonFirstTimeUser.Name = "simpleButtonFirstTimeUser";
            this.simpleButtonFirstTimeUser.Size = new System.Drawing.Size(342, 107);
            toolTipTitleItem1.Text = "I am a First time user!";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Click this if you are a completely new user.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.simpleButtonFirstTimeUser.SuperTip = superToolTip1;
            this.simpleButtonFirstTimeUser.TabIndex = 0;
            this.simpleButtonFirstTimeUser.Text = "I am a first time user!";
            this.simpleButtonFirstTimeUser.Click += new System.EventHandler(this.simpleButtonFirstTimeUser_Click);
            // 
            // simpleButtonWizard
            // 
            this.simpleButtonWizard.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonWizard.Appearance.Options.UseFont = true;
            this.simpleButtonWizard.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonWizard.ImageOptions.Image")));
            this.simpleButtonWizard.Location = new System.Drawing.Point(12, 238);
            this.simpleButtonWizard.Name = "simpleButtonWizard";
            this.simpleButtonWizard.Size = new System.Drawing.Size(342, 107);
            toolTipTitleItem2.Text = "I already have a menu.xml!";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Click this if you are an experienced SoftBar user and already have a menu.xml fil" +
    "e that you want to use.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.simpleButtonWizard.SuperTip = superToolTip2;
            this.simpleButtonWizard.TabIndex = 1;
            this.simpleButtonWizard.Text = "I already have a menu.xml!";
            this.simpleButtonWizard.Click += new System.EventHandler(this.simpleButtonWizard_Click);
            // 
            // simpleButtonPHSAppBarUser
            // 
            this.simpleButtonPHSAppBarUser.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonPHSAppBarUser.Appearance.Options.UseFont = true;
            this.simpleButtonPHSAppBarUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButtonPHSAppBarUser.Location = new System.Drawing.Point(12, 125);
            this.simpleButtonPHSAppBarUser.Name = "simpleButtonPHSAppBarUser";
            this.simpleButtonPHSAppBarUser.Size = new System.Drawing.Size(342, 107);
            toolTipTitleItem3.Text = "I already use PHS AppBar!";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Click this if your name is Paul and you have an old PHS AppBar config.ini file th" +
    "at you want to convert.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.simpleButtonPHSAppBarUser.SuperTip = superToolTip3;
            this.simpleButtonPHSAppBarUser.TabIndex = 2;
            this.simpleButtonPHSAppBarUser.Text = "I already use PHS AppBar!";
            this.simpleButtonPHSAppBarUser.Click += new System.EventHandler(this.simpleButtonPHSAppBarUser_Click);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 357);
            this.Controls.Add(this.simpleButtonPHSAppBarUser);
            this.Controls.Add(this.simpleButtonWizard);
            this.Controls.Add(this.simpleButtonFirstTimeUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Who are you?";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonFirstTimeUser;
        private DevExpress.XtraEditors.SimpleButton simpleButtonWizard;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPHSAppBarUser;
    }
}