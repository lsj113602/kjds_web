using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{
    public static class EnumExt
    {
        public static string GetEnumCode(this object enumType)
        {
            return ((int)enumType).ToString();
        }
        public static string GetEnumNote(this object enumType)
        {
            var type = enumType.GetType().GetField(enumType.ToString());
            var attrs = type.GetCustomAttributes(false);
            var note = attrs[0] as EnumNoteAttribute;
            return note.Note;
        }
        public static Dictionary<int, string> GetEnumDict<T>() where T:new()
        {
            T t = new T();
            var type = t.GetType();
            var fields = type.GetFields();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (var field in fields)
            {
                if (field.FieldType == typeof(int))
                    continue;
                int i = (int)field.GetValue(t);
                string s = (field.GetCustomAttributes(false)[0] as EnumNoteAttribute).Note;
                dict[i] = s;
            }
            return dict;
        }

        public static List<TreeSelectModel> GetEnumList<T>() where T : new()
        {
            T t = new T();
            var type = t.GetType();
            var fields = type.GetFields();
            List<TreeSelectModel> list = new List<TreeSelectModel>();
            foreach (var field in fields)
            {
                if (field.FieldType == typeof(int))
                    continue;
                TreeSelectModel tree = new TreeSelectModel();
                tree.id = ((int)field.GetValue(t)).ToString();
                tree.text = (field.GetCustomAttributes(false)[0] as EnumNoteAttribute).Note;
                list.Add(tree);
            }
            return list;
        }

        public static List<TreeSelectModel> GetEnumNoteList<T>() where T : new()
        {
            T t = new T();
            var type = t.GetType();
            var fields = type.GetFields();
            List<TreeSelectModel> list = new List<TreeSelectModel>();
            foreach (var field in fields)
            {
                if (field.FieldType == typeof(int))
                    continue;
                TreeSelectModel tree = new TreeSelectModel();
                tree.id = (field.GetCustomAttributes(false)[0] as EnumNoteAttribute).Note;
                tree.text = (field.GetCustomAttributes(false)[0] as EnumNoteAttribute).Note;
                list.Add(tree);
            }
            return list;
        }
    }
}
