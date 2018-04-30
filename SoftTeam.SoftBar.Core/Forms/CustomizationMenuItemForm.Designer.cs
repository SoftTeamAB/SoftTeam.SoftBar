namespace SoftTeam.SoftBar.Core.Forms
{
    partial class CustomizationMenuItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizationMenuItemForm));
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.editMenuItem = new SoftTeam.SoftBar.Core.Controls.EditMenuItemControl();
            this.editSubMenu = new SoftTeam.SoftBar.Core.Controls.EditSubMenuControl();
            this.editHeaderItem = new SoftTeam.SoftBar.Core.Controls.EditHeaderItemControl();
            this.editMenu = new SoftTeam.SoftBar.Core.Controls.EditMenuControl();
            this.SuspendLayout();
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCancel.ImageOptions.Image")));
            this.simpleButtonCancel.Location = new System.Drawing.Point(419, 316);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 33);
            this.simpleButtonCancel.TabIndex = 1;
            this.simpleButtonCancel.Text = "&Cancel";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonOk.ImageOptions.Image")));
            this.simpleButtonOk.Location = new System.Drawing.Point(338, 316);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(75, 33);
            this.simpleButtonOk.TabIndex = 2;
            this.simpleButtonOk.Text = "&OK";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.ApplicationPath = "";
            this.editMenuItem.BeginGroup = false;
            this.editMenuItem.DocumentPath = "";
            this.editMenuItem.IconPath = "";
            this.editMenuItem.Location = new System.Drawing.Point(0, 0);
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Parameters = "";
            this.editMenuItem.RunAsAdministrator = false;
            this.editMenuItem.Size = new System.Drawing.Size(500, 300);
            this.editMenuItem.TabIndex = 5;
            // 
            // editSubMenu
            // 
            this.editSubMenu.BeginGroup = false;
            this.editSubMenu.IconPath = "";
            this.editSubMenu.Location = new System.Drawing.Point(0, 0);
            this.editSubMenu.Name = "editSubMenu";
            this.editSubMenu.Size = new System.Drawing.Size(500, 300);
            this.editSubMenu.TabIndex = 4;
            // 
            // editHeaderItem
            // 
            this.editHeaderItem.BeginGroup = false;
            this.editHeaderItem.Location = new System.Drawing.Point(0, 0);
            this.editHeaderItem.Name = "editHeaderItem";
            this.editHeaderItem.Size = new System.Drawing.Size(500, 300);
            this.editHeaderItem.TabIndex = 3;
            // 
            // editMenu
            // 
            this.editMenu.BeginGroup = false;
            this.editMenu.IconPath = "";
            this.editMenu.Location = new System.Drawing.Point(0, 0);
            this.editMenu.MenuWidth = 0;
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(500, 300);
            this.editMenu.TabIndex = 0;
            // 
            // CustomizationMenuItemForm
            // 
            this.AcceptButton = this.simpleButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.simpleButtonCancel;
            this.ClientSize = new System.Drawing.Size(510, 361);
            this.Controls.Add(this.simpleButtonOk);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.editMenuItem);
            this.Controls.Add(this.editSubMenu);
            this.Controls.Add(this.editHeaderItem);
            this.Controls.Add(this.editMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomizationMenuItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customize menu item";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.EditMenuControl editMenu;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private Controls.EditHeaderItemControl editHeaderItem;
        private Controls.EditSubMenuControl editSubMenu;
        private Controls.EditMenuItemControl editMenuItem;
    }
}