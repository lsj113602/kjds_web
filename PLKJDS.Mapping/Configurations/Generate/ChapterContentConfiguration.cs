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
    partial class ChapterContentConfiguration : EntityConfiguration<ChapterContent>
    {
        /// <summary>
        /// 数据表映射构造函数
        /// </summary>
        public ChapterContentConfiguration()
        {
            ChapterContentConfigurationDefault();
            ChapterContentConfigurationAppend();
        }

        /// <summary>
        /// 默认的数据映射
        /// </summary>
        public void ChapterContentConfigurationDefault()
        {
          
			this.ToTable("ChapterContent");
            this.HasKey(t => t.ID);
            //this.Property(p => p.LastModifyUser).HasMaxLength(100);
			//this.Property(p => p.CreateUser).IsRequired().HasMaxLength(100);

        }

        /// <summary>
        /// 数据映射
        /// </summary>
        partial void ChapterContentConfigurationAppend();
    }
}
