using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum JobExperience:int
    {
        [EnumNote("不限工作经验")]
        NoLimited = 0,
        [EnumNote("一年以上")]
        Oneyear = 1,
        [EnumNote("一年到三年")]
        OneToThree=2,
        [EnumNote("三年以上")]
        ThreeyearMore=3
    }
}
