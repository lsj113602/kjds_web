using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum RoleAuthorizeType:int
    {
        [EnumNote("角色")]
        Role = 1,
        [EnumNote("部门")]
        Department = 2,
        [EnumNote("用户")]
        User = 3
    }
}
