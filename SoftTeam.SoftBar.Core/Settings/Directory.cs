using System.Drawing;

namespace SoftTeam.SoftBar.Core.Settings
{
    public class Directory
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string Path { get; set; }
        public bool BeginGroup { get; set; }

        public Image Image
        {
            get { return SoftTeam.SoftBar.Core.Properties.Resources.Directories; }
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
