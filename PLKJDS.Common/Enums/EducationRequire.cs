using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum  EducationRequire:int
    {
        [EnumNote("不限学历")]
        NoLimited=0,
        [EnumNote("大专及以上")]
        Collage=1,
        [EnumNote("本科及以上")]
        University=2
    }
}
