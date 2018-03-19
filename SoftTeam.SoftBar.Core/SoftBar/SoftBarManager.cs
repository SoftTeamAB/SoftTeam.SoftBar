using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Core.SoftBar
{
    public class SoftBarManager
    {
        #region Fields
        private SoftBarArea _systemArea = null;
        private SoftBarArea _userArea = null;
        private MainAppBarForm _form = null;
        private string _path = "";

        public MainAppBarForm Form { get => _form; set => _form = value; }
        public SoftBarArea UserArea { get => _userArea; set => _userArea = value; }
        public SoftBarArea SystemArea { get => _systemArea; set => _systemArea = value; }
        #endregion

        #region Constructor
        public SoftBarManager(MainAppBarForm form, string path)
        {
            _form = form;
            _path = path;

            _systemArea = new SoftBarArea(form, AreaType.System, path);
            _userArea = new SoftBarArea(form, AreaType.User, path, _systemArea.Width);
        }
        #endregion
    }
}
