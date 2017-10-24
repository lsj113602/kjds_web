using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    /// <summary>
    /// 机构性质
    /// </summary>
    public enum OrgProp:int
    {
        [EnumNote("国企")]
        StateOwned = 0,
        [EnumNote("私企")]
        Private = 1,
        [EnumNote("其他")]
        Other = 2

}
}
