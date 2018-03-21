using DevExpress.UserSkins;
using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Settings;
using SoftTeam.SoftBar.Core.Xml;

namespace SoftTeam.SoftBar.Core.SoftBar
{
    public class SoftBarManager
    {
        #region Fields
        private SoftBarArea _systemArea = null;
        private SoftBarArea _userArea = null;
        private XmlArea _userAreaXml = null;
        private SettingsManager _settingsManager = null;
        private MainAppBarForm _form = null;
        private string _path = "";
        #endregion

        #region Properties
        public MainAppBarForm Form { get => _form; set => _form = value; }
        public SoftBarArea UserArea { get => _userArea; set => _userArea = value; }
        public SoftBarArea SystemArea { get => _systemArea; set => _systemArea = value; }

        public string Path { get => _path; set => _path = value; }
        public XmlArea UserAreaXml { get => _userAreaXml; set => _userAreaXml = value; }
        public SettingsManager SettingsManager { get => _settingsManager; set => _settingsManager = value; }
        #endregion

        #region Constructor
        public SoftBarManager(MainAppBarForm form, string path)
        {
            _form = form;
            _path = path;

            // Load settings and set theme
            _settingsManager = new SettingsManager(HelperFunctions.GetSettingsPath());
            BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = HelperFunctions.GetThemeName(_settingsManager.Settings.GetIntegerSetting(Constants.General_Theme));

            // Load user area XML
            XmlLoader loader = new XmlLoader(_path);
            _userAreaXml = loader.Load();

            _systemArea = new SoftBarArea(this, AreaType.System);
            _systemArea.Load();
            _userArea = new SoftBarArea(this, AreaType.User, _systemArea.Width);
            _userArea.Load();

            _systemArea.OnAreaResized += _systemArea_OnAreaResized;
        }

        private void _systemArea_OnAreaResized(object sender, System.EventArgs e)
        {
            _userArea.Resize();
        }
        #endregion
    }
}
