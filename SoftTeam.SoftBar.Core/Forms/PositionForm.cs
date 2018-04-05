using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.Xml;
using System.IO;

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class PositionForm : DevExpress.XtraEditors.XtraForm
    {
        public ItemPosition Position { get; set; } = ItemPosition.None;

        public PositionForm(XmlMenuItemBase selected, bool insideAvailable = false)
        {
            InitializeComponent();

            simpleButtonCreateItemInside.Enabled = insideAvailable;

            pictureBoxIcon.Image = HelperFunctions.GetFileImage(selected.IconPath);
            labelControlSelectedItem.Text = selected.Name;
        }

        private void simpleButtonCreateItemBefore_Click(object sender, EventArgs e)
        {
            Position = ItemPosition.Before;
            this.Close();
        }

        private void simpleButtonCreateItemInside_Click(object sender, EventArgs e)
        {
            Position = ItemPosition.Inside;
            this.Close();
        }

        private void simpleButtonCreateItemAfter_Click(object sender, EventArgs e)
        {
            Position = ItemPosition.After;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Right)
                Position = ItemPosition.Inside;
            else if (keyData == Keys.Up)
                Position = ItemPosition.Before;
            else if (keyData == Keys.Down)
                Position = ItemPosition.After;

            this.Close();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PositionForm_Load(object sender, EventArgs e)
        {

        }
    }
}