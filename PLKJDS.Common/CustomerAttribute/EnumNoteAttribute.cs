using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common
{
    /// <summary>
    /// Enum的说明特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.Field,AllowMultiple = false,Inherited = false)]
    public class EnumNoteAttribute:Attribute
    {
        private string _note;
        public string Note
        {
            get
            {
                return _note;
            }

            private set
            {
                _note = value;
            }
        }
        public EnumNoteAttribute(string note)
        {
            _note = note;
        }

        
    }
}
