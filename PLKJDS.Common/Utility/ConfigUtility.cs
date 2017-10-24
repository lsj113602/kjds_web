using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Utility
{
    public class ConfigUtility : Configs
    {
        /// <summary>
        /// 是否启用SSO
        /// </summary>
        public static bool EnableSSO { get { return IsExistConfig("EnableSSO") ? bool.Parse(GetValue("EnableSSO")) : false; } }

        /// <summary>
        /// AppCode
        /// </summary>
        public static string AppCode { get { return IsExistConfig("AppCode") ? GetValue("AppCode") : ""; } }

        /// <summary>
        /// SignInUrl
        /// </summary>
        public static string SignInUrl { get { return IsExistConfig("SignInUrl") ? GetValue("SignInUrl") : ""; } }

        /// <summary>
        /// SignOutUrl
        /// </summary>
        public static string SignOutUrl { get { return IsExistConfig("SignOutUrl") ? GetValue("SignOutUrl") : ""; } }

        /// <summary>
        /// XXTeaKey
        /// </summary>
        public static string XXTeaKey { get { return IsExistConfig("XXTeaKey") ? GetValue("XXTeaKey") : ""; } }
  
    }
}
