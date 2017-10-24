using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIEntity
{
   public class ChapterContentModel
    {
       public string ID { get; set; }
       public string CourserID { get; set; }
       public string FileID { get; set; }
       public string TypeID { get; set; }

       public string ChapterName { get; set; }
       public string PChapterName { get; set; }
       public string SumChapterName { get; set; }
       public string CreatorUserId { get; set; }

       public string CreatorTime { get; set; }
    }
}
