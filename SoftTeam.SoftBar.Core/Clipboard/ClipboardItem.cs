using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core.ClipboardList
{
    public class ClipboardItem
    {
        private string _hash = "";

        public string Hash { get => _hash; set => _hash = value; }
    }
}
