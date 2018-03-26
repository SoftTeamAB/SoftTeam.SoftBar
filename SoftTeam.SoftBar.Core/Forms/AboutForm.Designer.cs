namespace SoftTeam.SoftBar.Core.Forms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.labelControlSoftBar = new DevExpress.XtraEditors.LabelControl();
            this.labelControlVersion = new DevExpress.XtraEditors.LabelControl();
            this.labelControlClose = new DevExpress.XtraEditors.LabelControl();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.hyperlinkLabelControlSoftTeam = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.hyperlinkLabelControlGitHub = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControlSoftBar
            // 
            this.labelControlSoftBar.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlSoftBar.Appearance.Options.UseFont = true;
            this.labelControlSoftBar.Appearance.Options.UseTextOptions = true;
            this.labelControlSoftBar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlSoftBar.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlSoftBar.Location = new System.Drawing.Point(12, 9);
            this.labelControlSoftBar.Name = "labelControlSoftBar";
            this.labelControlSoftBar.Size = new System.Drawing.Size(260, 46);
            this.labelControlSoftBar.TabIndex = 0;
            this.labelControlSoftBar.Text = "SoftBar";
            this.labelControlSoftBar.Click += new System.EventHandler(this.AboutForm_Click);
            // 
            // labelControlVersion
            // 
            this.labelControlVersion.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlVersion.Appearance.Options.UseFont = true;
            this.labelControlVersion.Appearance.Options.UseTextOptions = true;
            this.labelControlVersion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlVersion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlVersion.Location = new System.Drawing.Point(12, 61);
            this.labelControlVersion.Name = "labelControlVersion";
            this.labelControlVersion.Size = new System.Drawing.Size(260, 25);
            this.labelControlVersion.TabIndex = 1;
            this.labelControlVersion.Text = "labelControl2";
            this.labelControlVersion.Click += new System.EventHandler(this.AboutForm_Click);
            // 
            // labelControlClose
            // 
            this.labelControlClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlClose.Appearance.Options.UseFont = true;
            this.labelControlClose.Appearance.Options.UseTextOptions = true;
            this.labelControlClose.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControlClose.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlClose.Location = new System.Drawing.Point(-1, 152);
            this.labelControlClose.Name = "labelControlClose";
            this.labelControlClose.Size = new System.Drawing.Size(283, 20);
            this.labelControlClose.TabIndex = 2;
            this.labelControlClose.Text = "Click anywhere to close...";
            this.labelControlClose.Click += new System.EventHandler(this.AboutForm_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 8);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxLogo.TabIndex = 3;
            this.pictureBoxLogo.TabStop = false;
            // 
            // hyperlinkLabelControlSoftTeam
            // 
            this.hyperlinkLabelControlSoftTeam.Appearance.Options.UseTextOptions = true;
            this.hyperlinkLabelControlSoftTeam.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hyperlinkLabelControlSoftTeam.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.hyperlinkLabelControlSoftTeam.Cursor = System.Windows.Forms.Cursors.Default;
            this.hyperlinkLabelControlSoftTeam.Location = new System.Drawing.Point(12, 92);
            this.hyperlinkLabelControlSoftTeam.Name = "hyperlinkLabelControlSoftTeam";
            this.hyperlinkLabelControlSoftTeam.Size = new System.Drawing.Size(260, 13);
            this.hyperlinkLabelControlSoftTeam.TabIndex = 4;
            this.hyperlinkLabelControlSoftTeam.Text = "http://www.softteam.se";
            this.hyperlinkLabelControlSoftTeam.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.hyperlinkLabelControlSoftTeam_HyperlinkClick);
            // 
            // hyperlinkLabelControlGitHub
            // 
            this.hyperlinkLabelControlGitHub.Appearance.Options.UseTextOptions = true;
            this.hyperlinkLabelControlGitHub.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hyperlinkLabelControlGitHub.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.hyperlinkLabelControlGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hyperlinkLabelControlGitHub.Location = new System.Drawing.Point(12, 111);
            this.hyperlinkLabelControlGitHub.Name = "hyperlinkLabelControlGitHub";
            this.hyperlinkLabelControlGitHub.Size = new System.Drawing.Size(260, 13);
            this.hyperlinkLabelControlGitHub.TabIndex = 5;
            this.hyperlinkLabelControlGitHub.Text = "https://github.com/Hultan/SoftTeam.SoftBar";
            this.hyperlinkLabelControlGitHub.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.hyperlinkLabelControlGitHub_HyperlinkClick);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 172);
            this.Controls.Add(this.hyperlinkLabelControlGitHub);
            this.Controls.Add(this.hyperlinkLabelControlSoftTeam);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelControlClose);
            this.Controls.Add(this.labelControlVersion);
            this.Controls.Add(this.labelControlSoftBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About SoftBar";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.Click += new System.EventHandler(this.AboutForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControlSoftBar;
        private DevExpress.XtraEditors.LabelControl labelControlVersion;
        private DevExpress.XtraEditors.LabelControl labelControlClose;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private DevExpress.XtraEditors.HyperlinkLabelControl hyperlinkLabelControlSoftTeam;
        private DevExpress.XtraEditors.HyperlinkLabelControl hyperlinkLabelControlGitHub;
    }
}