using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIEntity.UI
{
    public class CourseModel
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 图片ID
        ///</summary>
        public string PhotoID { get; set; } // PhotoID (length: 64)
        public string LevelID { get; set; }
        ///<summary>
        /// 课程大纲名称
        ///</summary>
        public string CourseName { get; set; } // CourseName (length: 64)

        ///<summary>
        /// 开始时间
        ///</summary>
        public System.DateTime? StartTime { get; set; } // StartTime

        ///<summary>
        /// 结束时间
        ///</summary>
        public System.DateTime? EndTime { get; set; } // EndTime
        ///<summary>
        /// 课程描述
        ///</summary>
        public string Desc { get; set; } // Desc (length: 2147483647)

        ///<summary>
        /// 课程创始人
        ///</summary>
        public string CourseUserName { get; set; }

        public int PartNumber { get; set; }
    }
}
