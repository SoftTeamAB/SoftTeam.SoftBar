using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core.NewXml
{
    public class NewXmlMenuItemBase
    {
        protected string _name = string.Empty;

        public NewXmlMenuItemBase()
        {
        }

        public string Name { get => _name; set => _name = value; }
    }
}
