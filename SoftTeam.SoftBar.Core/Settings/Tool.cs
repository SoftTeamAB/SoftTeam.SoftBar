using SoftTeam.SoftBar.Core.Misc;
using System.Drawing;

namespace SoftTeam.SoftBar.Core.Settings
{
    public class Tool
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string Path { get; set; }
        public string Parameters { get; set; }
        public bool BeginGroup { get; set; }

        public Image Image
        {
            get { return HelperFunctions.ExtractIcon(IconPath); }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
