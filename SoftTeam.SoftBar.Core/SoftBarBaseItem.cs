using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core
{
    public class SoftBarBaseItem
    {
        private MainAppBarForm _form = null;
        private string _name = "";
        private bool _beginGroup = false;
        private bool _systemMenu = false;
        private Image _image = null;

        public SoftBarBaseItem(MainAppBarForm form, string name, bool beginGroup = false, bool systemMenu=false)
        {
            _form = form;
            _name = name;
            _beginGroup = beginGroup;
            _systemMenu = systemMenu;
        }

        public string Name { get => _name; set => _name = value; }
        public MainAppBarForm Form { get => _form; set => _form = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }
        public bool SystemMenu { get => _systemMenu; set => _systemMenu = value; }
        public Image Image { get => _image; set => _image = value; }
    }
}
