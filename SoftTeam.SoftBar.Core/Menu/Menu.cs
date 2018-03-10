using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core
{
    internal class Menu
    {
        private MenuArea _parent = null;
        private int _width = 0;
        private int _left = 0;
        private SimpleButton _button = null;
        private PopupMenu _popupMenu = null;
        private string _name;

        public Menu(MenuArea parent, string name, int width)
        {
            _parent = parent;
            _name = name;
            _width = width;
        }

        public MenuArea Parent
        {
            get { return _parent; }
        }

        public SimpleButton Button
        {
            get { return _button; }
            set { _button = value; }
        }

        public PopupMenu PopupMenu
        {
            get { return _popupMenu; }
            set { _popupMenu = value; }
        }

        #region Position
        public int Width
        {
            get { return _width; }
        }

        public int Left
        {
            get { return _left; }
            set { _left = value; }
        }
        #endregion

        public MenuItem AddMenuItem(string name, bool separator = false)
        {
            MenuItem item = new MenuItem(this, name);
            BarButtonItem menuItem = new BarButtonItem(_parent.Parent.Form.barManagerSoftBar,name);
            // Associate the BarButtonItem with the MenuItem
            menuItem.Tag = item;
            _popupMenu.AddItem(menuItem);
            item.Item = menuItem;

            if (separator)
                menuItem.Links[0].BeginGroup = true;

            return item;
        }

        public void Setup()
        {
            Button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            PopupMenu.ShowPopup(new Point(_left,0));
        }
    }
}
