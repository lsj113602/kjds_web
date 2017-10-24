using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PLKJDS.Common.Reflection
{
    class Assemblies
    {
        /// <summary>
        /// 获取已加载至当前应用程序中指定程序集作用范围内的程序集中定义的所有类型 <see cref="System.Type"/> 集合所构成的一个数组。
        /// </summary>
        /// <param name="scope">一个 <see cref="AssemblyScope"/> 枚举值，表示指定的程序集作用范围。</param>
        /// <returns>已加载至当前应用程序中指定程序集作用范围内的程序集中定义的所有类型 <see cref="System.Type"/> 集合所构成的一个数组。</returns>
        public static Type[] GetTypes(AssemblyScope scope)
        {
            return GetAssemblies(scope).SelectMany(assembly => GetTypes(assembly)).Distinct().ToArray();
        }

        /// <summary>
        /// 获取程序集中定义的类型。
        /// 同 <seealso cref="Assembly.GetTypes"/>；但在 <seealso cref="Assembly.GetTypes"/> 基础上屏蔽了 <see cref="System.Reflection.ReflectionTypeLoadException"/> 异常。
        /// </summary>
        /// <param name="assembly">应用程序集。</param>
        /// <returns>一个数组，包含此程序集中定义的所有类型。</returns>
        public static Type[] GetTypes(Assembly assembly)
        {
            return assembly.GetTypes();
        }

        /// <summary>
        /// 获取已加载至当前应用程序中指定程序集作用范围内的程序集 <see cref="Assembly"/> 集合。
        /// </summary>
        /// <param name="scope">一个 <see cref="AssemblyScope"/> 枚举值，表示指定的程序集作用范围。</param>
        /// <returns>已加载至当前应用程序中指定程序集作用范围内的程序集 <see cref="Assembly"/> 集合所构成的一个数组。</returns>
        public static Assembly[] GetAssemblies(AssemblyScope scope)
        {
            List<Assembly> list = new List<Assembly>();
            if (scope.HasFlag(AssemblyScope.Calling))
            {
                list.Add(Assembly.GetCallingAssembly());
            }
            if (scope.HasFlag(AssemblyScope.Entry))
            {
                list.Add(Assembly.GetEntryAssembly());
            }
            if (scope.HasFlag(AssemblyScope.Executing))
            {
                list.Add(Assembly.GetExecutingAssembly());
            }
            if (scope.HasFlag(AssemblyScope.Global))
            {
                list.AddRange(AppDomain.CurrentDomain.GetAssemblies());
            }
            return list.Distinct().ToArray();
        }
    }
}
