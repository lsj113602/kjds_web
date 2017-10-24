using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common
{
    public static class EntityCopyHelper
    {
        public static void CopyEnity<T>(T copy, T copyed) where T:class
        {
            var t = copyed.GetType();
            var props = t.GetProperties();
            foreach (var prop in props)
            {
                var value = prop.GetValue(copyed);
                if (value != null)
                {
                    var temp = copy.GetType().GetProperty(prop.Name);
                    temp.SetValue(copy, value);
                }
            }
        }
    }
}
