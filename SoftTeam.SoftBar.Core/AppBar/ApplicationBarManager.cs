using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.SoftBar;
using System;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core.AppBar
{
    public class ApplicationBarManager
    {
        private SoftBarManager _manager = null;
        private AppBarTool _appBar = null;
        private bool _onTop = false;

        public ApplicationBarManager(SoftBarManager manager)
        {
            _manager = manager;
            _appBar = new AppBarTool();
        }

        public void RegisterApplicationBar()
        {
            _appBar.RegisterBar(_manager.Form);
        }

        public void UnregisterApplicationBar()
        {
            _appBar.RegisterBar(_manager.Form);
        }

        public void AlwaysOnTop()
        {
            _onTop = !_onTop;
            _appBar.AlwaysOnTop(_manager.Form, _onTop);
        }

        public void ProcessApplicationBarMessages(ref Message m)
        {
            _appBar.WndProc(_manager.Form, ref m);
        }
    }
}
