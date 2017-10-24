using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Extend
{
    /// <summary>
    /// 提供一组对字符串对象 <see cref="System.String"/> 操作方法的扩展。
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 将字符串转换为 包含此字符串中的子字符串（由指定字符串分割）的字符串数组
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <param name="separator">决定如何分割的字符串</param>
        /// <param name="removeEmptyEntries">是否移除空元素</param>
        /// <returns></returns>
        public static string[] ToArray(this string value, string separator, bool removeEmptyEntries)
        {
            if (value.IsNull()) { value = string.Empty; }
            return value.Split(new string[] { separator }, removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }

        /// <summary>
        /// 将字符串转换为 包含此字符串中的子字符串（由指定字符串分割）的字符串数组
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <param name="separator">决定如何分割的字符串</param>
        /// <param name="count">要返回的子字符串的最大数量</param>
        /// <param name="removeEmptyEntries">是否移除空元素</param>
        /// <returns></returns>
        public static string[] ToArray(this string value, string separator, int count, bool removeEmptyEntries)
        {
            if (value.IsNull()) { value = string.Empty; }
            return value.Split(new string[] { separator }, count, removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }

        /// <summary>
        /// 将字符串转换为其表示的 bool 值。参数表示转换不成功时返回的默认值。
        /// 参数 <paramref name="friendly"/> 指示是否识别友好的条件 true 字符（如 "true", "1", "yes", "genuine", "right", "r", "checked"）。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="friendly"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string value, bool defaultValue, bool friendly = true)
        {
            if (friendly)
            {
                string[] array = { "true", "t", "1", "yes", "y", "genuine", "right", "r", "checked" };
                if (array.Contains(value, StringComparer.OrdinalIgnoreCase))
                    return true;
            }
            bool ret;
            return Boolean.TryParse(value, out ret) ? ret : defaultValue;
        }
    }
}
