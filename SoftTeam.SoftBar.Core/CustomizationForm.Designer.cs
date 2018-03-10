namespace SoftTeam.SoftBar.Core
{
    partial class CustomizationForm
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
            this.xtraScrollableControlMenu = new DevExpress.XtraEditors.XtraScrollableControl();
            this.SuspendLayout();
            // 
            // xtraScrollableControlMenu
            // 
            this.xtraScrollableControlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.xtraScrollableControlMenu.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControlMenu.Name = "xtraScrollableControlMenu";
            this.xtraScrollableControlMenu.Size = new System.Drawing.Size(379, 516);
            this.xtraScrollableControlMenu.TabIndex = 0;
            // 
            // CustomizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 516);
            this.Controls.Add(this.xtraScrollableControlMenu);
            this.Name = "CustomizationForm";
            this.Text = "CustomizationForm";
            this.Load += new System.EventHandler(this.CustomizationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControlMenu;
    }
}