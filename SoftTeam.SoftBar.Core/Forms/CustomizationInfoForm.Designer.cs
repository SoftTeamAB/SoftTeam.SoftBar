namespace SoftTeam.SoftBar.Core.Forms
{
    partial class CustomizationInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizationInfoForm));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlShiftInfo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlInfo = new DevExpress.XtraEditors.LabelControl();
            this.pictureBoxInfo = new System.Windows.Forms.PictureBox();
            this.pictureBoxUp = new System.Windows.Forms.PictureBox();
            this.pictureBoxDown = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.labelControlUpDown = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(32, 156);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "CTRL";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(32, 87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "SHIFT";
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
            this.labelControlShiftInfo.Location = new System.Drawing.Point(86, 82);
            this.labelControlShiftInfo.Name = "labelControlShiftInfo";
            this.labelControlShiftInfo.Size = new System.Drawing.Size(186, 57);
            this.labelControlShiftInfo.TabIndex = 2;
            this.labelControlShiftInfo.Text = "Hold down the SHIFT key before you click the add item button, to create the new i" +
    "tem BEFORE the selected item.";
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
            this.labelControl3.Location = new System.Drawing.Point(86, 153);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(186, 72);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "If the selected item is a sub menu, hold down the CTRL key before you click the a" +
    "dd item button, to create the new item INSIDE the selected item.";
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
            this.labelControlInfo.Location = new System.Drawing.Point(86, 19);
            this.labelControlInfo.Name = "labelControlInfo";
            this.labelControlInfo.Size = new System.Drawing.Size(204, 51);
            this.labelControlInfo.TabIndex = 4;
            this.labelControlInfo.Text = "The default is to always create a new item AFTER the selected (green) item.";
            // 
            // pictureBoxInfo
            // 
            this.pictureBoxInfo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInfo.Image")));
            this.pictureBoxInfo.Location = new System.Drawing.Point(32, 26);
            this.pictureBoxInfo.Name = "pictureBoxInfo";
            this.pictureBoxInfo.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxInfo.TabIndex = 5;
            this.pictureBoxInfo.TabStop = false;
            // 
            // pictureBoxUp
            // 
            this.pictureBoxUp.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUp.Image")));
            this.pictureBoxUp.Location = new System.Drawing.Point(30, 232);
            this.pictureBoxUp.Name = "pictureBoxUp";
            this.pictureBoxUp.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxUp.TabIndex = 6;
            this.pictureBoxUp.TabStop = false;
            // 
            // pictureBoxDown
            // 
            this.pictureBoxDown.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDown.Image")));
            this.pictureBoxDown.Location = new System.Drawing.Point(30, 248);
            this.pictureBoxDown.Name = "pictureBoxDown";
            this.pictureBoxDown.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxDown.TabIndex = 7;
            this.pictureBoxDown.TabStop = false;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLeft.Image")));
            this.pictureBoxLeft.Location = new System.Drawing.Point(23, 275);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxLeft.TabIndex = 8;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.Visible = false;
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxRight.Image")));
            this.pictureBoxRight.Location = new System.Drawing.Point(39, 275);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxRight.TabIndex = 9;
            this.pictureBoxRight.TabStop = false;
            this.pictureBoxRight.Visible = false;
            // 
            // labelControlUpDown
            // 
            this.labelControlUpDown.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlUpDown.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControlUpDown.Appearance.Options.UseFont = true;
            this.labelControlUpDown.Appearance.Options.UseForeColor = true;
            this.labelControlUpDown.Appearance.Options.UseTextOptions = true;
            this.labelControlUpDown.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControlUpDown.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlUpDown.Location = new System.Drawing.Point(86, 232);
            this.labelControlUpDown.Name = "labelControlUpDown";
            this.labelControlUpDown.Size = new System.Drawing.Size(186, 32);
            this.labelControlUpDown.TabIndex = 10;
            this.labelControlUpDown.Text = "Use the UP and DOWN key to move the selected item up and down.";
            // 
            // CustomizationInfoForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 289);
            this.Controls.Add(this.labelControlUpDown);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.pictureBoxDown);
            this.Controls.Add(this.pictureBoxUp);
            this.Controls.Add(this.pictureBoxInfo);
            this.Controls.Add(this.labelControlInfo);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControlShiftInfo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomizationInfoForm";
            this.ShowInTaskbar = false;
            this.Text = "CustomizationInfoForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControlShiftInfo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControlInfo;
        private System.Windows.Forms.PictureBox pictureBoxInfo;
        private System.Windows.Forms.PictureBox pictureBoxUp;
        private System.Windows.Forms.PictureBox pictureBoxDown;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private DevExpress.XtraEditors.LabelControl labelControlUpDown;
    }
}