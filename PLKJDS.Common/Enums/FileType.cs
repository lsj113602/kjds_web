using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Common;
namespace PLKJDS.Common.Enums
{
    public enum FileType:int
    {
        [EnumNote("JPG")]
        JPG = 1,
        [EnumNote("MP4")]
        MP4 = 2,
        [EnumNote("BMP")]
        BMP = 3
    }
}
