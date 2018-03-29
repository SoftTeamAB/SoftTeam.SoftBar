using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core.ClipboardList
{
    public class ClipboardItemText : ClipboardItem
    {
        private string _text = string.Empty;

        public ClipboardItemText()
        {
        }

        public ClipboardItemText(string text, string hash)
        {
            Text = text;
            Hash = hash;
        }

        public string Text { get => _text; set => _text = value; }
    }
}
