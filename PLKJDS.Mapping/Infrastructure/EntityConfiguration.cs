using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace PLKJDS.Mapping
{
    /// <summary>
    /// 实体配置基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class EntityConfiguration<TEntity> : EntityTypeConfiguration<TEntity>, IEntityConfiguration where TEntity : class
    {
        public EntityConfiguration()
        {

        }

        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
