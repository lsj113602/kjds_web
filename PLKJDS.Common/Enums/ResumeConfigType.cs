using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum ResumeConfigType:int
    {
        [EnumNote("Radio")]
        Radio = 0,
        [EnumNote("CheckBox")]
        CheckBox = 1,
        [EnumNote("Customer")]
        Customer = 2
    }
}
