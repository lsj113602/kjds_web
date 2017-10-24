using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLKJDS.UIEntity
{
   public class ChildDataModel
    {
        public string name { get; set; }
        public string code { get; set; }
        public string icon { get; set; }

        public string parentCode { get; set; }
        public List<ChildDataModel> child { get; set; }
    }
}
