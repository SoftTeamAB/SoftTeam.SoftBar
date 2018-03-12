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
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Core.Controls
{
    public partial class MenuItem : DevExpress.XtraEditors.XtraUserControl
    {
        private int _level = 0;
        private SoftBarBaseItem _item = null;
        private MenuItemType _type = MenuItemType.None;

        public MenuItem(MenuItemType type, SoftBarBaseItem item, int level, Color color)
        {
            _type = type;
            _level = level;
            _item = item;
            InitializeComponent();
            UpdateValues();
            this.BackColor = color;
        }

        private void UpdateValues()
        {
            labelControlType.Text = HelperFunctions.GetTypeName(_type);
            pictureBoxIcon.BackColor = HelperFunctions.GetTypeColor(_type);
            hyperlinkLabelControlName.Text = _item.Name;
            pictureBoxIcon.Image = _item.Image;
            if (_item.BeginGroup)
                pictureBoxBeginGroup.BringToFront();
            else
                pictureBoxNoBeginGroup.BringToFront();
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
            else if (_item is SoftBarHeaderItem)
            {
                using (CustomizeMenuItem form = new CustomizeMenuItem((SoftBarHeaderItem)_item))
                {
                    form.ShowDialog();
                    UpdateValues();
                }
            }

        }
    }
}
