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

namespace SoftTeam.SoftBar.Core.Controls
{
    public partial class EditHeaderItem : DevExpress.XtraEditors.XtraUserControl
    {
        private string _name = "";
        private bool _beginGroup = false;

        public new string Name { get => _name; set => _name = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }


        public EditHeaderItem()
        {
            InitializeComponent();
        }

        public void LoadValues()
        {
            textEditName.Text = Name;
            checkEditBeginGroup.Checked = BeginGroup;
        }

        public void SaveValues()
        {
            Name = textEditName.Text;
            BeginGroup = checkEditBeginGroup.Checked;
        }
    }
}
