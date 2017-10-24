using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public enum ChapterContentType:int
    {
        [EnumNote("视频")]
        Video = 0,
        [EnumNote("文档")]
        Doc = 1,
        [EnumNote("幻灯片")]
        Ppt = 2
    }
}
