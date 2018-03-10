using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace SoftTeam.SoftBar.Core
{
    public partial class MenuItem : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _headerItem = false;
        private int _level = 0;
        public MenuItem(SoftBarMenuItem item, int level, bool headerItem = false)
        {
            _level = level;
            _headerItem = headerItem;

            InitializeComponent();
            hyperlinkLabelControlName.Text = item.Name;
            if (headerItem)
                this.hyperlinkLabelControlName.ForeColor = Color.AliceBlue;
            else
                this.hyperlinkLabelControlName.ForeColor = Color.LightGreen;
            this.pictureBoxIcon.Image = item.Image;
        }

        public MenuItem(SoftBarMenu menu, int level)
        {
            _level = level;
            _headerItem = false;

            InitializeComponent();
            hyperlinkLabelControlName.Text = menu.Name;
            this.hyperlinkLabelControlName.ForeColor = Color.PaleVioletRed;

            this.pictureBoxIcon.Image = menu.Image;
        }

        private void MenuItem_Paint(object sender, PaintEventArgs e)
        {
            Skin currentSkin = CommonSkins.GetSkin(defaultLookAndFeelSoftBar.LookAndFeel);
            Color backColor = currentSkin.Colors.GetColor(DevExpress.Skins.CommonColors.Window);

            var percent = 1.5f;

            ControlPaint.Dark(backColor, percent);
        }
    }
}
