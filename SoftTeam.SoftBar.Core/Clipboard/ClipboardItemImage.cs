using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core.ClipboardList
{
    public class ClipboardItemImage : ClipboardItem
    {
        private Image _image = null;

        public ClipboardItemImage()
        {
        }

        public ClipboardItemImage(Image image)
        {
            Image = image;
        }

        public Image Image { get => _image; set => _image = value; }
    }
}
