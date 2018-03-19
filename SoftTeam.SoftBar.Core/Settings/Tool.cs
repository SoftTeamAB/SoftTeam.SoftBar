using SoftTeam.SoftBar.Core.Misc;
using System.Drawing;

namespace SoftTeam.SoftBar.Core.Settings
{
    /// <summary>
    /// Class that represents a tool in My Tools
    /// </summary>
    public class Tool
    {
        #region Fields
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string Path { get; set; }
        public string Parameters { get; set; }
        public bool BeginGroup { get; set; }
        #endregion

        #region Properties and overrides
        public Image Image
        {
            get { return HelperFunctions.ExtractIcon(IconPath); }
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
