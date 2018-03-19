using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoftTeam.SoftBar.Core.Settings
{
    /// <summary>
    /// Class that handles a Key/Value pair
    /// </summary>
    public class Setting
    {
        #region Fields
        private string _key;
        private string _value;
        #endregion

        #region Constructors
        public Setting()
        {
        }

        public Setting(string key, string value)
        {
            _key = key;
            _value = value;
        }
        #endregion

        #region Properties
        public string Key { get => _key; set => _key = value; }
        public string Value { get => _value; set => _value = value; }
        #endregion
    }
}
