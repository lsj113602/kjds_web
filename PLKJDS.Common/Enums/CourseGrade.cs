using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum CourseGrade:int
    {
        [EnumNote("初级")]
        SystemNotify = 0,
        [EnumNote("中级")]
        EmployInvite = 1,
        [EnumNote("高级")]
        InterviewFeedback = 2

    }
}
