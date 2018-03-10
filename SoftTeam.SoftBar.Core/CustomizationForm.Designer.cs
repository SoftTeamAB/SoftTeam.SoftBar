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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizationForm));
            this.xtraScrollableControlMenu = new DevExpress.XtraEditors.XtraScrollableControl();
            this.barManagerCustomization = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barSubItemFile = new DevExpress.XtraBars.BarSubItem();
            this.barStaticItemFileExitWithoutSave = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItemAddMenu = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemPathHeader = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemPath = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItemAddMenuItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddHeaderItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddSubMenu = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerCustomization)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraScrollableControlMenu
            // 
            this.xtraScrollableControlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControlMenu.Location = new System.Drawing.Point(0, 51);
            this.xtraScrollableControlMenu.Name = "xtraScrollableControlMenu";
            this.xtraScrollableControlMenu.Size = new System.Drawing.Size(754, 440);
            this.xtraScrollableControlMenu.TabIndex = 0;
            // 
            // barManagerCustomization
            // 
            this.barManagerCustomization.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManagerCustomization.DockControls.Add(this.barDockControlTop);
            this.barManagerCustomization.DockControls.Add(this.barDockControlBottom);
            this.barManagerCustomization.DockControls.Add(this.barDockControlLeft);
            this.barManagerCustomization.DockControls.Add(this.barDockControlRight);
            this.barManagerCustomization.Form = this;
            this.barManagerCustomization.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.barSubItemFile,
            this.barStaticItemFileExitWithoutSave,
            this.barButtonItemAddMenu,
            this.barStaticItemPathHeader,
            this.barStaticItemPath,
            this.barButtonItemAddMenuItem,
            this.barButtonItemAddHeaderItem,
            this.barButtonItemAddSubMenu,
            this.barSubItem1,
            this.barStaticItem2,
            this.barStaticItem3,
            this.barStaticItem4,
            this.barStaticItem5});
            this.barManagerCustomization.MainMenu = this.bar2;
            this.barManagerCustomization.MaxItemId = 14;
            this.barManagerCustomization.StatusBar = this.bar3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManagerCustomization;
            this.barDockControlTop.Size = new System.Drawing.Size(754, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 491);
            this.barDockControlBottom.Manager = this.barManagerCustomization;
            this.barDockControlBottom.Size = new System.Drawing.Size(754, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Manager = this.barManagerCustomization;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 440);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(754, 51);
            this.barDockControlRight.Manager = this.barManagerCustomization;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 440);
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemAddMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemAddMenuItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemAddHeaderItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemAddSubMenu)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemPathHeader),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemPath)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barSubItemFile
            // 
            this.barSubItemFile.Caption = "File";
            this.barSubItemFile.Id = 1;
            this.barSubItemFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemFileExitWithoutSave)});
            this.barSubItemFile.Name = "barSubItemFile";
            // 
            // barStaticItemFileExitWithoutSave
            // 
            this.barStaticItemFileExitWithoutSave.Caption = "Exit (without save)";
            this.barStaticItemFileExitWithoutSave.Id = 2;
            this.barStaticItemFileExitWithoutSave.Name = "barStaticItemFileExitWithoutSave";
            this.barStaticItemFileExitWithoutSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barStaticItemFileExitWithoutSave_ItemClick);
            // 
            // barButtonItemAddMenu
            // 
            this.barButtonItemAddMenu.Caption = "Add menu";
            this.barButtonItemAddMenu.Id = 3;
            this.barButtonItemAddMenu.Name = "barButtonItemAddMenu";
            // 
            // barStaticItemPathHeader
            // 
            this.barStaticItemPathHeader.Caption = "SoftBar.xml path : ";
            this.barStaticItemPathHeader.Id = 4;
            this.barStaticItemPathHeader.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItemPathHeader.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItemPathHeader.Name = "barStaticItemPathHeader";
            // 
            // barStaticItemPath
            // 
            this.barStaticItemPath.Caption = "[path]";
            this.barStaticItemPath.Id = 5;
            this.barStaticItemPath.Name = "barStaticItemPath";
            // 
            // barButtonItemAddMenuItem
            // 
            this.barButtonItemAddMenuItem.Caption = "Add menu item";
            this.barButtonItemAddMenuItem.Id = 6;
            this.barButtonItemAddMenuItem.Name = "barButtonItemAddMenuItem";
            // 
            // barButtonItemAddHeaderItem
            // 
            this.barButtonItemAddHeaderItem.Caption = "Add header item";
            this.barButtonItemAddHeaderItem.Id = 7;
            this.barButtonItemAddHeaderItem.Name = "barButtonItemAddHeaderItem";
            // 
            // barButtonItemAddSubMenu
            // 
            this.barButtonItemAddSubMenu.Caption = "Add sub menu";
            this.barButtonItemAddSubMenu.Id = 8;
            this.barButtonItemAddSubMenu.Name = "barButtonItemAddSubMenu";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Add";
            this.barSubItem1.Id = 9;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem5)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "Add menu";
            this.barStaticItem2.Id = 10;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "Add sub menu";
            this.barStaticItem3.Id = 11;
            this.barStaticItem3.Name = "barStaticItem3";
            // 
            // barStaticItem4
            // 
            this.barStaticItem4.Caption = "Add menu item";
            this.barStaticItem4.Id = 12;
            this.barStaticItem4.Name = "barStaticItem4";
            // 
            // barStaticItem5
            // 
            this.barStaticItem5.Caption = "Add header item";
            this.barStaticItem5.Id = 13;
            this.barStaticItem5.Name = "barStaticItem5";
            // 
            // CustomizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 516);
            this.Controls.Add(this.xtraScrollableControlMenu);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomizationForm";
            this.Text = "SoftBar customization form";
            this.Load += new System.EventHandler(this.CustomizationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManagerCustomization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControlMenu;
        private DevExpress.XtraBars.BarManager barManagerCustomization;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddMenu;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarSubItem barSubItemFile;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFileExitWithoutSave;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem barStaticItemPathHeader;
        private DevExpress.XtraBars.BarStaticItem barStaticItemPath;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddMenuItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddHeaderItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddSubMenu;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.BarStaticItem barStaticItem5;
    }
}