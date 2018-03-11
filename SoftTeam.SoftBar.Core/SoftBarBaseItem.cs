using SoftTeam.SoftBar.Core.Forms;
using System.Drawing;

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
        #endregion
    }
}
