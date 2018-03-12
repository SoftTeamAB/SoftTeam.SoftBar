namespace SoftTeam.SoftBar.Core.Controls
{
    partial class EditMenu
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMenu));
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            this.textEditIconPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControlEditMenu = new DevExpress.XtraEditors.LabelControl();
            this.labelControlIconPath = new DevExpress.XtraEditors.LabelControl();
            this.labelControlName = new DevExpress.XtraEditors.LabelControl();
            this.checkEditBeginGroup = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButtonBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.xtraOpenFileDialogEditMenu = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIconPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBeginGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditName
            // 
            this.textEditName.Location = new System.Drawing.Point(50, 89);
            this.textEditName.Name = "textEditName";
            this.textEditName.Size = new System.Drawing.Size(307, 20);
            superToolTip1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Text = "Name";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "The name of this menu item. This is the name that will appear in the menu, when i" +
    "t is opened.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.textEditName.SuperTip = superToolTip1;
            this.textEditName.TabIndex = 0;
            // 
            // textEditIconPath
            // 
            this.textEditIconPath.Location = new System.Drawing.Point(50, 134);
            this.textEditIconPath.Name = "textEditIconPath";
            this.textEditIconPath.Size = new System.Drawing.Size(274, 20);
            superToolTip2.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem2.Text = "Icon path";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "The path for the file that contains the icon that should be used for this menu it" +
    "em.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.textEditIconPath.SuperTip = superToolTip2;
            this.textEditIconPath.TabIndex = 1;
            // 
            // labelControlEditMenu
            // 
            this.labelControlEditMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlEditMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlEditMenu.Appearance.Options.UseFont = true;
            this.labelControlEditMenu.Appearance.Options.UseTextOptions = true;
            this.labelControlEditMenu.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlEditMenu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlEditMenu.Location = new System.Drawing.Point(3, 9);
            this.labelControlEditMenu.Name = "labelControlEditMenu";
            this.labelControlEditMenu.Size = new System.Drawing.Size(394, 19);
            this.labelControlEditMenu.TabIndex = 3;
            this.labelControlEditMenu.Text = "Edit menu";
            // 
            // labelControlIconPath
            // 
            this.labelControlIconPath.Location = new System.Drawing.Point(50, 115);
            this.labelControlIconPath.Name = "labelControlIconPath";
            this.labelControlIconPath.Size = new System.Drawing.Size(46, 13);
            this.labelControlIconPath.TabIndex = 4;
            this.labelControlIconPath.Text = "Icon path";
            // 
            // labelControlName
            // 
            this.labelControlName.Location = new System.Drawing.Point(50, 70);
            this.labelControlName.Name = "labelControlName";
            this.labelControlName.Size = new System.Drawing.Size(27, 13);
            this.labelControlName.TabIndex = 6;
            this.labelControlName.Text = "Name";
            // 
            // checkEditBeginGroup
            // 
            this.checkEditBeginGroup.Location = new System.Drawing.Point(50, 160);
            this.checkEditBeginGroup.Name = "checkEditBeginGroup";
            this.checkEditBeginGroup.Properties.Caption = "Begin group";
            this.checkEditBeginGroup.Size = new System.Drawing.Size(100, 19);
            superToolTip4.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem4.Text = "Begin group";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "If this is checked a separator will appear <b>before</b> this item in the menu.";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.checkEditBeginGroup.SuperTip = superToolTip4;
            this.checkEditBeginGroup.TabIndex = 2;
            // 
            // simpleButtonBrowse
            // 
            this.simpleButtonBrowse.Location = new System.Drawing.Point(330, 132);
            this.simpleButtonBrowse.Name = "simpleButtonBrowse";
            this.simpleButtonBrowse.Size = new System.Drawing.Size(27, 23);
            this.simpleButtonBrowse.TabIndex = 7;
            this.simpleButtonBrowse.Text = "...";
            this.simpleButtonBrowse.Click += new System.EventHandler(this.simpleButtonBrowse_Click);
            // 
            // xtraOpenFileDialogEditMenu
            // 
            this.xtraOpenFileDialogEditMenu.FileName = "xtraOpenFileDialog1";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxIcon.TabIndex = 8;
            this.pictureBoxIcon.TabStop = false;
            // 
            // EditMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.simpleButtonBrowse);
            this.Controls.Add(this.labelControlName);
            this.Controls.Add(this.labelControlIconPath);
            this.Controls.Add(this.labelControlEditMenu);
            this.Controls.Add(this.checkEditBeginGroup);
            this.Controls.Add(this.textEditIconPath);
            this.Controls.Add(this.textEditName);
            this.Name = "EditMenu";
            this.Size = new System.Drawing.Size(400, 250);
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIconPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBeginGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraEditors.TextEdit textEditIconPath;
        private DevExpress.XtraEditors.LabelControl labelControlEditMenu;
        private DevExpress.XtraEditors.LabelControl labelControlIconPath;
        private DevExpress.XtraEditors.LabelControl labelControlName;
        private DevExpress.XtraEditors.CheckEdit checkEditBeginGroup;
        private DevExpress.XtraEditors.SimpleButton simpleButtonBrowse;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialogEditMenu;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}
