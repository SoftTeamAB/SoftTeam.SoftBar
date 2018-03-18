using System;
using System.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Xml;

namespace SoftTeam.SoftBar.Core
{
    public class SoftBarMenu:SoftBarBaseMenu
    {
        #region Fields
        private int _width;
        private int _left;
        private PopupMenu _popupMenu = null;
        private SimpleButton _button = null;
        #endregion

        #region Constructor
        // Old constructor - REMOVE
        public SoftBarMenu(MainAppBarForm form, string name, int left, bool systemMenu = false) : base(form,name,systemMenu)
        {
            _left = left;
            _width = name.Length * 10;
            ParentPopupMenu = null;
            ParentSubMenu = null;
        }
        // New constructor
        public SoftBarMenu(MainAppBarForm form, XmlMenu menu, bool systemMenu = false) : base(form, menu.Name, systemMenu)
        {
            _left = 0;
            _width = menu.Name.Length * 10;
            IconPath = menu.IconPath;
            BeginGroup = menu.BeginGroup;
            ParentPopupMenu = null;
            ParentSubMenu = null;
        }
        #endregion

        #region Properties
        public int Width { get => _width; set => _width = value; }
        public int Left { get => _left; set => _left = value; }
        public PopupMenu Item { get => _popupMenu; set => _popupMenu = value; }
        public SimpleButton Button { get => _button; set => _button = value; }
        #endregion

        #region Setup
        public PopupMenu Setup()
        {
            Button = AddButton(Name);
            Item = AddPopupMenu();

            if (!SystemMenu) Button.Click += Button_Click;

            return Item;
        }

        //public override void AddSubMenu(BarSubItem subMenu)
        //{
        //    Item.AddItem(subMenu);
        //}

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
            Item.ShowPopup(new Point(_left, 0));
        }
        #endregion
    }
}
