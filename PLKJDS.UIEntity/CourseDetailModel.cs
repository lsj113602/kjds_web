using PLKJDS.Entity;
using PLKJDS.UIEntity.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIEntity
{
    public class CourseDetailModel
    {
       public  CourseListModel coursemodel { get; set; }
       public List<ChapterAndFile> chapter { get; set; }

       public  List<CourseTeacherModel> teachers { get; set; }

       public  CourseDetailModel()
       {
           coursemodel = new CourseListModel();
           chapter = new List<ChapterAndFile>();
           teachers = new List<CourseTeacherModel>();
       }
    }
}
