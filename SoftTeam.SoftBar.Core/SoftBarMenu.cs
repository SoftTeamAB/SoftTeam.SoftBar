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
    public class SoftBarMenu:SoftBarBaseMenu
    {
        #region Fields

        private int _width;
        private int _left;
        private string _iconPath = "";
        private PopupMenu _popupMenu = null;

        private SimpleButton _button = null;
        #endregion

        #region Constructor
        public SoftBarMenu(MainAppBarForm form, string name, int left, bool systemMenu = false) : base(form,name,systemMenu)
        {
            _left = left;
            Width = Name.Length * 10;
            ParentMenu = null;
            ParentSubMenu = null;
        }
        #endregion

        #region Properties
        public int Width { get => _width; set => _width = value; }
        public int Left { get => _left; set => _left = value; }
        public string IconPath { get => _iconPath; set { _iconPath = value; UpdateImage(); } }
        public PopupMenu PopupMenu { get => _popupMenu; set => _popupMenu = value; }

        public SimpleButton Button { get => _button; set => _button = value; }
        #endregion

        private void UpdateImage()
        {
            if (!string.IsNullOrEmpty(IconPath))
            {
                Image image = Icon.ExtractAssociatedIcon(IconPath).ToBitmap();
                Image = image.ResizeImage(16, 16);
            }
            else
                Image = null;
        }
        #region CreateMenu

        public void Setup()
        {
            Button = AddButton(Name);
            PopupMenu = AddPopupMenu();

            ParentMenu = PopupMenu;
            ParentSubMenu = null;

            if (SystemMenu) return;

            Button.Click += Button_Click;
        }

        public override void AddSubMenu(BarSubItem subMenu)
        {
            PopupMenu.AddItem(subMenu);
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
            Form.Controls.Add(button);

            return button;
        }

        private PopupMenu AddPopupMenu()
        {
            // Create an empty menu and return it
            PopupMenu menu = new PopupMenu(Form.barManagerSoftBar);
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
