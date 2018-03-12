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

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class CustomizeMenuItem : DevExpress.XtraEditors.XtraForm
    {
        private SoftBarMenu _menu = null;

        public CustomizeMenuItem(SoftBarMenu menu)
        {
            InitializeComponent();
            editMenu1.Name = menu.Name;
            editMenu1.IconPath = menu.IconPath;
            editMenu1.BeginGroup = menu.BeginGroup;
            _menu = menu;

            editMenu1.LoadValues();
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            editMenu1.SaveValues();

            _menu.Name = editMenu1.Name;
            _menu.IconPath = editMenu1.IconPath;
            _menu.BeginGroup = editMenu1.BeginGroup;

            this.Close();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}