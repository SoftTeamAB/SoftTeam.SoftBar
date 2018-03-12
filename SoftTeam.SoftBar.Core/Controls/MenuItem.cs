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
using SoftTeam.SoftBar.Core.Forms;

namespace SoftTeam.SoftBar.Core.Controls
{
    public partial class MenuItem : DevExpress.XtraEditors.XtraUserControl
    {
        private int _level = 0;
        private SoftBarBaseItem _item = null;

        public MenuItem(SoftBarBaseItem item, int level, Color color)
        {
            _level = level;
            _item = item;
            InitializeComponent();
            UpdateValues();
            this.BackColor = color;
        }

        private void UpdateValues()
        {
            hyperlinkLabelControlName.Text = _item.Name;
            this.pictureBoxIcon.Image = _item.Image;
        }

        private void item_Click(object sender, EventArgs e)
        {
            if (_item is SoftBarMenu)
            {
                using (CustomizeMenuItem form = new CustomizeMenuItem((SoftBarMenu)_item))
                {
                    form.ShowDialog();
                    UpdateValues();
                }
            }
        }
    }
}
