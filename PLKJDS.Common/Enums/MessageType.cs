using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum MessageType:int
    {
        [EnumNote("系统通知")]
        SystemNotify = 0,
        [EnumNote("应聘邀请")]
        EmployInvite = 1,
        [EnumNote("面试反馈")]
        InterviewFeedback = 2

    }
}
