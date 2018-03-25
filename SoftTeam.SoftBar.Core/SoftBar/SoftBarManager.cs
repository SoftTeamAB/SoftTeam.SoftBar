using DevExpress.UserSkins;
using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Settings;
using SoftTeam.SoftBar.Core.Xml;
using System.Drawing;

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
        private SoftBarFileManager _fileManager = null;
        #endregion

        #region Properties
        public MainAppBarForm Form { get => _form; set => _form = value; }
        public SoftBarArea UserArea { get => _userArea; set => _userArea = value; }
        public SoftBarArea SystemArea { get => _systemArea; set => _systemArea = value; }
        public XmlArea UserAreaXml { get => _userAreaXml; set => _userAreaXml = value; }
        public SettingsManager SettingsManager { get => _settingsManager; set => _settingsManager = value; }
        public SoftBarFileManager FileManager { get => _fileManager; set => _fileManager = value; }
        #endregion

        #region Constructor
        public SoftBarManager(MainAppBarForm form, string path)
        {
            _form = form;

            _fileManager = new SoftBarFileManager(path);

            // Load settings and set theme
            _settingsManager = new SettingsManager(_fileManager.SettingsPath);
            BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = HelperFunctions.GetThemeName(_settingsManager.Settings.GetIntegerSetting(Constants.General_Theme));

            // Load user area XML
            XmlLoader loader = new XmlLoader(_fileManager.MenuPath);
            _userAreaXml = loader.Load();

            // Setup system and user area
            _systemArea = new SoftBarArea(this, AreaType.System);
            _systemArea.Load();
            _userArea = new SoftBarArea(this, AreaType.User, _systemArea.Width);
            _userArea.Load();

            // Resize event
            _systemArea.OnAreaResized += _systemArea_OnAreaResized;

            // Paint event for separators
            _form.Paint += _form_Paint;
        }

        private void _systemArea_OnAreaResized(object sender, System.EventArgs e)
        {
            _userArea.Resize();
        }
        #endregion

        #region Separators
        private void _form_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Draw separator after system menu
            var left = _systemArea.Menus[0].Width;
            DrawSeparator(e.Graphics, left);

            // Draw another separator before user area
            left = _systemArea.Width;
            DrawSeparator(e.Graphics, left);
        }

        private void DrawSeparator(Graphics g, int left)
        {
            // Get the form color
            var formColor = _form.BackColor;
            // Get a lighter and a darker color
            var darkColor = HelperFunctions.ChangeColorBrightness(formColor, -0.3f);
            var lightColor = HelperFunctions.ChangeColorBrightness(formColor, -0.1f);

            // Create the pens
            Pen darkPen = new Pen(darkColor);
            Pen lightPen = new Pen(lightColor);

            // Draw the separator
            g.DrawLine(darkPen, left, 2, left, _form.Height - 4);
            g.DrawLine(lightPen, left + 1, 2, left + 1, _form.Height - 4);
        }
        #endregion
    }
}
