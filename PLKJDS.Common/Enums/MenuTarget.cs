using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum MenuTarget:int
    {
        [EnumNote("无页面")]
        expand = 0,
        [EnumNote("框架页")]
        iframe = 1,
        [EnumNote("弹出页")]
        open = 2,
        [EnumNote("新窗口")]
        blank = 3
    }
}
