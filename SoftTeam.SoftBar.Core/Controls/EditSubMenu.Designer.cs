namespace SoftTeam.SoftBar.Core.Controls
{
    partial class EditSubMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.simpleButtonBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlName = new DevExpress.XtraEditors.LabelControl();
            this.labelControlIconPath = new DevExpress.XtraEditors.LabelControl();
            this.labelControlEditSubMenu = new DevExpress.XtraEditors.LabelControl();
            this.checkEditBeginGroup = new DevExpress.XtraEditors.CheckEdit();
            this.textEditIconPath = new DevExpress.XtraEditors.TextEdit();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            this.xtraOpenFileDialogEditSubMenu = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBeginGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIconPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxIcon.TabIndex = 16;
            this.pictureBoxIcon.TabStop = false;
            // 
            // simpleButtonBrowse
            // 
            this.simpleButtonBrowse.Location = new System.Drawing.Point(330, 132);
            this.simpleButtonBrowse.Name = "simpleButtonBrowse";
            this.simpleButtonBrowse.Size = new System.Drawing.Size(27, 23);
            this.simpleButtonBrowse.TabIndex = 15;
            this.simpleButtonBrowse.Text = "...";
            this.simpleButtonBrowse.Click += new System.EventHandler(this.simpleButtonBrowse_Click);
            // 
            // labelControlName
            // 
            this.labelControlName.Location = new System.Drawing.Point(50, 70);
            this.labelControlName.Name = "labelControlName";
            this.labelControlName.Size = new System.Drawing.Size(27, 13);
            this.labelControlName.TabIndex = 14;
            this.labelControlName.Text = "Name";
            // 
            // labelControlIconPath
            // 
            this.labelControlIconPath.Location = new System.Drawing.Point(50, 115);
            this.labelControlIconPath.Name = "labelControlIconPath";
            this.labelControlIconPath.Size = new System.Drawing.Size(46, 13);
            this.labelControlIconPath.TabIndex = 13;
            this.labelControlIconPath.Text = "Icon path";
            // 
            // labelControlEditSubMenu
            // 
            this.labelControlEditSubMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlEditSubMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlEditSubMenu.Appearance.Options.UseFont = true;
            this.labelControlEditSubMenu.Appearance.Options.UseTextOptions = true;
            this.labelControlEditSubMenu.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlEditSubMenu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlEditSubMenu.Location = new System.Drawing.Point(3, 9);
            this.labelControlEditSubMenu.Name = "labelControlEditSubMenu";
            this.labelControlEditSubMenu.Size = new System.Drawing.Size(394, 19);
            this.labelControlEditSubMenu.TabIndex = 12;
            this.labelControlEditSubMenu.Text = "Edit sub menu";
            // 
            // checkEditBeginGroup
            // 
            this.checkEditBeginGroup.Location = new System.Drawing.Point(50, 160);
            this.checkEditBeginGroup.Name = "checkEditBeginGroup";
            this.checkEditBeginGroup.Properties.Caption = "Begin group";
            this.checkEditBeginGroup.Size = new System.Drawing.Size(100, 19);
            this.checkEditBeginGroup.TabIndex = 11;
            // 
            // textEditIconPath
            // 
            this.textEditIconPath.Enabled = false;
            this.textEditIconPath.Location = new System.Drawing.Point(50, 134);
            this.textEditIconPath.Name = "textEditIconPath";
            this.textEditIconPath.Size = new System.Drawing.Size(274, 20);
            this.textEditIconPath.TabIndex = 10;
            // 
            // textEditName
            // 
            this.textEditName.Location = new System.Drawing.Point(50, 89);
            this.textEditName.Name = "textEditName";
            this.textEditName.Size = new System.Drawing.Size(307, 20);
            this.textEditName.TabIndex = 9;
            // 
            // xtraOpenFileDialogEditSubMenu
            // 
            this.xtraOpenFileDialogEditSubMenu.FileName = "xtraOpenFileDialog1";
            // 
            // EditSubMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.simpleButtonBrowse);
            this.Controls.Add(this.labelControlName);
            this.Controls.Add(this.labelControlIconPath);
            this.Controls.Add(this.labelControlEditSubMenu);
            this.Controls.Add(this.checkEditBeginGroup);
            this.Controls.Add(this.textEditIconPath);
            this.Controls.Add(this.textEditName);
            this.Name = "EditSubMenu";
            this.Size = new System.Drawing.Size(400, 250);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBeginGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIconPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private DevExpress.XtraEditors.SimpleButton simpleButtonBrowse;
        private DevExpress.XtraEditors.LabelControl labelControlName;
        private DevExpress.XtraEditors.LabelControl labelControlIconPath;
        private DevExpress.XtraEditors.LabelControl labelControlEditSubMenu;
        private DevExpress.XtraEditors.CheckEdit checkEditBeginGroup;
        private DevExpress.XtraEditors.TextEdit textEditIconPath;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialogEditSubMenu;
    }
}
