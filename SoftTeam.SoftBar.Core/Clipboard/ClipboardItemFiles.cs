using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core.ClipboardList
{
    public class ClipboardItemFiles : ClipboardItem
    {
        private List<string> _files = null;

        public ClipboardItemFiles()
        {
        }

        public ClipboardItemFiles(List<string> files)
        {
            Files = files;
        }

        public List<string> Files { get => _files; set => _files = value; }
    }
}
