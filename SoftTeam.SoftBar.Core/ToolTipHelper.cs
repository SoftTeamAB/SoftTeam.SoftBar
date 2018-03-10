using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core
{
    public static class ToolTipHelper
    {
        public static SuperToolTip CreateWarningToolTip(string errorMessage)
        {
            SuperToolTip toolTip = new SuperToolTip();
            SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
            args.Title.Text = "Warning!";
            args.Contents.Text = errorMessage;
            args.Contents.Image = new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning);
            toolTip.Setup(args);

            return toolTip;
        }
    }
}
