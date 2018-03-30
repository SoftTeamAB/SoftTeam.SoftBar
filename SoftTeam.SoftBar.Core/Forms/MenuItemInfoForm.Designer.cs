namespace SoftTeam.SoftBar.Core.Forms
{
    partial class MenuItemInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuItemInfoForm));
            this.pictureBoxInfo = new System.Windows.Forms.PictureBox();
            this.labelControlInfo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlShiftInfo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxInfo
            // 
            this.pictureBoxInfo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInfo.Image")));
            this.pictureBoxInfo.Location = new System.Drawing.Point(22, 22);
            this.pictureBoxInfo.Name = "pictureBoxInfo";
            this.pictureBoxInfo.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxInfo.TabIndex = 11;
            this.pictureBoxInfo.TabStop = false;
            // 
            // labelControlInfo
            // 
            this.labelControlInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlInfo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControlInfo.Appearance.Options.UseFont = true;
            this.labelControlInfo.Appearance.Options.UseForeColor = true;
            this.labelControlInfo.Appearance.Options.UseTextOptions = true;
            this.labelControlInfo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControlInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlInfo.Location = new System.Drawing.Point(76, 21);
            this.labelControlInfo.Name = "labelControlInfo";
            this.labelControlInfo.Size = new System.Drawing.Size(186, 35);
            this.labelControlInfo.TabIndex = 10;
            this.labelControlInfo.Text = "You can create different types of SoftBar menu items:\r\n";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(35, 122);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(227, 58);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "To create a menu item that opens a document in its registered application, you on" +
    "ly need to enter the document path. You can leave the application path empty.";
            // 
            // labelControlShiftInfo
            // 
            this.labelControlShiftInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlShiftInfo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControlShiftInfo.Appearance.Options.UseFont = true;
            this.labelControlShiftInfo.Appearance.Options.UseForeColor = true;
            this.labelControlShiftInfo.Appearance.Options.UseTextOptions = true;
            this.labelControlShiftInfo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControlShiftInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlShiftInfo.Location = new System.Drawing.Point(35, 63);
            this.labelControlShiftInfo.Name = "labelControlShiftInfo";
            this.labelControlShiftInfo.Size = new System.Drawing.Size(227, 52);
            this.labelControlShiftInfo.TabIndex = 8;
            this.labelControlShiftInfo.Text = "To create a menu item that just starts an application, you only need to set the a" +
    "pplication path. Document path can be left empty.";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(35, 186);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(227, 58);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "To create a menu item that opens a document in a different application than the r" +
    "egistered application, you need to enter both the application path and document " +
    "path.\r\n";
            // 
            // MenuItemInfoForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureBoxInfo);
            this.Controls.Add(this.labelControlInfo);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControlShiftInfo);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuItemInfoForm";
            this.Text = "MenuItemInfoForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxInfo;
        private DevExpress.XtraEditors.LabelControl labelControlInfo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControlShiftInfo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}