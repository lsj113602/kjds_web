using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIEntity
{
   public class TrainPartModel
    {
       public string ID { get; set; }

       public string TrainID { get; set; }
       public string TrueName { get; set; }
       public string Gender { get; set; }

       public string OrgName { get; set; }

       public string Phone { get; set; }
       public DateTime? PartTime { get; set; }
    }
}
