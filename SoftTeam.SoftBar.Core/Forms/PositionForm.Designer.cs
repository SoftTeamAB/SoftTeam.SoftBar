namespace SoftTeam.SoftBar.Core.Forms
{
    partial class PositionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PositionForm));
            this.panelControlSelectedItem = new DevExpress.XtraEditors.PanelControl();
            this.labelControlSelectedItem = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonCreateItemBefore = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCreateItemInside = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCreateItemAfter = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlSelectedItem)).BeginInit();
            this.panelControlSelectedItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlSelectedItem
            // 
            this.panelControlSelectedItem.Controls.Add(this.pictureBoxIcon);
            this.panelControlSelectedItem.Controls.Add(this.labelControlSelectedItem);
            this.panelControlSelectedItem.Location = new System.Drawing.Point(12, 55);
            this.panelControlSelectedItem.Name = "panelControlSelectedItem";
            this.panelControlSelectedItem.Size = new System.Drawing.Size(317, 35);
            this.panelControlSelectedItem.TabIndex = 0;
            // 
            // labelControlSelectedItem
            // 
            this.labelControlSelectedItem.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlSelectedItem.Appearance.Options.UseFont = true;
            this.labelControlSelectedItem.Location = new System.Drawing.Point(36, 4);
            this.labelControlSelectedItem.Name = "labelControlSelectedItem";
            this.labelControlSelectedItem.Size = new System.Drawing.Size(127, 25);
            this.labelControlSelectedItem.TabIndex = 0;
            this.labelControlSelectedItem.Text = "Selected item";
            // 
            // simpleButtonCreateItemBefore
            // 
            this.simpleButtonCreateItemBefore.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCreateItemBefore.ImageOptions.Image")));
            this.simpleButtonCreateItemBefore.Location = new System.Drawing.Point(12, 11);
            this.simpleButtonCreateItemBefore.Name = "simpleButtonCreateItemBefore";
            this.simpleButtonCreateItemBefore.Size = new System.Drawing.Size(317, 38);
            this.simpleButtonCreateItemBefore.TabIndex = 1;
            this.simpleButtonCreateItemBefore.Text = "Create new item before...";
            this.simpleButtonCreateItemBefore.Click += new System.EventHandler(this.simpleButtonCreateItemBefore_Click);
            // 
            // simpleButtonCreateItemInside
            // 
            this.simpleButtonCreateItemInside.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCreateItemInside.ImageOptions.Image")));
            this.simpleButtonCreateItemInside.Location = new System.Drawing.Point(48, 96);
            this.simpleButtonCreateItemInside.Name = "simpleButtonCreateItemInside";
            this.simpleButtonCreateItemInside.Size = new System.Drawing.Size(317, 38);
            this.simpleButtonCreateItemInside.TabIndex = 2;
            this.simpleButtonCreateItemInside.Text = "Create new item inside...";
            this.simpleButtonCreateItemInside.Click += new System.EventHandler(this.simpleButtonCreateItemInside_Click);
            // 
            // simpleButtonCreateItemAfter
            // 
            this.simpleButtonCreateItemAfter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCreateItemAfter.ImageOptions.Image")));
            this.simpleButtonCreateItemAfter.Location = new System.Drawing.Point(12, 140);
            this.simpleButtonCreateItemAfter.Name = "simpleButtonCreateItemAfter";
            this.simpleButtonCreateItemAfter.Size = new System.Drawing.Size(317, 38);
            this.simpleButtonCreateItemAfter.TabIndex = 3;
            this.simpleButtonCreateItemAfter.Text = "Create new item after...";
            this.simpleButtonCreateItemAfter.Click += new System.EventHandler(this.simpleButtonCreateItemAfter_Click);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Location = new System.Drawing.Point(6, 5);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxIcon.TabIndex = 1;
            this.pictureBoxIcon.TabStop = false;
            // 
            // PositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 189);
            this.Controls.Add(this.simpleButtonCreateItemAfter);
            this.Controls.Add(this.simpleButtonCreateItemInside);
            this.Controls.Add(this.simpleButtonCreateItemBefore);
            this.Controls.Add(this.panelControlSelectedItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PositionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose position...";
            this.Load += new System.EventHandler(this.PositionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlSelectedItem)).EndInit();
            this.panelControlSelectedItem.ResumeLayout(false);
            this.panelControlSelectedItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlSelectedItem;
        private DevExpress.XtraEditors.LabelControl labelControlSelectedItem;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCreateItemBefore;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCreateItemInside;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCreateItemAfter;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
    }
}