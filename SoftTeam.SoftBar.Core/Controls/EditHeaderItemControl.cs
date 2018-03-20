namespace SoftTeam.SoftBar.Core.Controls
{
    public partial class EditHeaderItemControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields
        private string _name = "";
        private bool _beginGroup = false;
        #endregion

        #region Properties
        public new string Name { get => _name; set => _name = value; }
        public bool BeginGroup { get => _beginGroup; set => _beginGroup = value; }
        #endregion

        #region Constructor
        public EditHeaderItemControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Load/Save
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
        #endregion
    }
}
