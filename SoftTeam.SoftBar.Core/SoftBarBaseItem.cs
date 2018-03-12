using SoftTeam.SoftBar.Core.Controls;
using SoftTeam.SoftBar.Core.Extensions;
using SoftTeam.SoftBar.Core.Forms;
using System;
using System.Drawing;
using System.IO;

namespace SoftTeam.SoftBar.Core
{
    public abstract class SoftBarBaseItem
    {
        #region Fields
        private MainAppBarForm _form = null;
        private string _name = "";
        private bool _systemMenu = false;
        private Image _image = null;
        private bool _beginGroup = false;
        private string _iconPath = "";
        private bool _warning = false;
        private string _warningText = "";
        private MenuItem _customizationMenuItem = null;
        #endregion

        #region Constructors
        public SoftBarBaseItem(MainAppBarForm form, string name, bool systemMenu=false)
        {
            _form = form;
            _name = name;
            _systemMenu = systemMenu;
        }
        #endregion

        #region Properties
        public string Name { get => _name; set => _name = value; }
        public MainAppBarForm Form { get => _form; set => _form = value; }
        public bool SystemMenu { get => _systemMenu; set => _systemMenu = value; }
        public Image Image { get => _image; set => _image = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }
        public string IconPath { get => _iconPath; set { _iconPath = value; UpdateImage(); } }
        public bool Warning { get => _warning; set => _warning = value; }
        public string WarningText { get => _warningText; set => _warningText = value; }
        public MenuItem CustomizationMenuItem { get => _customizationMenuItem; set => _customizationMenuItem = value; }
        #endregion

        #region Misc functions
        private void UpdateImage()
        {
            // If we have a potential icon...
            if (!string.IsNullOrEmpty(IconPath))
            {
                try
                {
                    if (!File.Exists(IconPath))
                    {
                        // Set warning message
                        Warning = true;
                        WarningText = "IconPath does not exist!";
                        // Return an error image
                        Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
                    }
                    else
                    {
                        // Extract the icon...
                        Image iconImage = Icon.ExtractAssociatedIcon(IconPath).ToBitmap();
                        // and return an 16x16 image
                        Image = iconImage.ResizeImage(16, 16);
                    }
                }
                catch (Exception ex)
                {
                    // Set warning message
                    Warning = true;
                    WarningText = $"Unknown icon exception! : \n\n{ex.Message}";

                    // Return an error image
                    Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
                }
            }
            else
                // Return no image
                Image = null;
        }
        #endregion

    }
}
