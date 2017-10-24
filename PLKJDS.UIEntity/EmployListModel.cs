using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIEntity
{
    public class EmployListModel
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string EmployID { get; set; }
        public string Title { get; set; }
        public string TypeID { get; set; }
        public DateTime? PartTime { get; set; }
        public bool? IsPass { get; set; }
        public string LevelID { get; set; }
        public string Comment { get; set; }
        public string Gender { get; set; }
        public string TrueName { get; set; }
        public string Phone { get; set; }
        public DateTime? CreatorTime { get; set; }
        public bool? DeleteMark { get; set; }
    }
}
