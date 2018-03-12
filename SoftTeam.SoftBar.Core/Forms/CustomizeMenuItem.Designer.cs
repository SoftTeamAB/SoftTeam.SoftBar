namespace SoftTeam.SoftBar.Core.Forms
{
    partial class CustomizeMenuItem
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
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.editMenu = new SoftTeam.SoftBar.Core.Controls.EditMenu();
            this.editHeaderItem = new SoftTeam.SoftBar.Core.Controls.EditHeaderItem();
            this.SuspendLayout();
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.Location = new System.Drawing.Point(309, 266);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 1;
            this.simpleButtonCancel.Text = "&Cancel";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonOk.Location = new System.Drawing.Point(228, 266);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOk.TabIndex = 2;
            this.simpleButtonOk.Text = "&OK";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // editMenu
            // 
            this.editMenu.BeginGroup = false;
            this.editMenu.IconPath = "";
            this.editMenu.Location = new System.Drawing.Point(0, 0);
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(400, 250);
            this.editMenu.TabIndex = 0;
            // 
            // editHeaderItem
            // 
            this.editHeaderItem.Location = new System.Drawing.Point(0, 0);
            this.editHeaderItem.Name = "editHeaderItem";
            this.editHeaderItem.Size = new System.Drawing.Size(400, 250);
            this.editHeaderItem.TabIndex = 3;
            // 
            // CustomizeMenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 303);
            this.Controls.Add(this.simpleButtonOk);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.editHeaderItem);
            this.Controls.Add(this.editMenu);
            this.Name = "CustomizeMenuItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CustomizeMenuItem";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.EditMenu editMenu;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private Controls.EditHeaderItem editHeaderItem;
    }
}