namespace SoftTeam.SoftBar.Core.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabPaneSettings = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPageDirectories = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.checkEditSpecialVideos = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditSpecialPictures = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditSpecialMusic = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditSpecialDownloads = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditSpecialDocuments = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditSpecialDesktop = new DevExpress.XtraEditors.CheckEdit();
            this.labelControlSpecialFoldersHeader = new DevExpress.XtraEditors.LabelControl();
            this.labelControlDriveTypesHeader = new DevExpress.XtraEditors.LabelControl();
            this.checkEditNetworkDrives = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditCDRom = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditRemovableDrives = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditFixedDrives = new DevExpress.XtraEditors.CheckEdit();
            this.tabNavigationPageMyDirectories = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.listBoxControlMyDirectories = new DevExpress.XtraEditors.ListBoxControl();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlMyDirectoriesHeader = new DevExpress.XtraEditors.LabelControl();
            this.tabNavigationPageGeneral = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.checkEditShowDirectoriesMenu = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditShowToolsMenu = new DevExpress.XtraEditors.CheckEdit();
            this.tabNavigationPageTools = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControlToolsHeader = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonAddDirectory = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonEditDirectory = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRemove = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRemoveTool = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAddTool = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneSettings)).BeginInit();
            this.tabPaneSettings.SuspendLayout();
            this.tabNavigationPageDirectories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSpecialVideos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSpecialPictures.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSpecialMusic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSpecialDownloads.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSpecialDocuments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSpecialDesktop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditNetworkDrives.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditCDRom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditRemovableDrives.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditFixedDrives.Properties)).BeginInit();
            this.tabNavigationPageMyDirectories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlMyDirectories)).BeginInit();
            this.tabNavigationPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShowDirectoriesMenu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShowToolsMenu.Properties)).BeginInit();
            this.tabNavigationPageTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPaneSettings
            // 
            this.tabPaneSettings.Controls.Add(this.tabNavigationPageDirectories);
            this.tabPaneSettings.Controls.Add(this.tabNavigationPageMyDirectories);
            this.tabPaneSettings.Controls.Add(this.tabNavigationPageGeneral);
            this.tabPaneSettings.Controls.Add(this.tabNavigationPageTools);
            this.tabPaneSettings.Location = new System.Drawing.Point(12, 12);
            this.tabPaneSettings.Name = "tabPaneSettings";
            this.tabPaneSettings.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPageGeneral,
            this.tabNavigationPageDirectories,
            this.tabNavigationPageMyDirectories,
            this.tabNavigationPageTools});
            this.tabPaneSettings.RegularSize = new System.Drawing.Size(607, 372);
            this.tabPaneSettings.SelectedPage = this.tabNavigationPageMyDirectories;
            this.tabPaneSettings.Size = new System.Drawing.Size(607, 372);
            this.tabPaneSettings.TabIndex = 0;
            // 
            // tabNavigationPageDirectories
            // 
            this.tabNavigationPageDirectories.Caption = "Directories";
            this.tabNavigationPageDirectories.Controls.Add(this.checkEditSpecialVideos);
            this.tabNavigationPageDirectories.Controls.Add(this.checkEditSpecialPictures);
            this.tabNavigationPageDirectories.Controls.Add(this.checkEditSpecialMusic);
            this.tabNavigationPageDirectories.Controls.Add(this.checkEditSpecialDownloads);
            this.tabNavigationPageDirectories.Controls.Add(this.checkEditSpecialDocuments);
            this.tabNavigationPageDirectories.Controls.Add(this.checkEditSpecialDesktop);
            this.tabNavigationPageDirectories.Controls.Add(this.labelControlSpecialFoldersHeader);
            this.tabNavigationPageDirectories.Controls.Add(this.labelControlDriveTypesHeader);
            this.tabNavigationPageDirectories.Controls.Add(this.checkEditNetworkDrives);
            this.tabNavigationPageDirectories.Controls.Add(this.checkEditCDRom);
            this.tabNavigationPageDirectories.Controls.Add(this.checkEditRemovableDrives);
            this.tabNavigationPageDirectories.Controls.Add(this.checkEditFixedDrives);
            this.tabNavigationPageDirectories.Name = "tabNavigationPageDirectories";
            this.tabNavigationPageDirectories.Size = new System.Drawing.Size(607, 372);
            // 
            // checkEditSpecialVideos
            // 
            this.checkEditSpecialVideos.Location = new System.Drawing.Point(16, 299);
            this.checkEditSpecialVideos.Name = "checkEditSpecialVideos";
            this.checkEditSpecialVideos.Properties.Caption = "Videos";
            this.checkEditSpecialVideos.Size = new System.Drawing.Size(266, 19);
            this.checkEditSpecialVideos.TabIndex = 11;
            // 
            // checkEditSpecialPictures
            // 
            this.checkEditSpecialPictures.Location = new System.Drawing.Point(16, 274);
            this.checkEditSpecialPictures.Name = "checkEditSpecialPictures";
            this.checkEditSpecialPictures.Properties.Caption = "Pictures";
            this.checkEditSpecialPictures.Size = new System.Drawing.Size(266, 19);
            this.checkEditSpecialPictures.TabIndex = 10;
            // 
            // checkEditSpecialMusic
            // 
            this.checkEditSpecialMusic.Location = new System.Drawing.Point(16, 249);
            this.checkEditSpecialMusic.Name = "checkEditSpecialMusic";
            this.checkEditSpecialMusic.Properties.Caption = "Music";
            this.checkEditSpecialMusic.Size = new System.Drawing.Size(266, 19);
            this.checkEditSpecialMusic.TabIndex = 9;
            // 
            // checkEditSpecialDownloads
            // 
            this.checkEditSpecialDownloads.EditValue = true;
            this.checkEditSpecialDownloads.Location = new System.Drawing.Point(16, 224);
            this.checkEditSpecialDownloads.Name = "checkEditSpecialDownloads";
            this.checkEditSpecialDownloads.Properties.Caption = "Downloads";
            this.checkEditSpecialDownloads.Size = new System.Drawing.Size(266, 19);
            this.checkEditSpecialDownloads.TabIndex = 8;
            // 
            // checkEditSpecialDocuments
            // 
            this.checkEditSpecialDocuments.EditValue = true;
            this.checkEditSpecialDocuments.Location = new System.Drawing.Point(16, 199);
            this.checkEditSpecialDocuments.Name = "checkEditSpecialDocuments";
            this.checkEditSpecialDocuments.Properties.Caption = "Documents";
            this.checkEditSpecialDocuments.Size = new System.Drawing.Size(266, 19);
            this.checkEditSpecialDocuments.TabIndex = 7;
            // 
            // checkEditSpecialDesktop
            // 
            this.checkEditSpecialDesktop.EditValue = true;
            this.checkEditSpecialDesktop.Location = new System.Drawing.Point(16, 174);
            this.checkEditSpecialDesktop.Name = "checkEditSpecialDesktop";
            this.checkEditSpecialDesktop.Properties.Caption = "Desktop";
            this.checkEditSpecialDesktop.Size = new System.Drawing.Size(266, 19);
            this.checkEditSpecialDesktop.TabIndex = 6;
            // 
            // labelControlSpecialFoldersHeader
            // 
            this.labelControlSpecialFoldersHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlSpecialFoldersHeader.Appearance.Options.UseFont = true;
            this.labelControlSpecialFoldersHeader.Location = new System.Drawing.Point(16, 155);
            this.labelControlSpecialFoldersHeader.Name = "labelControlSpecialFoldersHeader";
            this.labelControlSpecialFoldersHeader.Size = new System.Drawing.Size(195, 13);
            this.labelControlSpecialFoldersHeader.TabIndex = 5;
            this.labelControlSpecialFoldersHeader.Text = "Show the following special folders :";
            // 
            // labelControlDriveTypesHeader
            // 
            this.labelControlDriveTypesHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlDriveTypesHeader.Appearance.Options.UseFont = true;
            this.labelControlDriveTypesHeader.Location = new System.Drawing.Point(16, 16);
            this.labelControlDriveTypesHeader.Name = "labelControlDriveTypesHeader";
            this.labelControlDriveTypesHeader.Size = new System.Drawing.Size(312, 13);
            this.labelControlDriveTypesHeader.TabIndex = 4;
            this.labelControlDriveTypesHeader.Text = "Show the following drive types in the directories menu :";
            // 
            // checkEditNetworkDrives
            // 
            this.checkEditNetworkDrives.EditValue = true;
            this.checkEditNetworkDrives.Location = new System.Drawing.Point(16, 110);
            this.checkEditNetworkDrives.Name = "checkEditNetworkDrives";
            this.checkEditNetworkDrives.Properties.Caption = "Mapped network drives";
            this.checkEditNetworkDrives.Size = new System.Drawing.Size(266, 19);
            this.checkEditNetworkDrives.TabIndex = 3;
            // 
            // checkEditCDRom
            // 
            this.checkEditCDRom.EditValue = true;
            this.checkEditCDRom.Location = new System.Drawing.Point(16, 85);
            this.checkEditCDRom.Name = "checkEditCDRom";
            this.checkEditCDRom.Properties.Caption = "CD Rom drives";
            this.checkEditCDRom.Size = new System.Drawing.Size(266, 19);
            this.checkEditCDRom.TabIndex = 2;
            // 
            // checkEditRemovableDrives
            // 
            this.checkEditRemovableDrives.EditValue = true;
            this.checkEditRemovableDrives.Location = new System.Drawing.Point(16, 60);
            this.checkEditRemovableDrives.Name = "checkEditRemovableDrives";
            this.checkEditRemovableDrives.Properties.Caption = "Removable drives (floppy, USB)";
            this.checkEditRemovableDrives.Size = new System.Drawing.Size(266, 19);
            this.checkEditRemovableDrives.TabIndex = 1;
            // 
            // checkEditFixedDrives
            // 
            this.checkEditFixedDrives.EditValue = true;
            this.checkEditFixedDrives.Location = new System.Drawing.Point(16, 35);
            this.checkEditFixedDrives.Name = "checkEditFixedDrives";
            this.checkEditFixedDrives.Properties.Caption = "Fixed drives";
            this.checkEditFixedDrives.Size = new System.Drawing.Size(266, 19);
            this.checkEditFixedDrives.TabIndex = 0;
            // 
            // tabNavigationPageMyDirectories
            // 
            this.tabNavigationPageMyDirectories.Caption = "My directories";
            this.tabNavigationPageMyDirectories.Controls.Add(this.labelControlMyDirectoriesHeader);
            this.tabNavigationPageMyDirectories.Controls.Add(this.listBoxControlMyDirectories);
            this.tabNavigationPageMyDirectories.Controls.Add(this.simpleButtonAddDirectory);
            this.tabNavigationPageMyDirectories.Controls.Add(this.simpleButtonEditDirectory);
            this.tabNavigationPageMyDirectories.Controls.Add(this.simpleButtonRemove);
            this.tabNavigationPageMyDirectories.Name = "tabNavigationPageMyDirectories";
            this.tabNavigationPageMyDirectories.Size = new System.Drawing.Size(589, 327);
            // 
            // listBoxControlMyDirectories
            // 
            this.listBoxControlMyDirectories.Location = new System.Drawing.Point(20, 82);
            this.listBoxControlMyDirectories.Name = "listBoxControlMyDirectories";
            this.listBoxControlMyDirectories.Size = new System.Drawing.Size(551, 225);
            this.listBoxControlMyDirectories.TabIndex = 0;
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Location = new System.Drawing.Point(436, 376);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(75, 32);
            this.simpleButtonSave.TabIndex = 1;
            this.simpleButtonSave.Text = "Save";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(517, 376);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 32);
            this.simpleButtonCancel.TabIndex = 2;
            this.simpleButtonCancel.Text = "Cancel";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // labelControlMyDirectoriesHeader
            // 
            this.labelControlMyDirectoriesHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlMyDirectoriesHeader.Appearance.Options.UseFont = true;
            this.labelControlMyDirectoriesHeader.Location = new System.Drawing.Point(20, 13);
            this.labelControlMyDirectoriesHeader.Name = "labelControlMyDirectoriesHeader";
            this.labelControlMyDirectoriesHeader.Size = new System.Drawing.Size(438, 13);
            this.labelControlMyDirectoriesHeader.TabIndex = 4;
            this.labelControlMyDirectoriesHeader.Text = "Add any additional directories that you want to show in the directories menu :";
            // 
            // tabNavigationPageGeneral
            // 
            this.tabNavigationPageGeneral.Caption = "General";
            this.tabNavigationPageGeneral.Controls.Add(this.checkEditShowToolsMenu);
            this.tabNavigationPageGeneral.Controls.Add(this.checkEditShowDirectoriesMenu);
            this.tabNavigationPageGeneral.Name = "tabNavigationPageGeneral";
            this.tabNavigationPageGeneral.Size = new System.Drawing.Size(589, 327);
            // 
            // checkEditShowDirectoriesMenu
            // 
            this.checkEditShowDirectoriesMenu.Location = new System.Drawing.Point(28, 24);
            this.checkEditShowDirectoriesMenu.Name = "checkEditShowDirectoriesMenu";
            this.checkEditShowDirectoriesMenu.Properties.Caption = "Show directories menu";
            this.checkEditShowDirectoriesMenu.Size = new System.Drawing.Size(272, 19);
            this.checkEditShowDirectoriesMenu.TabIndex = 0;
            // 
            // checkEditShowToolsMenu
            // 
            this.checkEditShowToolsMenu.Location = new System.Drawing.Point(28, 49);
            this.checkEditShowToolsMenu.Name = "checkEditShowToolsMenu";
            this.checkEditShowToolsMenu.Properties.Caption = "Show tools menu";
            this.checkEditShowToolsMenu.Size = new System.Drawing.Size(272, 19);
            this.checkEditShowToolsMenu.TabIndex = 1;
            // 
            // tabNavigationPageTools
            // 
            this.tabNavigationPageTools.Caption = "Tools";
            this.tabNavigationPageTools.Controls.Add(this.labelControlToolsHeader);
            this.tabNavigationPageTools.Controls.Add(this.listBoxControl1);
            this.tabNavigationPageTools.Controls.Add(this.simpleButtonRemoveTool);
            this.tabNavigationPageTools.Controls.Add(this.simpleButtonAddTool);
            this.tabNavigationPageTools.Name = "tabNavigationPageTools";
            this.tabNavigationPageTools.Size = new System.Drawing.Size(589, 327);
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Location = new System.Drawing.Point(14, 64);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(557, 238);
            this.listBoxControl1.TabIndex = 2;
            // 
            // labelControlToolsHeader
            // 
            this.labelControlToolsHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlToolsHeader.Appearance.Options.UseFont = true;
            this.labelControlToolsHeader.Location = new System.Drawing.Point(14, 7);
            this.labelControlToolsHeader.Name = "labelControlToolsHeader";
            this.labelControlToolsHeader.Size = new System.Drawing.Size(423, 13);
            this.labelControlToolsHeader.TabIndex = 3;
            this.labelControlToolsHeader.Text = "Add any tools (Windows  or Non-Windows) that you want in the tools menu:";
            // 
            // simpleButtonAddDirectory
            // 
            this.simpleButtonAddDirectory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonAddDirectory.ImageOptions.Image")));
            this.simpleButtonAddDirectory.Location = new System.Drawing.Point(20, 44);
            this.simpleButtonAddDirectory.Name = "simpleButtonAddDirectory";
            this.simpleButtonAddDirectory.Size = new System.Drawing.Size(75, 32);
            this.simpleButtonAddDirectory.TabIndex = 3;
            this.simpleButtonAddDirectory.Text = "Add";
            this.simpleButtonAddDirectory.Click += new System.EventHandler(this.simpleButtonAddDirectory_Click);
            // 
            // simpleButtonEditDirectory
            // 
            this.simpleButtonEditDirectory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonEditDirectory.ImageOptions.Image")));
            this.simpleButtonEditDirectory.Location = new System.Drawing.Point(101, 44);
            this.simpleButtonEditDirectory.Name = "simpleButtonEditDirectory";
            this.simpleButtonEditDirectory.Size = new System.Drawing.Size(75, 32);
            this.simpleButtonEditDirectory.TabIndex = 2;
            this.simpleButtonEditDirectory.Text = "Edit";
            this.simpleButtonEditDirectory.Click += new System.EventHandler(this.simpleButtonEditDirectory_Click);
            // 
            // simpleButtonRemove
            // 
            this.simpleButtonRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonRemove.ImageOptions.Image")));
            this.simpleButtonRemove.Location = new System.Drawing.Point(496, 44);
            this.simpleButtonRemove.Name = "simpleButtonRemove";
            this.simpleButtonRemove.Size = new System.Drawing.Size(75, 32);
            this.simpleButtonRemove.TabIndex = 1;
            this.simpleButtonRemove.Text = "Remove";
            this.simpleButtonRemove.Click += new System.EventHandler(this.simpleButtonRemove_Click);
            // 
            // simpleButtonRemoveTool
            // 
            this.simpleButtonRemoveTool.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonRemoveTool.ImageOptions.Image")));
            this.simpleButtonRemoveTool.Location = new System.Drawing.Point(496, 26);
            this.simpleButtonRemoveTool.Name = "simpleButtonRemoveTool";
            this.simpleButtonRemoveTool.Size = new System.Drawing.Size(75, 32);
            this.simpleButtonRemoveTool.TabIndex = 1;
            this.simpleButtonRemoveTool.Text = "Remove";
            // 
            // simpleButtonAddTool
            // 
            this.simpleButtonAddTool.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonAddTool.ImageOptions.Image")));
            this.simpleButtonAddTool.Location = new System.Drawing.Point(14, 26);
            this.simpleButtonAddTool.Name = "simpleButtonAddTool";
            this.simpleButtonAddTool.Size = new System.Drawing.Size(75, 32);
            this.simpleButtonAddTool.TabIndex = 0;
            this.simpleButtonAddTool.Text = "Add";
            this.simpleButtonAddTool.Click += new System.EventHandler(this.simpleButtonAddTool_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 425);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonSave);
            this.Controls.Add(this.tabPaneSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneSettings)).EndInit();
            this.tabPaneSettings.ResumeLayout(false);
            this.tabNavigationPageDirectories.ResumeLayout(false);
            this.tabNavigationPageDirectories.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSpecialVideos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSpecialPictures.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSpecialMusic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSpecialDownloads.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSpecialDocuments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSpecialDesktop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditNetworkDrives.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditCDRom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditRemovableDrives.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditFixedDrives.Properties)).EndInit();
            this.tabNavigationPageMyDirectories.ResumeLayout(false);
            this.tabNavigationPageMyDirectories.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlMyDirectories)).EndInit();
            this.tabNavigationPageGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShowDirectoriesMenu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShowToolsMenu.Properties)).EndInit();
            this.tabNavigationPageTools.ResumeLayout(false);
            this.tabNavigationPageTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabPane tabPaneSettings;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageDirectories;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageMyDirectories;
        private DevExpress.XtraEditors.LabelControl labelControlDriveTypesHeader;
        private DevExpress.XtraEditors.CheckEdit checkEditNetworkDrives;
        private DevExpress.XtraEditors.CheckEdit checkEditCDRom;
        private DevExpress.XtraEditors.CheckEdit checkEditRemovableDrives;
        private DevExpress.XtraEditors.CheckEdit checkEditFixedDrives;
        private DevExpress.XtraEditors.CheckEdit checkEditSpecialVideos;
        private DevExpress.XtraEditors.CheckEdit checkEditSpecialPictures;
        private DevExpress.XtraEditors.CheckEdit checkEditSpecialMusic;
        private DevExpress.XtraEditors.CheckEdit checkEditSpecialDownloads;
        private DevExpress.XtraEditors.CheckEdit checkEditSpecialDocuments;
        private DevExpress.XtraEditors.CheckEdit checkEditSpecialDesktop;
        private DevExpress.XtraEditors.LabelControl labelControlSpecialFoldersHeader;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddDirectory;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEditDirectory;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRemove;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlMyDirectories;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.LabelControl labelControlMyDirectoriesHeader;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageGeneral;
        private DevExpress.XtraEditors.CheckEdit checkEditShowDirectoriesMenu;
        private DevExpress.XtraEditors.CheckEdit checkEditShowToolsMenu;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageTools;
        private DevExpress.XtraEditors.LabelControl labelControlToolsHeader;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRemoveTool;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddTool;
    }
}