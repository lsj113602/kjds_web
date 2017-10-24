using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIEntity
{
    public class TreeDataModel
    {
        public string name { get; set; }
        public string code { get; set; }
        public string icon { get; set; }
        public List<ChildDataModel> child { get; set; }
     }
}
