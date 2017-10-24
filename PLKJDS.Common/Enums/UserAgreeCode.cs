using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum UserAgreeCode
    {
        [EnumNote("同意")]
        Agree = 1,
        [EnumNote("不同意")]
        NoAgree = 2,
        [EnumNote("未审核")]
        UnAgree = 3
    }
}
