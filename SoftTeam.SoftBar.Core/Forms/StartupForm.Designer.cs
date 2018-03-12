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
            this.simpleButtonFirstTimeUser = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonWizard = new DevExpress.XtraEditors.SimpleButton();
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
            this.simpleButtonFirstTimeUser.TabIndex = 0;
            this.simpleButtonFirstTimeUser.Text = "I am a first time user!";
            this.simpleButtonFirstTimeUser.Click += new System.EventHandler(this.simpleButtonFirstTimeUser_Click);
            // 
            // simpleButtonWizard
            // 
            this.simpleButtonWizard.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonWizard.Appearance.Options.UseFont = true;
            this.simpleButtonWizard.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButtonWizard.Location = new System.Drawing.Point(12, 125);
            this.simpleButtonWizard.Name = "simpleButtonWizard";
            this.simpleButtonWizard.Size = new System.Drawing.Size(342, 107);
            this.simpleButtonWizard.TabIndex = 1;
            this.simpleButtonWizard.Text = "I already have a menu.xml!";
            this.simpleButtonWizard.Click += new System.EventHandler(this.simpleButtonWizard_Click);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 244);
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
    }
}