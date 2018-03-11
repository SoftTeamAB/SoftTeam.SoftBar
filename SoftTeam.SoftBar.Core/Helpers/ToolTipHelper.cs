using DevExpress.Utils;
using System.Drawing;

namespace SoftTeam.SoftBar.Core.Helpers
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
