namespace SoftTeam.SoftBar.Core.Forms
{
    partial class ChooseDirectoryForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseDirectoryForm));
            this.radioGroupChooseDirectory = new DevExpress.XtraEditors.RadioGroup();
            this.labelControlHeader = new DevExpress.XtraEditors.LabelControl();
            this.labelControlChoosenDirectory = new DevExpress.XtraEditors.LabelControl();
            this.xtraFolderBrowserDialogSoftBar = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.simpleButtonChooseDirectory = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupChooseDirectory.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroupChooseDirectory
            // 
            this.radioGroupChooseDirectory.Location = new System.Drawing.Point(21, 49);
            this.radioGroupChooseDirectory.Name = "radioGroupChooseDirectory";
            this.radioGroupChooseDirectory.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "%HOMEPATH%\\AppData\\Local\\SoftTeam AB\\SoftBar"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Choose your own directory")});
            this.radioGroupChooseDirectory.Size = new System.Drawing.Size(315, 62);
            this.radioGroupChooseDirectory.TabIndex = 0;
            this.radioGroupChooseDirectory.SelectedIndexChanged += new System.EventHandler(this.radioGroupChooseDirectory_SelectedIndexChanged);
            // 
            // labelControlHeader
            // 
            this.labelControlHeader.Appearance.Options.UseTextOptions = true;
            this.labelControlHeader.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControlHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlHeader.Location = new System.Drawing.Point(21, 12);
            this.labelControlHeader.Name = "labelControlHeader";
            this.labelControlHeader.Size = new System.Drawing.Size(315, 31);
            this.labelControlHeader.TabIndex = 1;
            this.labelControlHeader.Text = "Please choose the SoftBar working directory, where all the settings will be store" +
    "d and backup:ed:";
            // 
            // labelControlChoosenDirectory
            // 
            this.labelControlChoosenDirectory.Location = new System.Drawing.Point(21, 163);
            this.labelControlChoosenDirectory.Name = "labelControlChoosenDirectory";
            this.labelControlChoosenDirectory.Size = new System.Drawing.Size(63, 13);
            this.labelControlChoosenDirectory.TabIndex = 2;
            this.labelControlChoosenDirectory.Text = "labelControl1";
            // 
            // xtraFolderBrowserDialogSoftBar
            // 
            this.xtraFolderBrowserDialogSoftBar.SelectedPath = "xtraFolderBrowserDialog1";
            // 
            // simpleButtonChooseDirectory
            // 
            this.simpleButtonChooseDirectory.Enabled = false;
            this.simpleButtonChooseDirectory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonChooseDirectory.ImageOptions.Image")));
            this.simpleButtonChooseDirectory.Location = new System.Drawing.Point(21, 117);
            this.simpleButtonChooseDirectory.Name = "simpleButtonChooseDirectory";
            this.simpleButtonChooseDirectory.Size = new System.Drawing.Size(90, 40);
            this.simpleButtonChooseDirectory.TabIndex = 3;
            this.simpleButtonChooseDirectory.Text = "Directory";
            this.simpleButtonChooseDirectory.Click += new System.EventHandler(this.simpleButtonChooseDirectory_Click);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButtonCancel.Location = new System.Drawing.Point(246, 183);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(90, 40);
            this.simpleButtonCancel.TabIndex = 4;
            this.simpleButtonCancel.Text = "Cancel";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButtonSave.Location = new System.Drawing.Point(150, 183);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(90, 40);
            this.simpleButtonSave.TabIndex = 5;
            this.simpleButtonSave.Text = "Save";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // ChooseDirectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 235);
            this.Controls.Add(this.simpleButtonSave);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonChooseDirectory);
            this.Controls.Add(this.labelControlChoosenDirectory);
            this.Controls.Add(this.labelControlHeader);
            this.Controls.Add(this.radioGroupChooseDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseDirectoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoftBar working directory";
            this.Load += new System.EventHandler(this.ChooseDirectoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupChooseDirectory.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroupChooseDirectory;
        private DevExpress.XtraEditors.LabelControl labelControlHeader;
        private DevExpress.XtraEditors.LabelControl labelControlChoosenDirectory;
        private DevExpress.XtraEditors.XtraFolderBrowserDialog xtraFolderBrowserDialogSoftBar;
        private DevExpress.XtraEditors.SimpleButton simpleButtonChooseDirectory;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
    }
}