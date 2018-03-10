using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core
{
    public class SoftBarMenu
    {
        #region Fields
        private readonly List<SoftBarMenuItem> _menuItems = new List<SoftBarMenuItem>();

        private MainAppBarForm _form = null;
        private string _name = "";
        private int _width;
        private int _left;
        private string _iconPath = "";
        private bool _isSystemMenu = false;
        private SimpleButton _button = null;
        private PopupMenu _popupMenu = null;        
        #endregion

        #region Constructor
        public SoftBarMenu(MainAppBarForm form, string name, int left, bool isSystemMenu = false)
        {
            _form = form;            
            _left = left;
            _name = name;
            _isSystemMenu = isSystemMenu;
            Width = Name.Length * 10;
        }
        #endregion

        #region Properties
        public string Name { get => _name; set => _name = value; }
        public List<SoftBarMenuItem> MenuItems => _menuItems;
        public int Width { get => _width; set => _width = value; }
        public int Left { get => _left; set => _left = value; }
        public string IconPath { get => _iconPath; set => _iconPath = value; }
        public bool IsSystemMenu { get => _isSystemMenu; set => _isSystemMenu = value; }
        
        public SimpleButton Button { get => _button; set => _button = value; }
        public PopupMenu PopupMenu { get => _popupMenu; set => _popupMenu = value; }

        public Image Image
        {
            get
            {
                if (!string.IsNullOrEmpty(IconPath))
                {
                    //Icon ico = Icon.ExtractAssociatedIcon(path);
                    //Image image = new Icon(ico, 16, 16).ToBitmap();

                    Image image = Icon.ExtractAssociatedIcon(IconPath).ToBitmap();
                    return image.ResizeImage(16, 16);
                }
                else
                    return null;
            }
        }
        #endregion

        #region CreateMenu
        public void CreateMenu()
        {
            Button = AddButton(Name);
            PopupMenu = AddPopupMenu();

            if (!_isSystemMenu)
                Button.Click += Button_Click;
        }

        private SimpleButton AddButton(string name)
        {
            // Create a button for the menu
            SimpleButton button = new SimpleButton();
            button.Text = name;
            button.Visible = true;
            button.Location = new Point(_left, 0);
            button.Width = name.Length * 10;
            button.Height = 32;
            button.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            button.ImageOptions.Image = Image;
            // Add the button to the form
            _form.Controls.Add(button);

            return button;
        }

        private PopupMenu AddPopupMenu()
        {
            // Create an empty menu and return it
            PopupMenu menu = new PopupMenu(_form.barManagerSoftBar);
            return menu;
        }
        #endregion

        #region Events
        private void Button_Click(object sender, EventArgs e)
        {
            PopupMenu.ShowPopup(new Point(_left, 0));
        }
        #endregion
    }
}
