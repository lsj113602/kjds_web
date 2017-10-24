using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIEntity.UI
{
    public class TrainListModel
    {
        public string ID { get; set; }
        public string PhotoID { get; set; }
        public string Host { get; set; }
        public string StatusCode { get; set; }
        public string Content { get; set; }
        public string TrainTitle { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? ApplySTime { get; set; }
        public DateTime? ApplyETime { get; set; }
        public string Summary { get; set; }
        public int LimitNumber { get; set; }
        public int PartNumber { get; set; }
        public string UserName { get; set; }
        public bool? DeleteMark { get; set; }

    }
}
