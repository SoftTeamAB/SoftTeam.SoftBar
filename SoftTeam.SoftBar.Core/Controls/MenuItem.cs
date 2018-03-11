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

namespace SoftTeam.SoftBar.Core.Controls
{
    public partial class MenuItem : DevExpress.XtraEditors.XtraUserControl
    {
        private int _level = 0;

        public MenuItem(SoftBarBaseItem item, int level)
        {
            _level = level;

            InitializeComponent();
            hyperlinkLabelControlName.Text = item.Name;
            this.hyperlinkLabelControlName.ForeColor = Color.AliceBlue;
            this.pictureBoxIcon.Image = item.Image;
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
