using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace PLKJDS.Mapping
{
    /// <summary>
    /// 实体配置器接口
    /// </summary>
    public interface IEntityConfiguration
    {
        /// <summary>
        /// 将实体配置对象注册到实体生成器配置集合
        /// </summary>
        /// <param name="configurations">实体生成器配置集合</param>
        void RegistTo(ConfigurationRegistrar configurations);
    }
}
