using SoftTeam.SoftBar.Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core
{
    public class SoftBarArea
    {
        private AreaType _type = AreaType.System;
        private List<SoftBarMenu> _menus = null;

        public SoftBarArea(AreaType type)
        {
            _type = type;
            _menus = new List<SoftBarMenu>();
        }

        //public SoftBarMenu AddMenu()
        //{
        //}

        public int Width { get => _menus.Sum(m => m.Width); }
    }
}
