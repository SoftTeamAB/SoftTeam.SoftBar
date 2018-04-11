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

namespace SoftTeam.SoftBar.Core.Forms
{
    public partial class CaptureForm : DevExpress.XtraEditors.XtraForm
    {
        private const int WaitingStateImage = 0;
        private const int CapturingStateImage = 1;

        private ProcessCapture _capture = new ProcessCapture();

        public string ApplicationPath { get; set; }

        private enum CaptureState
        {
            Waiting,
            Capturing
        }

        private CaptureState _state = CaptureState.Waiting;

        public CaptureForm()
        {
            InitializeComponent();
        }

        private void simpleButtonCapture_Click(object sender, EventArgs e)
        {
            switch (_state)
            {
                case CaptureState.Waiting:
                    _state = CaptureState.Capturing;
                    simpleButtonCapture.ImageOptions.Image = imageListCapture.Images[CapturingStateImage];
                    simpleButtonCapture.Text = "Stop!";

                    _capture.Capture();
                    gridControlCapture.DataSource = null;
                    break;
                case CaptureState.Capturing:
                    _state = CaptureState.Waiting;
                    simpleButtonCapture.ImageOptions.Image = imageListCapture.Images[WaitingStateImage];
                    simpleButtonCapture.Text = "Capture!";

                    var result = _capture.EndCapture();
                    gridControlCapture.DataSource = result.OrderBy(p=>p.Priority);
                    if (gridViewCapture.RowCount > 0)
                    {
                        gridViewCapture.FocusedColumn = gridViewCapture.Columns[0];
                        gridViewCapture.FocusedRowHandle = 0;
                    }

                    break;
            }
        }

        private void gridViewCapture_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var row = (ExecutableCandidate)gridViewCapture.GetFocusedRow();
            ApplicationPath = row.Path;
        }

        private void simpleButtonNext_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}