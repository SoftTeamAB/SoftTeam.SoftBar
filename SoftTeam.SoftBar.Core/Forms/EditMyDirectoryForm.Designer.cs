namespace SoftTeam.SoftBar.Core.Forms
{
    partial class EditMyDirectoryForm
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
            this.textEditMyDirectory = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.xtraFolderBrowserDialogMyDirectory = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.labelControlMyDirectoryHeader = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMyDirectory.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditMyDirectory
            // 
            this.textEditMyDirectory.Location = new System.Drawing.Point(38, 57);
            this.textEditMyDirectory.Name = "textEditMyDirectory";
            this.textEditMyDirectory.Size = new System.Drawing.Size(232, 20);
            this.textEditMyDirectory.TabIndex = 0;
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Location = new System.Drawing.Point(146, 110);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(75, 32);
            this.simpleButtonSave.TabIndex = 1;
            this.simpleButtonSave.Text = "Save";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(227, 110);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 32);
            this.simpleButtonCancel.TabIndex = 2;
            this.simpleButtonCancel.Text = "Cancel";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonBrowse
            // 
            this.simpleButtonBrowse.Location = new System.Drawing.Point(276, 55);
            this.simpleButtonBrowse.Name = "simpleButtonBrowse";
            this.simpleButtonBrowse.Size = new System.Drawing.Size(26, 23);
            this.simpleButtonBrowse.TabIndex = 3;
            this.simpleButtonBrowse.Text = "...";
            this.simpleButtonBrowse.Click += new System.EventHandler(this.simpleButtonBrowse_Click);
            // 
            // xtraFolderBrowserDialogMyDirectory
            // 
            this.xtraFolderBrowserDialogMyDirectory.SelectedPath = "xtraFolderBrowserDialog1";
            // 
            // labelControlMyDirectoryHeader
            // 
            this.labelControlMyDirectoryHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlMyDirectoryHeader.Appearance.Options.UseFont = true;
            this.labelControlMyDirectoryHeader.Location = new System.Drawing.Point(38, 38);
            this.labelControlMyDirectoryHeader.Name = "labelControlMyDirectoryHeader";
            this.labelControlMyDirectoryHeader.Size = new System.Drawing.Size(120, 13);
            this.labelControlMyDirectoryHeader.TabIndex = 4;
            this.labelControlMyDirectoryHeader.Text = "Enter your directory :";
            // 
            // EditMyDirectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 154);
            this.Controls.Add(this.labelControlMyDirectoryHeader);
            this.Controls.Add(this.simpleButtonBrowse);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonSave);
            this.Controls.Add(this.textEditMyDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditMyDirectoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "My directory";
            ((System.ComponentModel.ISupportInitialize)(this.textEditMyDirectory.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEditMyDirectory;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonBrowse;
        private DevExpress.XtraEditors.XtraFolderBrowserDialog xtraFolderBrowserDialogMyDirectory;
        private DevExpress.XtraEditors.LabelControl labelControlMyDirectoryHeader;
    }
}