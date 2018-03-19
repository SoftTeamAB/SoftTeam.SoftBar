namespace SoftTeam.SoftBar.Core.Forms
{
    partial class MyDirectoryForm
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
            this.textEditPath = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonBrowsePath = new DevExpress.XtraEditors.SimpleButton();
            this.xtraFolderBrowserDialogMyDirectory = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.labelControPath = new DevExpress.XtraEditors.LabelControl();
            this.labelControlName = new DevExpress.XtraEditors.LabelControl();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonBrowseIconPath = new DevExpress.XtraEditors.SimpleButton();
            this.textEditIconPath = new DevExpress.XtraEditors.TextEdit();
            this.checkEditBegingGroup = new DevExpress.XtraEditors.CheckEdit();
            this.labelControlBeginGroup = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIconPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBegingGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditPath
            // 
            this.textEditPath.Location = new System.Drawing.Point(29, 80);
            this.textEditPath.Name = "textEditPath";
            this.textEditPath.Size = new System.Drawing.Size(232, 20);
            this.textEditPath.TabIndex = 0;
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSave.Location = new System.Drawing.Point(156, 199);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(75, 32);
            this.simpleButtonSave.TabIndex = 1;
            this.simpleButtonSave.Text = "Save";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.Location = new System.Drawing.Point(237, 199);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 32);
            this.simpleButtonCancel.TabIndex = 2;
            this.simpleButtonCancel.Text = "Cancel";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonBrowsePath
            // 
            this.simpleButtonBrowsePath.Location = new System.Drawing.Point(272, 78);
            this.simpleButtonBrowsePath.Name = "simpleButtonBrowsePath";
            this.simpleButtonBrowsePath.Size = new System.Drawing.Size(26, 23);
            this.simpleButtonBrowsePath.TabIndex = 3;
            this.simpleButtonBrowsePath.Text = "...";
            this.simpleButtonBrowsePath.Click += new System.EventHandler(this.simpleButtonBrowsePath_Click);
            // 
            // xtraFolderBrowserDialogMyDirectory
            // 
            this.xtraFolderBrowserDialogMyDirectory.SelectedPath = "xtraFolderBrowserDialog1";
            // 
            // labelControPath
            // 
            this.labelControPath.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControPath.Appearance.Options.UseFont = true;
            this.labelControPath.Location = new System.Drawing.Point(29, 61);
            this.labelControPath.Name = "labelControPath";
            this.labelControPath.Size = new System.Drawing.Size(32, 13);
            this.labelControPath.TabIndex = 4;
            this.labelControPath.Text = "Path :";
            // 
            // labelControlName
            // 
            this.labelControlName.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlName.Appearance.Options.UseFont = true;
            this.labelControlName.Location = new System.Drawing.Point(29, 16);
            this.labelControlName.Name = "labelControlName";
            this.labelControlName.Size = new System.Drawing.Size(38, 13);
            this.labelControlName.TabIndex = 6;
            this.labelControlName.Text = "Name :";
            // 
            // textEditName
            // 
            this.textEditName.Location = new System.Drawing.Point(29, 35);
            this.textEditName.Name = "textEditName";
            this.textEditName.Size = new System.Drawing.Size(232, 20);
            this.textEditName.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(29, 106);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Icon path :";
            // 
            // simpleButtonBrowseIconPath
            // 
            this.simpleButtonBrowseIconPath.Location = new System.Drawing.Point(272, 123);
            this.simpleButtonBrowseIconPath.Name = "simpleButtonBrowseIconPath";
            this.simpleButtonBrowseIconPath.Size = new System.Drawing.Size(26, 23);
            this.simpleButtonBrowseIconPath.TabIndex = 8;
            this.simpleButtonBrowseIconPath.Text = "...";
            this.simpleButtonBrowseIconPath.Click += new System.EventHandler(this.simpleButtonBrowseIconPath_Click);
            // 
            // textEditIconPath
            // 
            this.textEditIconPath.Location = new System.Drawing.Point(29, 125);
            this.textEditIconPath.Name = "textEditIconPath";
            this.textEditIconPath.Size = new System.Drawing.Size(232, 20);
            this.textEditIconPath.TabIndex = 7;
            // 
            // checkEditBegingGroup
            // 
            this.checkEditBegingGroup.Location = new System.Drawing.Point(29, 170);
            this.checkEditBegingGroup.Name = "checkEditBegingGroup";
            this.checkEditBegingGroup.Properties.Caption = "Begin group";
            this.checkEditBegingGroup.Size = new System.Drawing.Size(232, 19);
            this.checkEditBegingGroup.TabIndex = 10;
            // 
            // labelControlBeginGroup
            // 
            this.labelControlBeginGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlBeginGroup.Appearance.Options.UseFont = true;
            this.labelControlBeginGroup.Location = new System.Drawing.Point(29, 151);
            this.labelControlBeginGroup.Name = "labelControlBeginGroup";
            this.labelControlBeginGroup.Size = new System.Drawing.Size(73, 13);
            this.labelControlBeginGroup.TabIndex = 11;
            this.labelControlBeginGroup.Text = "Begin group :";
            // 
            // MyDirectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 243);
            this.Controls.Add(this.labelControlBeginGroup);
            this.Controls.Add(this.checkEditBegingGroup);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.simpleButtonBrowseIconPath);
            this.Controls.Add(this.textEditIconPath);
            this.Controls.Add(this.labelControlName);
            this.Controls.Add(this.textEditName);
            this.Controls.Add(this.labelControPath);
            this.Controls.Add(this.simpleButtonBrowsePath);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonSave);
            this.Controls.Add(this.textEditPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyDirectoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "My directory";
            ((System.ComponentModel.ISupportInitialize)(this.textEditPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIconPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBegingGroup.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEditPath;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonBrowsePath;
        private DevExpress.XtraEditors.XtraFolderBrowserDialog xtraFolderBrowserDialogMyDirectory;
        private DevExpress.XtraEditors.LabelControl labelControPath;
        private DevExpress.XtraEditors.LabelControl labelControlName;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonBrowseIconPath;
        private DevExpress.XtraEditors.TextEdit textEditIconPath;
        private DevExpress.XtraEditors.CheckEdit checkEditBegingGroup;
        private DevExpress.XtraEditors.LabelControl labelControlBeginGroup;
    }
}