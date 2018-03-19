using System.Drawing;

namespace SoftTeam.SoftBar.Core.Settings
{
    /// <summary>
    /// Class for a directory in My Directories
    /// </summary>
    public class Directory
    {
        #region Fields
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string Path { get; set; }
        public bool BeginGroup { get; set; }
        #endregion

        #region Properties and overrides
        public Image Image
        {
            get { return SoftTeam.SoftBar.Core.Properties.Resources.Directories; }
        }


        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
