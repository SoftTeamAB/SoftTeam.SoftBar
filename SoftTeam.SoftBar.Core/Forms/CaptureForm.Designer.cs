namespace SoftTeam.SoftBar.Core.Forms
{
    partial class CaptureForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureForm));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.gridColumnPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButtonCapture = new DevExpress.XtraEditors.SimpleButton();
            this.imageListCapture = new System.Windows.Forms.ImageList(this.components);
            this.labelControlCaptureDescription = new DevExpress.XtraEditors.LabelControl();
            this.labelControlHeader = new DevExpress.XtraEditors.LabelControl();
            this.gridControlCapture = new DevExpress.XtraGrid.GridControl();
            this.gridViewCapture = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonNext = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumnPriority
            // 
            this.gridColumnPriority.Caption = "Priority";
            this.gridColumnPriority.FieldName = "Priority";
            this.gridColumnPriority.Name = "gridColumnPriority";
            // 
            // simpleButtonCapture
            // 
            this.simpleButtonCapture.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonCapture.Appearance.Options.UseFont = true;
            this.simpleButtonCapture.ImageOptions.ImageIndex = 0;
            this.simpleButtonCapture.ImageOptions.ImageList = this.imageListCapture;
            this.simpleButtonCapture.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButtonCapture.ImageOptions.ImageToTextIndent = 20;
            this.simpleButtonCapture.Location = new System.Drawing.Point(12, 111);
            this.simpleButtonCapture.Name = "simpleButtonCapture";
            this.simpleButtonCapture.Size = new System.Drawing.Size(435, 90);
            this.simpleButtonCapture.TabIndex = 0;
            this.simpleButtonCapture.Text = "Capture!";
            this.simpleButtonCapture.Click += new System.EventHandler(this.simpleButtonCapture_Click);
            // 
            // imageListCapture
            // 
            this.imageListCapture.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCapture.ImageStream")));
            this.imageListCapture.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCapture.Images.SetKeyName(0, "hourglass_run.png");
            this.imageListCapture.Images.SetKeyName(1, "hourglass_stop.png");
            // 
            // labelControlCaptureDescription
            // 
            this.labelControlCaptureDescription.Location = new System.Drawing.Point(12, 27);
            this.labelControlCaptureDescription.Name = "labelControlCaptureDescription";
            this.labelControlCaptureDescription.Size = new System.Drawing.Size(301, 78);
            this.labelControlCaptureDescription.TabIndex = 2;
            this.labelControlCaptureDescription.Text = resources.GetString("labelControlCaptureDescription.Text");
            // 
            // labelControlHeader
            // 
            this.labelControlHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlHeader.Appearance.Options.UseFont = true;
            this.labelControlHeader.Appearance.Options.UseTextOptions = true;
            this.labelControlHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlHeader.Location = new System.Drawing.Point(12, 2);
            this.labelControlHeader.Name = "labelControlHeader";
            this.labelControlHeader.Size = new System.Drawing.Size(435, 31);
            this.labelControlHeader.TabIndex = 3;
            this.labelControlHeader.Text = "Capture";
            // 
            // gridControlCapture
            // 
            this.gridControlCapture.Location = new System.Drawing.Point(12, 207);
            this.gridControlCapture.MainView = this.gridViewCapture;
            this.gridControlCapture.Name = "gridControlCapture";
            this.gridControlCapture.Size = new System.Drawing.Size(435, 111);
            this.gridControlCapture.TabIndex = 4;
            this.gridControlCapture.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCapture});
            // 
            // gridViewCapture
            // 
            this.gridViewCapture.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnPath,
            this.gridColumnPriority});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.gridColumnPriority;
            gridFormatRule2.Name = "FormatProgram";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = 0;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.gridViewCapture.FormatRules.Add(gridFormatRule2);
            this.gridViewCapture.GridControl = this.gridControlCapture;
            this.gridViewCapture.Name = "gridViewCapture";
            this.gridViewCapture.OptionsBehavior.Editable = false;
            this.gridViewCapture.OptionsView.ShowGroupPanel = false;
            this.gridViewCapture.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewCapture_FocusedRowChanged);
            // 
            // gridColumnPath
            // 
            this.gridColumnPath.Caption = "Path";
            this.gridColumnPath.FieldName = "Path";
            this.gridColumnPath.MaxWidth = 400;
            this.gridColumnPath.MinWidth = 10;
            this.gridColumnPath.Name = "gridColumnPath";
            this.gridColumnPath.Visible = true;
            this.gridColumnPath.VisibleIndex = 0;
            this.gridColumnPath.Width = 400;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCancel.ImageOptions.Image")));
            this.simpleButtonCancel.Location = new System.Drawing.Point(357, 324);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(90, 34);
            this.simpleButtonCancel.TabIndex = 5;
            this.simpleButtonCancel.Text = "Cancel";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonNext
            // 
            this.simpleButtonNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonNext.ImageOptions.Image")));
            this.simpleButtonNext.Location = new System.Drawing.Point(261, 324);
            this.simpleButtonNext.Name = "simpleButtonNext";
            this.simpleButtonNext.Size = new System.Drawing.Size(90, 34);
            this.simpleButtonNext.TabIndex = 6;
            this.simpleButtonNext.Text = "Next";
            this.simpleButtonNext.Click += new System.EventHandler(this.simpleButtonNext_Click);
            // 
            // CaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 364);
            this.Controls.Add(this.simpleButtonNext);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.gridControlCapture);
            this.Controls.Add(this.labelControlCaptureDescription);
            this.Controls.Add(this.simpleButtonCapture);
            this.Controls.Add(this.labelControlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CaptureForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCapture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonCapture;
        private System.Windows.Forms.ImageList imageListCapture;
        private DevExpress.XtraEditors.LabelControl labelControlCaptureDescription;
        private DevExpress.XtraEditors.LabelControl labelControlHeader;
        private DevExpress.XtraGrid.GridControl gridControlCapture;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCapture;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPath;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPriority;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNext;
    }
}