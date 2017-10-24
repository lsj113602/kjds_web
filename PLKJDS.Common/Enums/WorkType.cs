using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
     public enum WorkType:int
    {
        [EnumNote("全职")]
        FulltimeJob = 0,
        [EnumNote("兼职")]
        ParttimeJob  = 1,
        [EnumNote("实习")]
        Internship = 2,
        [EnumNote("项目")]
        FieldWork = 3

    }
}
