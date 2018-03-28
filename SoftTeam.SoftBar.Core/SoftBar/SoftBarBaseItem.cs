using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;
using System;
using System.Drawing;
using System.IO;

namespace SoftTeam.SoftBar.Core.SoftBar
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
        #endregion

        #region Misc functions
        private void UpdateImage()
        {
            try
            {
                Image image = HelperFunctions.GetFileImage(IconPath, ImageSize.Small);

                if (image == null)
                    // Return an error image
                    Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
                else
                    // Return the correct image
                    Image = image;
            }
            catch
            {
                // Return an error image
                Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
            }
        }
        #endregion
    }
}
