using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using PLKJDS.Common.Reflection;

namespace PLKJDS.Common.Extend
{
    /// <summary>
    /// 提供一组对 类型 <see cref="System.Type"/> 的工具操作方法。
    /// </summary>
    public static class Types
    {
        /// <summary>
        /// 获取已加载至当前应用程序中指定程序集作用范围内的程序集中定义的所有类型 <see cref="System.Type"/> 集合所构成的一个数组。
        /// </summary>
        /// <param name="scope">一个 <see cref="AssemblyScope"/> 枚举值，表示指定的程序集作用范围。</param>
        /// <returns>已加载至当前应用程序中指定程序集作用范围内的程序集中定义的所有类型 <see cref="System.Type"/> 集合所构成的一个数组。</returns>
        public static Type[] GetTypes(AssemblyScope scope)
        {
            return Assemblies.GetTypes(scope);
        }
    }
}
