namespace SoftTeam.SoftBar.Core.Controls
{
    partial class MenuItem
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
            this.hyperlinkLabelControlName = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.defaultLookAndFeelSoftBar = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // hyperlinkLabelControlName
            // 
            this.hyperlinkLabelControlName.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hyperlinkLabelControlName.Appearance.Options.UseFont = true;
            this.hyperlinkLabelControlName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.hyperlinkLabelControlName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hyperlinkLabelControlName.Location = new System.Drawing.Point(40, 10);
            this.hyperlinkLabelControlName.Name = "hyperlinkLabelControlName";
            this.hyperlinkLabelControlName.Size = new System.Drawing.Size(243, 16);
            this.hyperlinkLabelControlName.TabIndex = 0;
            this.hyperlinkLabelControlName.Text = "Name";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(152, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "labelControl1";
            this.labelControl1.Visible = false;
            // 
            // defaultLookAndFeelSoftBar
            // 
            this.defaultLookAndFeelSoftBar.LookAndFeel.SkinName = "DevExpress Dark Style";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Location = new System.Drawing.Point(2, 2);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxIcon.TabIndex = 3;
            this.pictureBoxIcon.TabStop = false;
            // 
            // MenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.hyperlinkLabelControlName);
            this.Name = "MenuItem";
            this.Size = new System.Drawing.Size(398, 34);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuItem_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.HyperlinkLabelControl hyperlinkLabelControlName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeelSoftBar;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
    }
}
