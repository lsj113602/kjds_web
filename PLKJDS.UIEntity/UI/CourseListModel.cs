using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIEntity.UI
{
    public class CourseListModel
    {
        public string ID { get; set; }
        public string CourseName { get; set; }
        public string OrgName { get; set; }
        public string Desc { get; set; }
        public string CreatorUserID { get; set; }
        public string TeacherName { get; set;}
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? SerialNum { get; set; }//已开课期数
        public int? StatusCode { get; set; }
        public string LevelID { get; set; }
        public string PhotoID { get; set; }

        public string TeacherImg { get; set; }
        public int PartnerCount { get; set; }
        public bool? DeleteMark { get; set; }
    }
}
