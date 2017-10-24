using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum CourseStatu:int
    {
        [EnumNote("即将开课")]
        SystemNotify = 0,
        [EnumNote("开课中")]
        EmployInvite = 1,
        [EnumNote("已结课")]
        InterviewFeedback = 2

    }
}
