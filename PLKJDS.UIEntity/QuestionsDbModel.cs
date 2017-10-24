using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIEntity
{
    public class QuestionsDbModel
    {
        public string ID { get; set; }
        public string ChapterName { get; set; }
        public int Selects { get; set; }
        public int TRs { get; set; }
        public string PID { get; set; }
        public DateTime? CreatorTime { get; set; }
        public int Total
        {
            get
            {
                return Selects + TRs;
            }
        }
    }
}
