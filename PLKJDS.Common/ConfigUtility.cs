using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace PLKJDS.Common
{
    /// <summary>
    /// 配置键操作
    /// </summary>
    public static class ConfigUtility
    {
        /// <summary>
        /// 获取指定配置项
        /// 未配置指定键时，将抛出异常
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns>键值</returns>
        public static string GetConfigValue(string key)
        {
            if (IsExistConfig(key))
            {
                return ConfigurationManager.AppSettings[key];
            }
            else
            {
                throw new Exception(string.Format("请在配置文件中AppSettings节中配置{0}节点", key));
            }
        }
        /// <summary>
        /// 判断指定配置项是否存在
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns>返回true表示存在，否则返回false</returns>
        public static bool IsExistConfig(string key)
        {
            return ConfigurationManager.AppSettings[key] != null;
        }

        #region 通用配置项,文件服务器、域名
        /// <summary>
        /// 本地写入是的绝对路径
        /// </summary>
        public static string FilePath { get { return GetConfigValue("FilePath"); } }

        /// <summary>
        /// 默认文件服务器地址
        /// </summary>
        public static string FileServerUrl { get { return GetConfigValue("FileServerUrl"); } }
        /// <summary>
        /// 文件上传服务器地址
        /// </summary>
        public static string FileUploadUrl { get { return FileServerUrl + "/Files/FileUpload.ashx"; } }
        /// <summary>
        /// 文件上传服务器地址，匿名上传
        /// </summary>
        public static string FileUploadNoTokenUrl { get { return FileServerUrl + "/Files/FileUploadNoToken.ashx"; } }
        /// <summary>
        /// 文件下载服务器地址
        /// </summary>
        public static string FileDownloadUrl { get { return FileServerUrl + "/Files/FileDownload.ashx?id="; } }
        /// <summary>
        /// 用于js通信的域名
        /// </summary>
        public static string JSDomain { get { return GetConfigValue("JSDomain"); } }
        #endregion

        #region ES配置项

        public static string ES_BasePath { get { return GetConfigValue("BasePath"); } }

        public static List<string> ES_Path
        {
            get
            {
                string path = GetConfigValue("Path");
                var paths = from it in path.Split(new char[] { ',' })
                            select string.Format("{0}{1}", ES_BasePath, it);
                return paths.ToList();
            }
        }

        #endregion

        #region 与SSO相关配置项
        /// <summary>
        /// 由SSO提供的全局登录、退出、注册的url
        /// </summary>
        public static string SSO_Login { get { return GetConfigValue("SignInUrl"); } }
        /// <summary>
        /// 登录成功后，如果没有返回页面，则默认跳转到下面指定的页面
        /// </summary>
        public static string LoginToUrl { get { return GetConfigValue("LoginToUrl"); } }

        public static string SSO_LoginOut { get { return GetConfigValue("SignOutUrl"); } }

        #endregion

        #region TradeSite的配置项
        /// <summary>
        /// 默认用户ID
        /// </summary>
        public static int TS_UID { get { return int.Parse(GetConfigValue("UID")); } }
        /// <summary>
        /// 默认订购编码
        /// </summary>
        public static string TS_OrderCode { get { return GetConfigValue("OrderCode"); } }
        /// <summary>
        /// 默认的平台客户ID
        /// </summary>
        public static int TS_PlatformCustomerID { get { return int.Parse(GetConfigValue("PlatformCustomerID")); } }
        #endregion

        #region TFrame配置项
        /// <summary>
        /// T框架站点
        /// </summary>
        public static string Site_TFramework { get { return GetConfigValue("Site_TFramework"); } }
        /// <summary>
        /// 交易前端站点
        /// </summary>
        public static string Site_Trade { get { return GetConfigValue("Site_Trade"); } }
        /// <summary>
        /// 交易前端站点-首页
        /// </summary>
        public static string Site_Trade_Index { get { return Site_Trade + "/Index.aspx"; } }
        /// <summary>
        /// 交易前端站点-产品页
        /// </summary>
        public static string Site_Trade_Product { get { return Site_Trade + "/Product/ProductExplain.aspx"; } }
        /// <summary>
        /// 用户审核前端站点
        /// </summary>
        public static string Site_UASite { get { return GetConfigValue("Site_UASite"); } }
        /// <summary>
        /// 用户审核站点-首页
        /// </summary>
        public static string Site_UASite_Index { get { return Site_UASite + "/Index.aspx"; } }
        /// <summary>
        /// 会员中心前端站点
        /// </summary>
        public static string Site_SC { get { return GetConfigValue("Site_SC"); } }
        /// <summary>
        /// 会员中心前端站点-首页
        /// </summary>
        public static string Site_SC_Index { get { return Site_SC + "/Index.aspx"; } }
        /// <summary>
        /// 代理商中心前端站点
        /// </summary>
        public static string Site_Proxy { get { return GetConfigValue("Site_Proxy"); } }
        /// <summary>
        /// 代理商中心前端站点-首页
        /// </summary>
        public static string Site_Proxy_Index { get { return Site_Proxy + "/Index.aspx"; } }

        /// <summary>
        /// 交易前端站点-我的订单
        /// </summary>
        public static string Site_Trade_MyTrade { get { return Site_Trade + "/TradeCenter/TradeManage.aspx"; } }
        /// <summary>
        /// BBS前端站点
        /// </summary>
        public static string Site_BBS { get { return GetConfigValue("Site_BBS"); } }
        /// <summary>
        /// BBS前端站点-首页
        /// </summary>
        public static string Site_BBS_Index { get { return Site_BBS + "/index.php"; } }
        /// <summary>
        /// CMS站点
        /// </summary>
        public static string Site_CMS { get { return GetConfigValue("Site_CMS"); } }
        /// <summary>
        /// 后台框架站点
        /// </summary>
        public static string Site_PFramework { get { return GetConfigValue("Site_PFramework"); } }
        #endregion

        #region DiskSite配置项
        /// <summary>
        /// 访问令牌加密密钥
        /// </summary>
        public static string AccessTokenPassword { get { return GetConfigValue("AccessTokenPassword"); } }

        #endregion

        #region EquipmentService相关配置
        /// <summary>
        /// 由SSO提供的登录验证接口的url
        /// </summary>
        public static string Rest_Login { get { return GetConfigValue("Rest_Login"); } }
        /// <summary>
        /// XXTea密钥
        /// </summary>
        public static string XXTeaKey { get { return GetConfigValue("XXTeaKey"); } }
        #endregion

        #region WCF相关配置
        /// <summary>
        /// WCF服务引用地址
        /// </summary>
        public static string WCFUrl { get { return GetConfigValue("WCFUrl"); } }
        #endregion
    }
}
