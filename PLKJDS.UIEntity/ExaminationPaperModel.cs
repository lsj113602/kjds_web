using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIEntity
{
   public class ExaminationPaperModel
    {
       public string ID { get; set; }
       public string CourserID { get; set; }
       public string CourseName { get; set; }

       public int? QuestionSum { get; set; }
       public int? SelectNum { get; set; }
       public int? TFNum { get; set; }
       public int? FullMark { get; set; }

       public int? PassMark { get; set; }

       public List<ChapterQuestionSelect> selectList { get; set; }

       public List<ChapterQuestionTR> TRList { get; set; }
      
    }
}
