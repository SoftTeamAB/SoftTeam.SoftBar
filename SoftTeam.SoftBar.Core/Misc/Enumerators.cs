using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core.Misc
{
    public enum UserTypeEnum
    {
        None=0,
        FirstTimeUser=1,
        Wizard=2
    }

    public enum MenuItemType
    {
        None=0,
        Menu,
        SubMenu,
        HeaderItem,
        MenuItem
    }

    public enum MenuItemSelectedStatus
    {
        NotSelected,
        Selected,
        SubSelected
    }

    public enum MenuItemsDirection
    {
        Up,
        Down
    }
}
