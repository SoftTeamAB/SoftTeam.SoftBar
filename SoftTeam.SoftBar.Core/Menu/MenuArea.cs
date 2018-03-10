using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Drawing;

namespace SoftTeam.SoftBar.Core
{
    internal class MenuArea
    {
        private ApplicationBar _parent;
        private string _name;
        private int _left = 0;
        private int _width = 0;
        private List<Menu> _menus = new List<Menu>();

        private const int SEPARATOR_WIDTH = 0;

        public MenuArea(ApplicationBar parent,string name, int left = 0)
        {
            _parent = parent;
            _name = name;
            _left = left;
        }

        public ApplicationBar Parent
        {
            get { return _parent; }
        }

        public int Left
        {
            get { return _left; }
        }

        public int Width
        {
            get { return _width; }
        }

        public Menu AddMenu(string name)
        {
            Menu newMenu = new Menu(this,name, name.Length * 10);
            newMenu.Button = AddButton(name);
            newMenu.PopupMenu = AddPopupMenu(name);
            newMenu.Setup();
            newMenu.Left = GetCurrentWidth();
            _width = name.Length * 10;
            _menus.Add(newMenu);
            

            return newMenu;
        }

        private SimpleButton AddButton(string name)
        {
            // Create a button for the menu
            SimpleButton button = new SimpleButton();
            button.Text = name;
            button.Visible = true;
            button.Location = new Point(GetCurrentWidth(), 0);
            button.Width = name.Length * 10;
            button.Height = 32;
            button.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            
            // Add the button to the form
            _parent.Form.Controls.Add(button);

            return button;
        }

        private PopupMenu AddPopupMenu(string name)
        {
            // Create an empty menu and return it
            PopupMenu menu = new PopupMenu(_parent.Form.barManagerSoftBar);
            return menu;
        }

        private int GetCurrentWidth()
        {
            int width = _left + SEPARATOR_WIDTH;

            foreach (var menu in _menus)
                width += menu.Width + SEPARATOR_WIDTH;

            return width;
        }
    }
}
