using PLKJDS.Mapping.ConfigurationFactories;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PLKJDS.Data
{
    public class PLKJDSDbContext : System.Data.Entity.DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nameOrConnectionString">数据库名称或连接字符串。</param>
        public PLKJDSDbContext(string nameOrConnectionString = "PLKJDS")
            : base(nameOrConnectionString)
        {
            // 禁用实体状态改变跟踪
            Configuration.AutoDetectChangesEnabled = false;
            // 禁用导航属性延迟加载
            Configuration.LazyLoadingEnabled = false;
            // 禁用自动创建代理类
            Configuration.ProxyCreationEnabled = false;
            // 禁用数据库null语义
            Configuration.UseDatabaseNullSemantics = true;
            // 禁用保存时验证所跟踪实体
            Configuration.ValidateOnSaveEnabled = false;
        }

        /// <summary>
        /// 模型配置重写
        /// </summary>
        /// <param name="modelBuilder">数据实体生成器</param>
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            //兼容oracle，需要设置默认schema
            if (this.Database.Connection.GetType().Name.Equals("OracleConnection"))
            {
                string schema = Regex.Match(this.Database.Connection.ConnectionString, @"[User Id,uid]=([^;]+)").Groups[1].Value;
                modelBuilder.HasDefaultSchema(schema);
            }
            // 禁用一对多级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // 禁用多对多级联删除
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            // 禁用表名自动复数规则
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            ConfigurationFactory.ConfigurationsInit(modelBuilder.Configurations);
        }
    }
}
