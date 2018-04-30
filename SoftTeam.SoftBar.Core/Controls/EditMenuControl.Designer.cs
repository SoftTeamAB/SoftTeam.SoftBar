namespace SoftTeam.SoftBar.Core.Controls
{
    partial class EditMenuControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMenuControl));
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            this.textEditIconPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControlEditMenu = new DevExpress.XtraEditors.LabelControl();
            this.labelControlIconPath = new DevExpress.XtraEditors.LabelControl();
            this.labelControlName = new DevExpress.XtraEditors.LabelControl();
            this.checkEditBeginGroup = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButtonBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.toolTipControllerEditMenu = new DevExpress.Utils.ToolTipController(this.components);
            this.labelControlWidth = new DevExpress.XtraEditors.LabelControl();
            this.spinEditWidth = new DevExpress.XtraEditors.SpinEdit();
            this.openFileDialogEditMenu = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIconPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBeginGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditWidth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditName
            // 
            this.textEditName.Location = new System.Drawing.Point(50, 74);
            this.textEditName.Name = "textEditName";
            this.textEditName.Size = new System.Drawing.Size(400, 20);
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
            this.textEditIconPath.Location = new System.Drawing.Point(50, 119);
            this.textEditIconPath.Name = "textEditIconPath";
            this.textEditIconPath.Size = new System.Drawing.Size(367, 20);
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
            this.textEditIconPath.EditValueChanged += new System.EventHandler(this.textEditIconPath_EditValueChanged);
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
            this.labelControlEditMenu.Size = new System.Drawing.Size(494, 19);
            this.labelControlEditMenu.TabIndex = 3;
            this.labelControlEditMenu.Text = "Edit menu";
            // 
            // labelControlIconPath
            // 
            this.labelControlIconPath.Location = new System.Drawing.Point(50, 100);
            this.labelControlIconPath.Name = "labelControlIconPath";
            this.labelControlIconPath.Size = new System.Drawing.Size(87, 13);
            this.labelControlIconPath.TabIndex = 4;
            this.labelControlIconPath.Text = "Icon path (24x24)";
            // 
            // labelControlName
            // 
            this.labelControlName.Location = new System.Drawing.Point(50, 55);
            this.labelControlName.Name = "labelControlName";
            this.labelControlName.Size = new System.Drawing.Size(27, 13);
            this.labelControlName.TabIndex = 6;
            this.labelControlName.Text = "Name";
            // 
            // checkEditBeginGroup
            // 
            this.checkEditBeginGroup.Location = new System.Drawing.Point(50, 190);
            this.checkEditBeginGroup.Name = "checkEditBeginGroup";
            this.checkEditBeginGroup.Properties.Caption = "Begin group";
            this.checkEditBeginGroup.Size = new System.Drawing.Size(100, 19);
            superToolTip3.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem3.Text = "Begin group";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "If this is checked a separator will appear <b>before</b> this item in the menu.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.checkEditBeginGroup.SuperTip = superToolTip3;
            this.checkEditBeginGroup.TabIndex = 2;
            // 
            // simpleButtonBrowse
            // 
            this.simpleButtonBrowse.Location = new System.Drawing.Point(423, 117);
            this.simpleButtonBrowse.Name = "simpleButtonBrowse";
            this.simpleButtonBrowse.Size = new System.Drawing.Size(27, 23);
            this.simpleButtonBrowse.TabIndex = 7;
            this.simpleButtonBrowse.Text = "...";
            this.simpleButtonBrowse.Click += new System.EventHandler(this.simpleButtonBrowse_Click);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Location = new System.Drawing.Point(51, 9);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxIcon.TabIndex = 8;
            this.pictureBoxIcon.TabStop = false;
            // 
            // labelControlWidth
            // 
            this.labelControlWidth.Location = new System.Drawing.Point(50, 145);
            this.labelControlWidth.Name = "labelControlWidth";
            this.labelControlWidth.Size = new System.Drawing.Size(28, 13);
            this.labelControlWidth.TabIndex = 10;
            this.labelControlWidth.Text = "Width";
            // 
            // spinEditWidth
            // 
            this.spinEditWidth.EditValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.spinEditWidth.Location = new System.Drawing.Point(50, 164);
            this.spinEditWidth.Name = "spinEditWidth";
            this.spinEditWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditWidth.Properties.IsFloatValue = false;
            this.spinEditWidth.Properties.Mask.EditMask = "N00";
            this.spinEditWidth.Properties.MaxValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.spinEditWidth.Properties.MinValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.spinEditWidth.Size = new System.Drawing.Size(117, 20);
            this.spinEditWidth.TabIndex = 11;
            // 
            // openFileDialogEditMenu
            // 
            this.openFileDialogEditMenu.FileName = "openFileDialog1";
            // 
            // EditMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spinEditWidth);
            this.Controls.Add(this.labelControlWidth);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.simpleButtonBrowse);
            this.Controls.Add(this.labelControlName);
            this.Controls.Add(this.labelControlIconPath);
            this.Controls.Add(this.labelControlEditMenu);
            this.Controls.Add(this.checkEditBeginGroup);
            this.Controls.Add(this.textEditIconPath);
            this.Controls.Add(this.textEditName);
            this.Name = "EditMenuControl";
            this.Size = new System.Drawing.Size(500, 300);
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIconPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBeginGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditWidth.Properties)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private DevExpress.Utils.ToolTipController toolTipControllerEditMenu;
        private DevExpress.XtraEditors.LabelControl labelControlWidth;
        private DevExpress.XtraEditors.SpinEdit spinEditWidth;
        private System.Windows.Forms.OpenFileDialog openFileDialogEditMenu;
    }
}
