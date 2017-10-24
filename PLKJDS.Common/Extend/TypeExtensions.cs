using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Common.Reflection;

namespace PLKJDS.Common.Extend
{
    /// <summary>
    /// 提供一组对 类型 <see cref="System.Type"/> 操作方法的扩展。
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// 判断当前 <see cref="System.Type"/> 指示的类型是否继承于（或等价于）某个 <see cref="System.Type"/> 类型。
        /// </summary>
        /// <param name="_this">当前 <see cref="System.Type"/> 对象。</param>
        /// <param name="c">用于比较的 <see cref="System.Type"/> 类型对象。</param>
        /// <returns>如果当前类型等价或继承与指定的类型，则返回 true，否则返回 false。</returns>
        public static bool IsInhertOf(this System.Type _this, System.Type c)
        {
            return _this == c || _this.IsSubclassOf(c);
        }

        /// <summary>
        /// 判断当前 <see cref="System.Type"/> 指示的类型是否实现或(等价于)某个 <see cref="System.Type"/> 指示的接口。
        /// </summary>
        /// <param name="_this">当前 <see cref="System.Type"/> 对象。</param>
        /// <param name="c">用于比较的 <see cref="System.Type"/> 类型对象，表示一个接口类型。</param>
        /// <returns>如果当前类型等价或继承与指定的接口类型，则返回 true，否则返回 false。</returns>
        public static bool IsImplementOf(this System.Type _this, System.Type c)
        {
            return _this == c || _this.GetInterfaces().Contains(c);
        }

        /// <summary>
        /// 获取当前类型的所有子类或接口实现类。
        /// </summary>
        /// <param name="_this">当前 <see cref="System.Type"/> 对象。</param>
        /// <returns>当前类型的所有子类或接口实现类。</returns>
        public static Type[] GetSubClass(this Type _this)
        {
            return GetSubClass(_this, AssemblyScope.Global);
        }

        /// <summary>
        /// 获取当前类型在指定应用程序集范围的所有子类或接口实现类。
        /// </summary>
        /// <param name="_this">当前 <see cref="System.Type"/> 对象。</param>
        /// <param name="scope">指定的应用程序集范围</param>
        /// <returns>当前类型在指定应用程序集范围的所有子类或接口实现类。</returns>
        public static Type[] GetSubClass(this Type _this, AssemblyScope scope)
        {
            return Types.GetTypes(scope).Where(type => type != _this && type.IsInhertOrImplementOf(_this)).ToArray();
        }

        /// <summary>
        /// 判断当前 <see cref="System.Type"/> 指示的类型是否实现、继承等价于某个 <see cref="System.Type"/> 指示的类型或接口。
        /// </summary>
        /// <param name="_this">当前 <see cref="System.Type"/> 对象。</param>
        /// <param name="c">用于比较的 <see cref="System.Type"/> 类型对象。</param>
        /// <returns>如果当前类型实现、继承等价于指定的类型或接口，则返回 true，否则返回 false。</returns>
        public static bool IsInhertOrImplementOf(this System.Type _this, System.Type c)
        {
            return _this.IsInhertOf(c) || _this.IsImplementOf(c);
        }
    }
}
