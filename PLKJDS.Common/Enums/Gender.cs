using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum Gender:int
    {
        [EnumNote("男")]
        Male = 0,
        [EnumNote("女")]
        Female = 1
    }
}
