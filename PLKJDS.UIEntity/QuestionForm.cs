using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIEntity
{
    public class QuestionForm
    {
        public string ID { get; set; }
        public string KeyValue { get; set;}
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string ChapterName { get; set; }
        public string ChapterID { get; set; }
        public string QuestionType { get; set; }
        public int Score { get; set; }
        public string QName { get; set; }

        public string SelectAnswer { get; set; }
        public string SelectA { get; set; }
        public string SelectB { get; set; }
        public string SelectC { get; set; }
        public string SelectD { get; set; }
        public bool TRAnswer { get; set; }

        public string UserID { get; set; }
        public string UserName { get; set; }
        public DateTime? CreatorTime { get; set; }
    }
}
