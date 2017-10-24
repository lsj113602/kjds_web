using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum EmployTypes:int
    {
        [EnumNote("兼职")]
        PartTime = 0,
        [EnumNote("全职")]
        FullTime = 1,
        [EnumNote("实习")]
        Practice = 2,
        [EnumNote("项目")]
        Project = 3

    }
}
