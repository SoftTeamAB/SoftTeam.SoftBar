using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoftTeam.SoftBar.Core.Settings
{
    public class Setting
    {
        private string _key;
        private string _value;

        public Setting()
        {

        }

        public Setting(string key, string value)
        {
            _key = key;
            _value = value;
        }

        public string Key { get => _key; set => _key = value; }
        public string Value { get => _value; set => _value = value; }
    }
}
