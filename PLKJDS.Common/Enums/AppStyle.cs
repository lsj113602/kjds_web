using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum AppStyle : int
    {
        [EnumNote("学生端")]
        Student = 0,
        [EnumNote("教师端")]
        Teacher = 1,
        [EnumNote("企业端")]
        Enterprise = 2
    }
}
