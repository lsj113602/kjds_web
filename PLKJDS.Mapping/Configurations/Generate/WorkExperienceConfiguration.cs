﻿// <autogenerated>
//   This file was generated by T4 code generator Exec.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>



using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using PLKJDS.Entity;

namespace PLKJDS.Mapping.Configurations
{
	/// <summary>
    /// 数据表映射
    /// </summary>
    partial class WorkExperienceConfiguration : EntityConfiguration<WorkExperience>
    {
        /// <summary>
        /// 数据表映射构造函数
        /// </summary>
        public WorkExperienceConfiguration()
        {
            WorkExperienceConfigurationDefault();
            WorkExperienceConfigurationAppend();
        }

        /// <summary>
        /// 默认的数据映射
        /// </summary>
        public void WorkExperienceConfigurationDefault()
        {
          
			this.ToTable("WorkExperience");
            this.HasKey(t => t.ID);
            //this.Property(p => p.LastModifyUser).HasMaxLength(100);
			//this.Property(p => p.CreateUser).IsRequired().HasMaxLength(100);

        }

        /// <summary>
        /// 数据映射
        /// </summary>
        partial void WorkExperienceConfigurationAppend();
    }
}
