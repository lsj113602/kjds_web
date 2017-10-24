using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum EmployStatu:int
    {
        [EnumNote("待审批")]
        PendingApproval=0,
        [EnumNote("审批通过")]
        Approved=1,
        [EnumNote("审批不通过")]
        Unapproval=2,
        [EnumNote("已过期")]
        Expried=3
    }
}
