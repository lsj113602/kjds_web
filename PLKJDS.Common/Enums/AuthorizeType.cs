using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum AuthorizeType:int
    {
        [EnumNote("菜单")]
        Menu = 1,
        [EnumNote("按钮")]
        Button = 2
    }
}
