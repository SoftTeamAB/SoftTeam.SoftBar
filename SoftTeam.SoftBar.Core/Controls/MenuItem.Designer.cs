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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuItem));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.labelControlType = new DevExpress.XtraEditors.LabelControl();
            this.defaultLookAndFeelSoftBar = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.pictureBoxBeginGroup = new System.Windows.Forms.PictureBox();
            this.pictureBoxNoBeginGroup = new System.Windows.Forms.PictureBox();
            this.toolTipControllerMenuItem = new DevExpress.Utils.ToolTipController(this.components);
            this.labelControlName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBeginGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNoBeginGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControlType
            // 
            this.labelControlType.Location = new System.Drawing.Point(40, 0);
            this.labelControlType.Name = "labelControlType";
            this.labelControlType.Size = new System.Drawing.Size(22, 13);
            this.labelControlType.TabIndex = 1;
            this.labelControlType.Text = "type";
            this.labelControlType.DoubleClick += new System.EventHandler(this.MenuItem_DoubleClick);
            this.labelControlType.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuItem_MouseDown);
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
            this.pictureBoxIcon.DoubleClick += new System.EventHandler(this.MenuItem_DoubleClick);
            this.pictureBoxIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuItem_MouseDown);
            // 
            // pictureBoxBeginGroup
            // 
            this.pictureBoxBeginGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxBeginGroup.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBeginGroup.Image")));
            this.pictureBoxBeginGroup.Location = new System.Drawing.Point(363, 2);
            this.pictureBoxBeginGroup.Name = "pictureBoxBeginGroup";
            this.pictureBoxBeginGroup.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxBeginGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            superToolTip1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Text = "Begin group enabled!";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "When <b>Being group</b> is enabled a separator is created in the menu <b>before</" +
    "b> this item.\r\n\r\nClick to edit this item and change this setting.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.toolTipControllerMenuItem.SetSuperTip(this.pictureBoxBeginGroup, superToolTip1);
            this.pictureBoxBeginGroup.TabIndex = 4;
            this.pictureBoxBeginGroup.TabStop = false;
            this.pictureBoxBeginGroup.DoubleClick += new System.EventHandler(this.MenuItem_DoubleClick);
            this.pictureBoxBeginGroup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuItem_MouseDown);
            // 
            // pictureBoxNoBeginGroup
            // 
            this.pictureBoxNoBeginGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxNoBeginGroup.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNoBeginGroup.Image")));
            this.pictureBoxNoBeginGroup.Location = new System.Drawing.Point(363, 2);
            this.pictureBoxNoBeginGroup.Name = "pictureBoxNoBeginGroup";
            this.pictureBoxNoBeginGroup.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxNoBeginGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            superToolTip2.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem2.Text = "Begin group disabled!";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "When <b>Being group</b> is enabled a separator is created in the menu <b>before</" +
    "b> this item.\r\n\r\nClick to edit this item and change this setting.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.toolTipControllerMenuItem.SetSuperTip(this.pictureBoxNoBeginGroup, superToolTip2);
            this.pictureBoxNoBeginGroup.TabIndex = 5;
            this.pictureBoxNoBeginGroup.TabStop = false;
            this.pictureBoxNoBeginGroup.DoubleClick += new System.EventHandler(this.MenuItem_DoubleClick);
            this.pictureBoxNoBeginGroup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuItem_MouseDown);
            // 
            // labelControlName
            // 
            this.labelControlName.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlName.Appearance.Options.UseFont = true;
            this.labelControlName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlName.Location = new System.Drawing.Point(40, 15);
            this.labelControlName.Name = "labelControlName";
            this.labelControlName.Size = new System.Drawing.Size(317, 21);
            this.labelControlName.TabIndex = 6;
            this.labelControlName.Text = "labelControl1";
            this.labelControlName.DoubleClick += new System.EventHandler(this.MenuItem_DoubleClick);
            this.labelControlName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuItem_MouseDown);
            // 
            // MenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelControlName);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.labelControlType);
            this.Controls.Add(this.pictureBoxBeginGroup);
            this.Controls.Add(this.pictureBoxNoBeginGroup);
            this.Name = "MenuItem";
            this.Size = new System.Drawing.Size(398, 36);
            this.DoubleClick += new System.EventHandler(this.MenuItem_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuItem_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBeginGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNoBeginGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControlType;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeelSoftBar;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.PictureBox pictureBoxBeginGroup;
        private System.Windows.Forms.PictureBox pictureBoxNoBeginGroup;
        private DevExpress.Utils.ToolTipController toolTipControllerMenuItem;
        private DevExpress.XtraEditors.LabelControl labelControlName;
    }
}
