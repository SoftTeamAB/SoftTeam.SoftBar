namespace SoftTeam.SoftBar.Core.Controls
{
    partial class EditHeaderItemControl
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditHeaderItemControl));
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelControlName = new DevExpress.XtraEditors.LabelControl();
            this.labelControlEditHeader = new DevExpress.XtraEditors.LabelControl();
            this.checkEditBeginGroup = new DevExpress.XtraEditors.CheckEdit();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBeginGroup.Properties)).BeginInit();
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
            // labelControlName
            // 
            this.labelControlName.Location = new System.Drawing.Point(50, 70);
            this.labelControlName.Name = "labelControlName";
            this.labelControlName.Size = new System.Drawing.Size(27, 13);
            this.labelControlName.TabIndex = 14;
            this.labelControlName.Text = "Name";
            // 
            // labelControlEditHeader
            // 
            this.labelControlEditHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlEditHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlEditHeader.Appearance.Options.UseFont = true;
            this.labelControlEditHeader.Appearance.Options.UseTextOptions = true;
            this.labelControlEditHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlEditHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlEditHeader.Location = new System.Drawing.Point(3, 9);
            this.labelControlEditHeader.Name = "labelControlEditHeader";
            this.labelControlEditHeader.Size = new System.Drawing.Size(494, 19);
            this.labelControlEditHeader.TabIndex = 12;
            this.labelControlEditHeader.Text = "Edit header";
            // 
            // checkEditBeginGroup
            // 
            this.checkEditBeginGroup.Location = new System.Drawing.Point(50, 115);
            this.checkEditBeginGroup.Name = "checkEditBeginGroup";
            this.checkEditBeginGroup.Properties.Caption = "Begin group";
            this.checkEditBeginGroup.Size = new System.Drawing.Size(100, 19);
            superToolTip1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem1.Text = "Begin group";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "If this is checked a separator will appear <b>before</b> this item in the menu.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.checkEditBeginGroup.SuperTip = superToolTip1;
            this.checkEditBeginGroup.TabIndex = 11;
            // 
            // textEditName
            // 
            this.textEditName.Location = new System.Drawing.Point(50, 89);
            this.textEditName.Name = "textEditName";
            this.textEditName.Size = new System.Drawing.Size(405, 20);
            superToolTip2.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem2.Text = "Name";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "The name of this menu item. This is the name that will appear in the menu, when i" +
    "t is opened.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.textEditName.SuperTip = superToolTip2;
            this.textEditName.TabIndex = 9;
            // 
            // EditHeaderItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.labelControlName);
            this.Controls.Add(this.labelControlEditHeader);
            this.Controls.Add(this.checkEditBeginGroup);
            this.Controls.Add(this.textEditName);
            this.Name = "EditHeaderItemControl";
            this.Size = new System.Drawing.Size(500, 300);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBeginGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private DevExpress.XtraEditors.LabelControl labelControlName;
        private DevExpress.XtraEditors.LabelControl labelControlEditHeader;
        private DevExpress.XtraEditors.CheckEdit checkEditBeginGroup;
        private DevExpress.XtraEditors.TextEdit textEditName;
    }
}
