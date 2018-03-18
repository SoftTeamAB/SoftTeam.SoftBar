using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core.Settings
{
    public class Tool
    {
        public string Name = "";
        public string IconPath = "";
        public string Path = "";
        public string Parameters = "";
        public bool BeginGroup = false;

        public override string ToString()
        {
            return Name;
        }
    }
}
